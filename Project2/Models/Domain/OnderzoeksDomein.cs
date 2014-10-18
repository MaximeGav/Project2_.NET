using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Project2.Models.Domain
{
    public class OnderzoeksDomein
    {

        public OnderzoeksDomein()
        {}

        public OnderzoeksDomein(int id, string naam)
        {
            this.Id = id;
            this.Naam = naam;
        }
        public int Id
        {
            get;
            set;
        }

        [DisplayName("Onderzoeksdomein")]
        public string Naam
        {
            get;
            set;
        }
    }
}
