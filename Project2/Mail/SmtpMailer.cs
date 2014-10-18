using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;


namespace Project2.Mail
{
    public class SmtpMailer
    {
        const String USERNAME="project2groep02@gmail.com", WACHTWOORD="verhelstsucktoplol";


       
          public void SendMailPassword(String toMail, String password) {
            MailMessage mail = new MailMessage();

            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            smtpServer.Credentials = new System.Net.NetworkCredential(USERNAME, WACHTWOORD);
            smtpServer.Port = 587; 
            smtpServer.EnableSsl = true;


            mail.From = new MailAddress(USERNAME, "Bachelorproefapplicatie");
            mail.To.Add(toMail);
            mail.Subject = "Wachtwoord vergeten";
            mail.Body = "Uw nieuw wachtwoord is : " + password;

            smtpServer.Send(mail);
        }
    }
}