using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;


namespace Project2.Models.Domain
{
    public class VoorstelInBehandelingState : VoorstelState
    {
        protected internal VoorstelInBehandelingState(Voorstel voorstel) : base(voorstel)
        {
            this.Naam = "Voorstel in behandeling";
        }

        protected override void VoorstelGoedkeuren()
        {
            Voorstel.toGoedGekeurdState();
        }

        protected override void AdviesVragenBPC()
        {
            Voorstel.toAdviesBPCState();
        }

        protected override void GoedkeurenMetFeedback()
        {
            Voorstel.toGoedGekeurdMetFeedbackState();
        }
    }
}
