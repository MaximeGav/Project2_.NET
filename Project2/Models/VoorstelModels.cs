using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Ninject;
using Project2.Models.Domain;

namespace Project2.Models
{
    
        public class VoorstelIndienenModel
        {
            [Display(Name = "Voornaam co-promotor")]
            public string Voornaamcp { get; set; }

            [Display(Name = "Naam co-promotor")]
            public string Naamcp { get; set; }

            [Display(Name = "Email co-promotor")]
            [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",
                ErrorMessage = "Gelieve een geldig e-mailadres in te vullen")]
            public string Emailcp { get; set; }

            [Display(Name = "Organisatie co-promotor")]
            public string Organisatiecp { get; set; }

            [Display(Name = "Titel bachelorproef")]
            [Required(ErrorMessage = "*")]
            [DataType(DataType.MultilineText)]
            public string Titel { get; set; }

            [Display(Name = "Onderzoeksdomein 1")]
            [Required(ErrorMessage = "*")]
            public OnderzoeksDomein OnderzoeksDomein1 { get; set; }

            [Display(Name = "Onderzoeksdomein 2")]
            public OnderzoeksDomein OnderzoeksDomein2 { get; set; }

            [Display(Name = "Trefwoorden")]
            [DataType(DataType.MultilineText)]
            public string Trefwoorden { get; set; }

            [Display(Name = "Context")]
            [Required(ErrorMessage = "*")]
            [DataType(DataType.MultilineText)]
            public string Context { get; set; }

            [Display(Name = "Onderzoeksvraag")]
            [Required(ErrorMessage = "*")]
            [DataType(DataType.MultilineText)]
            public string Onderzoeksvraag { get; set; }

            [Display(Name = "Plan van aanpak")]
            [Required(ErrorMessage = "*")]
            [DataType(DataType.MultilineText)]
            public string PlanVanAanpak { get; set; }

            [Display(Name = "Referentielijst")]
            [Required(ErrorMessage = "*")]
            [DataType(DataType.MultilineText)]
            public string ReferentieLijst { get; set; }

            [Display(Name = "Definitief")]
            public bool IsDefinitief { get; set; }

            [Display(Name = "Status")]
            public string Status { get; set; }

