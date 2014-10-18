using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Project2.Models.Domain
{
    public class Gebruiker
    {
        const int MIN_LENGTH_PASSWORD = 6, MAX_LENGTH_PASSWORD = 20;
        /// <summary>
        /// </summary>
        public string voornaam { get; set; }
        public string familienaam { get; set; }
        public string wachtwoord { get; set; }
        public string email { get; set; }
        public int id { get; set; }
        public bool IsEersteLogin { get; set; }
        public string username { get; set; }

        /// <summary>
        /// </summary>

        public String VolledigeNaam
        {
            get { return voornaam + " " + familienaam; }
        }

        
        public String GenereerNieuwWachtwoord()
        {
            String nieuwWachtwoord = RandomPassword.Generate(MIN_LENGTH_PASSWORD, MAX_LENGTH_PASSWORD);
            wachtwoord = CalculateSHA256(nieuwWachtwoord);
            return nieuwWachtwoord;
        }

        private Boolean IsValidPassword(string passwoord)
        {
            Boolean IsMinLength = passwoord.Length >= 6;
            Boolean IsMaxLength = passwoord.Length <= 20;
            Boolean HasCapitalLetter = passwoord.Any(char.IsUpper);
            Boolean HasSmallLetter = passwoord.Any(char.IsLower);
            Boolean HasNumber = passwoord.Any(char.IsNumber);
            Boolean HasSymbol = passwoord.Any(char.IsSymbol);
            if (IsMinLength && IsMaxLength)
            {
                int Validation = 0;
                if (HasCapitalLetter) Validation++;
                if (HasSmallLetter) Validation++;
                if (HasNumber) Validation++;
                if (HasSymbol) Validation++;
                if (Validation >= 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void VeranderWachtwoord(String wachtwoord)
        {
            if (IsValidPassword(wachtwoord))
            {
                this.wachtwoord = CalculateSHA256(wachtwoord);
            }
            else
            {
                throw new InvalidPasswordException();
            }
        }

        public Boolean Login(string wachtwoord)
        {
            if(CalculateSHA256(wachtwoord)==this.wachtwoord)
            {
                return true;
            }
            return false;
        }

        public string CalculateSHA256(String password)
        {
            SHA256Managed crypt = new SHA256Managed();
            ASCIIEncoding enc = new ASCIIEncoding();
            string hash = BitConverter.ToString(crypt.ComputeHash(enc.GetBytes(password)));
            hash = hash.Replace("-", "").ToUpper();
            return hash;
        }



       public class InvalidPasswordException : Exception
        {
            public override string Message
            {
                get
                {
                    return "Het wachtwoord moet minimaal 6 en maximaal 20 karakters lang zijn en moet een combinatie zijn van tenminste 3 van de volgende karakters: hoofdletters, kleine letters, getallen & symbolen.";
                }
            }

        }
    }

}

