using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Project2.Models.Domain
{
    public class Feedback
    {
        List<String> keuzes = new List<string>();
        public int Id
        {
            get;
            set;
        }

        public String ScoreTitel
        {
            get;
            set;
        }

        public String ScoreContext
        {
            get;
            set;
        }

        public String ScoreSmart
        {
            get;
            set;
        }

        public String ScoreOnderzoeksvraag
        {
            get;
            set;
        }

        public String ScoreBijdrage
        {
            get;
            set;
        }

        public String ScoreOnderwerp
        {
            get;
            set;
        }

        public String ScoreReferentielijst
        {
            get;
            set;
        }

        public String Suggesties
        {
            get;
            set;
        }

        public bool IsDefinitief
        {
            get;
            set;
        }
    }
}