            public List<OnderzoeksDomein> OnderzoeksDomeinen { get; set; }
        }

    public class FeedbackModel
        {
            //---------- Alle details van voorstel ----------//
            [Display(Name = "Voornaam co-promotor")]
            public string Voornaamcp { get; set; }

            [Display(Name = "Naam co-promotor")]
            public string Naamcp { get; set; }

            [Display(Name = "Email co-promotor")]
            public string Emailcp { get; set; }

            [Display(Name = "Organisatie co-promotor")]
            public string Organisatiecp { get; set; }

            public int Id { get; set; }

            [Display(Name = "Titel bachelorproef")]
            public string Titel { get; set; }

            [Display(Name = "Onderzoeksdomein 1")]
            public OnderzoeksDomein OnderzoeksDomein1 { get; set; }

            [Display(Name = "Onderzoeksdomein 2")]
            public OnderzoeksDomein OnderzoeksDomein2 { get; set; }

            [Display(Name = "Trefwoorden")]
            public string Trefwoorden { get; set; }

            [Display(Name = "Context")]
            public string Context { get; set; }

            [Display(Name = "Onderzoeksvraag")]
            public string Onderzoeksvraag { get; set; }

            [Display(Name = "Plan van aanpak")]
            public string PlanVanAanpak { get; set; }

            [Display(Name = "Referentielijst")]
            public string ReferentieLijst { get; set; }

            [Display(Name = "Voorstel is definitief?")]
            public bool IsDefinitief { get; set; }

            [Display(Name = "Feedback aanvaard?")]
            public bool IsAanvaard { get; set; }

            [Display(Name = "Status")]
            public string Status { get; set; }

            //---------- Alle scores ----------//
            [Display(Name = "Duidelijkheid titel")]
            [Required(ErrorMessage = "*")]
            public string ScoreTitel { get; set; }

            [Display(Name = "Duidelijkheid context")]
            [Required(ErrorMessage = "*")]
            public string ScoreContext { get; set; }

            [Display(Name = "Onderzoeksvraag is S.M.A.R.T.")]
            [Required(ErrorMessage = "*")]
            public string ScoreSmart { get; set; }

            [Display(Name = "Onderzoeksvraag is gebaseerd op reëel probleem")]
            [Required(ErrorMessage = "*")]
            public string ScoreOnderzoeksvraag { get; set; }

            [Display(Name = "Duidelijkheid bijdrage student")]
            [Required(ErrorMessage = "*")]
            public string ScoreBijdrage { get; set; }

            [Display(Name = "Onderwerpkeuze")]
            [Required(ErrorMessage = "*")]
            public string ScoreOnderwerp { get; set; }

            [Display(Name = "Referentielijst")]
            [Required(ErrorMessage = "*")]
            public string ScoreReferentielijst { get; set; }

            [DataType(DataType.MultilineText)]
            [Display(Name = "Suggesties")]
            public string Suggesties { get; set; }
        }

        public class AdviesVragenModel
        {
            //---------- Alle details van voorstel ----------//
            [Display(Name = "Voornaam co-promotor")]
            public string Voornaamcp { get; set; }

            [Display(Name = "Naam co-promotor")]
            public string Naamcp { get; set; }

            [Display(Name = "Email co-promotor")]
            public string Emailcp { get; set; }

            [Display(Name = "Organisatie co-promotor")]
            public string Organisatiecp { get; set; }

            public int Id { get; set; }

            [Display(Name = "Titel bachelorproef")]
            public string Titel { get; set; }

            [Display(Name = "Onderzoeksdomein 1")]
            public OnderzoeksDomein OnderzoeksDomein1 { get; set; }

            [Display(Name = "Onderzoeksdomein 2")]
            public OnderzoeksDomein OnderzoeksDomein2 { get; set; }

            [Display(Name = "Trefwoorden")]
            public string Trefwoorden { get; set; }

            [Display(Name = "Context")]
            public string Context { get; set; }

            [Display(Name = "Onderzoeksvraag")]
            public string Onderzoeksvraag { get; set; }

            [Display(Name = "Plan van aanpak")]
            public string PlanVanAanpak { get; set; }

            [Display(Name = "Referentielijst")]
            public string ReferentieLijst { get; set; }

            [Display(Name = "Voorstel is definitief?")]
            public bool IsDefinitief { get; set; }

            [Display(Name = "Feedback aanvaard?")]
            public bool IsAanvaard { get; set; }

            [Display(Name = "Status")]
            public string Status { get; set; }

            [Required(ErrorMessage = "*")]
            [Display(Name = "Vraag aan Bachelorproefcoördinator")]
            [DataType(DataType.MultilineText)]
            public string Vraag { get; set; }

            [Display(Name = "Antwoord op vraag promotor")]
            [DataType(DataType.MultilineText)]
            public string Antwoord { get; set; }
        }

        public class AdviesGevenModel
        {
            //---------- Alle details van voorstel ----------//
            [Display(Name = "Voornaam co-promotor")]
            public string Voornaamcp { get; set; }

            [Display(Name = "Naam co-promotor")]
            public string Naamcp { get; set; }

            [Display(Name = "Email co-promotor")]
            public string Emailcp { get; set; }

            [Display(Name = "Organisatie co-promotor")]
            public string Organisatiecp { get; set; }

            public int Id { get; set; }

            [Display(Name = "Titel bachelorproef")]
            public string Titel { get; set; }

            [Display(Name = "Onderzoeksdomein 1")]
            public OnderzoeksDomein OnderzoeksDomein1 { get; set; }

            [Display(Name = "Onderzoeksdomein 2")]
            public OnderzoeksDomein OnderzoeksDomein2 { get; set; }

            [Display(Name = "Trefwoorden")]
            public string Trefwoorden { get; set; }

            [Display(Name = "Context")]
            public string Context { get; set; }

            [Display(Name = "Onderzoeksvraag")]
            public string Onderzoeksvraag { get; set; }

            [Display(Name = "Plan van aanpak")]
            public string PlanVanAanpak { get; set; }

            [Display(Name = "Referentielijst")]
            public string ReferentieLijst { get; set; }

            [Display(Name = "Voorstel is definitief?")]
            public bool IsDefinitief { get; set; }

            [Display(Name = "Feedback aanvaard?")]
            public bool IsAanvaard { get; set; }

            [Display(Name = "Status")]
            public string Status { get; set; }

            [Required(ErrorMessage = "*")]
            [Display(Name = "Vraag aan Bachelorproefcoördinator")]
            [DataType(DataType.MultilineText)]
            public string Vraag { get; set; }

            [Required(ErrorMessage = "*")]
            [Display(Name = "Antwoord op vraag promotor")]
            [DataType(DataType.MultilineText)]
            public string Antwoord { get; set; }
        }
    
    
}
    
