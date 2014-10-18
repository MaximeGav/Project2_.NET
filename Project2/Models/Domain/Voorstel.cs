using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;
using System.Web.WebPages;
using Project2.Models.Domain.State_pattern;

namespace Project2.Models.Domain
{
    public class Voorstel
    {
        public Voorstel()
        {
            
        }

        public int id { get; set; }
        public Voorstel(string titel, OnderzoeksDomein onderzoeksDomein1, OnderzoeksDomein onderzoeksDomein2, string trefwoorden, string context, string onderzoeksvraag, string aanpaksPlan, bool isDefinitief)
        {
            this.OnderzoeksDomein1 = onderzoeksDomein1;
            this.OnderzoeksDomein2 = onderzoeksDomein2;
            this.Titel = titel;
            this.Trefwoorden = trefwoorden;
            this.Context = context;
            this.AanpaksPlan = aanpaksPlan;
            this.Onderzoeksvraag = onderzoeksvraag;
            this.IsDefinitief = isDefinitief;
        }

        public Voorstel(string naamCP, string voornaamCP, string emailCP, string organisatieCP, string titel, OnderzoeksDomein onderzoeksDomein1, OnderzoeksDomein onderzoeksDomein2, string trefwoorden, string context, string onderzoeksvraag, string aanpaksPlan, bool isDefinitief)
        {
            this.Titel = titel;
            this.OnderzoeksDomein1 = onderzoeksDomein1;
            this.Trefwoorden = trefwoorden;
            this.Context = context;
            this.AanpaksPlan = aanpaksPlan;
            this.Onderzoeksvraag = onderzoeksvraag;
            this.NaamCP = naamCP;
            this.VoornaamCP = voornaamCP;
            this.OrganisatieCP = organisatieCP;
            this.EmailCP = emailCP;
            this.IsDefinitief = isDefinitief;
        }

        public string Titel
        {
            get;
            set;
        }

        public string Trefwoorden
        {
            get;
            set;
        }

        public string Context
        {
            get;
            set;
        }

        public string Onderzoeksvraag
        {
            get;
            set;
        }

        public string AanpaksPlan
        {
            get;
            set;
        }

        public string ReferentieLijst
        {
            get;
            set;
        }

        public string NaamCP
        {
            get;
            set;
        }

        public string VoornaamCP
        {
            get;
            set;
        }

        public string EmailCP
        {
           get;
           set;
            
        }

        public string OrganisatieCP
        {
            get;
            set;
        }

        public bool IsDefinitief
        {
            get;
            set;
        }

        public bool IsAanvaard
        {
            get;
            set;
        }
       
        public VoorstelState CurrentState
        {
            get;
            set;
        }

        private String _Status;
        public String Status {
            get
            {
                return _Status;
            }


            set
            {
                if(value!=_Status)
                {
                _Status = value;
                switch (value)
                {
                    case "Voorstel in behandeling":
                        toVoorstelInBehandelingState();
                        break;
                    case "Nieuw voorstel":
                        toVoorstelNieuwState();
                        break;
                    case "Goedgekeurd met opmerkingen":
                        toGoedGekeurdMetFeedbackState();
                        break;
                    case "Goedgekeurd":
                        toGoedGekeurdState();
                        break;
                    case "Advies BPC":
                        toAdviesBPCState();
                        break;
                }
               }
            }
        }

        public void toVoorstelInBehandelingState()
        {
            CurrentState = new VoorstelInBehandelingState(this);
            Status = CurrentState.Naam;
        }

        public void toVoorstelNieuwState()
        {

            CurrentState = new VoorstelNieuwState(this);
            Status = CurrentState.Naam;
        }

        public void toGoedGekeurdMetFeedbackState()
        {
            CurrentState = new GoedgekeurdMetFeedbackState(this);
            Status = CurrentState.Naam;
        }

        public void toGoedGekeurdState()
        {
            CurrentState = new VoorstelGoedgekeurdState(this);
            Status = CurrentState.Naam;
        }

        public void toAdviesBPCState()
        {
            CurrentState = new AdviesBPCState(this);
            Status = CurrentState.Naam;
        }

        public virtual OnderzoeksDomein OnderzoeksDomein1
        {
            get;
            set;
        }

        public virtual OnderzoeksDomein OnderzoeksDomein2
        {
            get;
            set;
        }

        public bool HasCoPromotor()
        {
            if (NaamCP.IsEmpty() && VoornaamCP.IsEmpty() && EmailCP.IsEmpty() && OrganisatieCP.IsEmpty())
                return false;
            return true;
        }

        public virtual Feedback Feedback1
        {
            get;
            set;
        }

        public virtual Advies Advies
        {
            get;
            set;
        }

        public void geefVraagAdvies(String vraag)
        {
            toAdviesBPCState();
            Advies advies = new Advies();
            advies.Vraag = vraag;
            Advies = advies;

        }
        
    }
}
