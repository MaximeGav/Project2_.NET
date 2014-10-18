using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Models.Domain
{
    public class Student : Gebruiker
    {
     

        public Student()
        {
            
        }
        public Student(string voornaam, string familienaam, string wachtwoord)
        {
            this.voornaam = voornaam;
            this.familienaam = familienaam;
            this.wachtwoord = wachtwoord;
        }
        public virtual Voorstel Voorstel
        {
            get;
            set;
        }

        public virtual Promotor Promotor
        {
            get;
            set;
        }

        public void VoorstelIndienen(Voorstel Voorstel, Boolean IsDefinitief)
        {
            this.Voorstel = Voorstel;
            Voorstel.IsDefinitief = IsDefinitief;
            switch(IsDefinitief)
            {
                case true:
                    Voorstel.toVoorstelInBehandelingState();
                    break;
                case false:
                    Voorstel.toVoorstelNieuwState();
                    break;
            }
        }


        public void AanvaardFeedback()
        {
            Voorstel.IsAanvaard = true;
        }

        public void VoorstelGoedkeuren(Voorstel voorstel)
        {
            this.Voorstel = voorstel;
            voorstel.toGoedGekeurdState();  
        }

        public void VoorstelGoedkeurenMetOpmerkingen(Voorstel voorstel)
        {
            this.Voorstel = voorstel;
            voorstel.toGoedGekeurdMetFeedbackState();
        }

        public void VoorstelAfkeuren()
        {
            this.Voorstel = null;
        }
        
    }
}
