using Project2.Models.DAL;
using Project2.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Project2.MySqlSecurity
{
    public class MySqlWebSecurity
    {
        public enum Role
        {
            Student,
            Promotor,
            BpCoordinator,
            Anonymous
        }
        private AppContext context;
        AccountRepository acc;
        public MySqlWebSecurity(AppContext context)
        {
            this.context = context;
            acc = new AccountRepository(context);
        }
        public Boolean ValidateUser(String login, String password)
        {


            Gebruiker g = acc.FindByEmail(login);

            if (g != null && g.Login(password))
            {
                return true;
            }
            return false;
        }




        public bool IsFirstLogin(String email)
        {
            Gebruiker g = acc.FindByEmail(email);
            if (g.IsEersteLogin != null) return g.IsEersteLogin;
            return false;
        }

        public Role GetUserRole(String email)
        {
            Gebruiker g = acc.FindByEmail(email);
            if (g == null) return Role.Anonymous;
            if (g.GetType() == typeof(BPCoordinator))
            {
                return Role.BpCoordinator;
            }
            else if (g.GetType() == typeof(Promotor))
            {
                return Role.Promotor;
            }
            else if (g.GetType() == typeof(Student))
            {
                return Role.Student;
            }
            return Role.Student;
        }

        internal String ChangePassword(string login, string nieuwWachtwoord, bool isEersteLogin = false, bool generateNewPassword = false)
        {
           
            Gebruiker g = acc.FindByEmail(login);
            String returnPass = "";
            if(!generateNewPassword)
            {
                g.VeranderWachtwoord(nieuwWachtwoord);
                returnPass = nieuwWachtwoord;
            }
            else
            {
                returnPass = g.GenereerNieuwWachtwoord();
            }
            if (isEersteLogin)
            {
                g.IsEersteLogin = false;
            }
            context.SaveChanges();
            return returnPass;
        }
        
    }

   
}