using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Project2.Models.Domain
{
    [NotMapped]
    public abstract class VoorstelState
    {
       

        protected VoorstelState(Voorstel voorstel)
        {
            this.Voorstel = voorstel;
        }

        public virtual Voorstel Voorstel
        {
            get;
            set;
        }

        public String Naam { get; set; }

        protected virtual void AdviesGeven()
        {
            
        }

        protected virtual void AdviesVragenBPC()
        {
            
        }

        protected virtual void GoedkeurenMetFeedback()
        {
            
        }

        protected virtual void VoorstelAfkeuren()
        {
            
        }

        protected virtual void VoorstelGoedkeuren()
        {
            
        }

        protected virtual void VoorstelIndienen()
        {
            
        }
    }
}
