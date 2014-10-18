using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project2.Models.Domain.State_pattern
{
    public class GoedgekeurdMetFeedbackState : VoorstelState
    {
        protected internal GoedgekeurdMetFeedbackState(Voorstel voorstel) : base(voorstel)
        {
            this.Naam = "Goedgekeurd met opmerkingen";
        }
    }
}