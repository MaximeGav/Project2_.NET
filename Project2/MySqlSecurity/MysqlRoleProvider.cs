
using System.Web.Security;
using System.Configuration.Provider;
using System.Collections.Specialized;
using System;
using System.Data;
using System.Data.Odbc;
using System.Configuration;
using System.Diagnostics;
using System.Web;
using System.Globalization;
using Project2.Models.DAL;

/*

This provider works with the following schema for the tables of role data.

CREATE TABLE Roles
(
  Rolename Text (255) NOT NULL,
  ApplicationName Text (255) NOT NULL,
    CONSTRAINT PKRoles PRIMARY KEY (Rolename, ApplicationName)
)

CREATE TABLE UsersInRoles
(
  Username Text (255) NOT NULL,
  Rolename Text (255) NOT NULL,
  ApplicationName Text (255) NOT NULL,
    CONSTRAINT PKUsersInRoles PRIMARY KEY (Username, Rolename, ApplicationName)
)

*/


namespace Project2.MySqlSecurity
{

    public sealed class MysqlRoleProvider : RoleProvider
    {


        //
        // Global connection string, generic exception message, event log info.
        //

        private string eventSource = "OdbcRoleProvider";
        private string eventLog = "Application";
        private string exceptionMessage = "An exception occurred. Please check the Event Log.";

        private ConnectionStringSettings pConnectionStringSettings;
        private string connectionString;


        //
        // If false, exceptions are thrown to the caller. If true,
        // exceptions are written to the event log.
        //

        private bool pWriteExceptionsToEventLog = false;

        public bool WriteExceptionsToEventLog
        {
            get { return pWriteExceptionsToEventLog; }
            set { pWriteExceptionsToEventLog = value; }
        }

        public override void Initialize(string name, NameValueCollection config)
        {
            // Initialize the abstract base class.
            base.Initialize(name, config);




            //
            // Initialize OdbcConnection.
            //

            pConnectionStringSettings = ConfigurationManager.
              ConnectionStrings[config["connectionStringName"]];

            if (pConnectionStringSettings == null || pConnectionStringSettings.ConnectionString.Trim() == "")
            {
                throw new ProviderException("Connection string cannot be blank.");
            }

            connectionString = pConnectionStringSettings.ConnectionString;
        }

        //
        // System.Configuration.Provider.ProviderBase.Initialize Method
        //

        //
        // System.Web.Security.RoleProvider properties.
        //


        private string pApplicationName;


        public override string ApplicationName
        {
            get { return pApplicationName; }
            set { pApplicationName = value; }
        }

        //
        // System.Web.Security.RoleProvider methods.
        //

        //
        // RoleProvider.AddUsersToRoles
        //

        public override void AddUsersToRoles(string[] usernames, string[] rolenames)
        {
            throw new NotImplementedException();
        }


        //
        // RoleProvider.CreateRole
        //

        public override void CreateRole(string rolename)
        {
            throw new NotImplementedException();
        }


        //
        // RoleProvider.DeleteRole
        //

        public override bool DeleteRole(string rolename, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }


        //
        // RoleProvider.GetAllRoles
        //

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }


        //
        // RoleProvider.GetRolesForUser
        //

        public override string[] GetRolesForUser(string username)
        {
            MySqlWebSecurity security = new MySqlWebSecurity(new AppContext());
            MySqlWebSecurity.Role role = security.GetUserRole(username);

            switch (role.ToString())
            {
                case "BpCoordinator":
                    if (role == MySqlWebSecurity.Role.BpCoordinator) return new String[] { "BpCoordinator" };
                    break;
                case "Student":
                    if (role == MySqlWebSecurity.Role.Student) return new String[] { "Student" };
                    break;
                case "Promotor":
                    if (role == MySqlWebSecurity.Role.Promotor) return new String[] { "Promotor" };
                    break;
                case "Anonymous":
                    if(role==MySqlWebSecurity.Role.Anonymous) return new string[]{"Anonymous"};
                    break;

            }

            return null;
        }


        //
        // RoleProvider.GetUsersInRole
        //

        public override string[] GetUsersInRole(string rolename)
        {
            throw new NotImplementedException();
        }


        //
        // RoleProvider.IsUserInRole
        //

        public override bool IsUserInRole(string username, string rolename)
        {
            MySqlWebSecurity security = new MySqlWebSecurity(new AppContext());
            MySqlWebSecurity.Role role = security.GetUserRole(username);

            switch (rolename)
            {
                case "BpCoordinator":
                    if (role == MySqlWebSecurity.Role.BpCoordinator) return true;
                    break;
                case "Student":
                    if (role == MySqlWebSecurity.Role.Student) return true;
                    break;
                case "Promotor":
                    if (role == MySqlWebSecurity.Role.Promotor) return true;
                    break;
                case "Anonymous":
                    if (role == MySqlWebSecurity.Role.Anonymous) return true;
                    break;
            }

            return false;
        }


        //
        // RoleProvider.RemoveUsersFromRoles
        //

        public override void RemoveUsersFromRoles(string[] usernames, string[] rolenames)
        {
            throw new NotImplementedException();
        }


        //
        // RoleProvider.RoleExists
        //

        public override bool RoleExists(string rolename)
        {
            bool exists = false;

            OdbcConnection conn = new OdbcConnection(connectionString);
            OdbcCommand cmd = new OdbcCommand("SELECT COUNT(*) FROM Roles " +
                      " WHERE Rolename = ? AND ApplicationName = ?", conn);

            cmd.Parameters.Add("@Rolename", OdbcType.VarChar, 255).Value = rolename;
            cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = ApplicationName;

            try
            {
                conn.Open();

                int numRecs = (int)cmd.ExecuteScalar();

                if (numRecs > 0)
                {
                    exists = true;
                }
            }
            catch (OdbcException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "RoleExists");
                }
                else
                {
                    throw e;
                }
            }
            finally
            {
                conn.Close();
            }

            return exists;
        }

        //
        // RoleProvider.FindUsersInRole
        //

        public override string[] FindUsersInRole(string rolename, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        //
        // WriteToEventLog
        //   A helper function that writes exception detail to the event log. Exceptions
        // are written to the event log as a security measure to avoid private database
        // details from being returned to the browser. If a method does not return a status
        // or boolean indicating the action succeeded or failed, a generic exception is also 
        // thrown by the caller.
        //

        private void WriteToEventLog(OdbcException e, string action)
        {
            EventLog log = new EventLog();
            log.Source = eventSource;
            log.Log = eventLog;

            string message = exceptionMessage + "\n\n";
            message += "Action: " + action + "\n\n";
            message += "Exception: " + e.ToString();

            log.WriteEntry(message);
        }

    }
}
