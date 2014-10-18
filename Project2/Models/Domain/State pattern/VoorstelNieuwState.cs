using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;


namespace Project2.Models.Domain
{
    public class VoorstelNieuwState : VoorstelState
    {
        protected internal VoorstelNieuwState(Voorstel voorstel) : base(voorstel)
        {
            this.Naam = "Nieuw Voorstel";
        }

        protected override void VoorstelIndienen()
        {
            Voorstel.toVoorstelInBehandelingState();
        }
    }
}
