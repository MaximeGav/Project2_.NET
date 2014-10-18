using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project2.Models.Domain.State_pattern
{
    public class VoorstelGoedgekeurdState : VoorstelState
    {
        protected internal VoorstelGoedgekeurdState(Voorstel voorstel) : base(voorstel)
        {
            this.Naam = "Goedgekeurd";
        }
    }
}