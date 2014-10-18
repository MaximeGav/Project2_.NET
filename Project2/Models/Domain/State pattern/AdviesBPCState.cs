using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project2.Models.Domain.State_pattern
{
    public class AdviesBPCState : VoorstelState
    {
        protected internal AdviesBPCState(Voorstel voorstel) : base(voorstel)
        {
            this.Naam = "Advies BPC";
        }

        protected override void AdviesGeven()
        {
            Voorstel.toVoorstelInBehandelingState();
        }
    }
}