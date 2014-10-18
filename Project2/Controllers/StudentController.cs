using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Project2.Models;
using Project2.Models.DAL;
using Project2.Models.Domain;
using Project2.MySqlSecurity;

namespace Project2.Controllers
{
    [FirstLoginAuth]
    public class StudentController : Controller
    {
        private IVoorstelRepository voorstelRepository;
        private IOnderzoeksdomeinRepository onderzoeksdomeinRepository;
        private IStudentRepository studentRepository;
        private AccountRepository accountRepository;

        public StudentController(IVoorstelRepository voorstelRepository, IOnderzoeksdomeinRepository onderzoeksdomeinRepository, IStudentRepository studentRepository, AccountRepository accountRepository)
        {
            this.voorstelRepository = voorstelRepository;
            this.onderzoeksdomeinRepository = onderzoeksdomeinRepository;
            this.studentRepository = studentRepository;
            this.accountRepository = accountRepository;
        }

        public ActionResult Index()
        {
            Voorstel voorstel = studentRepository.FindVoorstel(HttpContext.User.Identity.Name);
           
            return View(voorstel);
        }

        public ActionResult Create()
        {
            VoorstelIndienenModel model = new VoorstelIndienenModel();
            model.OnderzoeksDomeinen = onderzoeksdomeinRepository.FindAll().OrderBy(o => o.Naam).ToList();
            ViewBag.Message = "Voorstel maken.";
          

            return View(model);
        }

        [HttpPost]
        public ActionResult VoorstelIndienen(String action, VoorstelIndienenModel model)
        {
            if (ModelState.IsValid)
            {
                Voorstel voorstel = new Voorstel();
                
                Student s = studentRepository.FindBy(HttpContext.User.Identity.Name);
                if (!model.Voornaamcp.IsEmpty() && !model.Naamcp.IsEmpty() && !model.Organisatiecp.IsEmpty() &&
                    !model.Emailcp.IsEmpty())
                {
                    voorstel.VoornaamCP = model.Voornaamcp;
                    voorstel.NaamCP = model.Naamcp;
                    voorstel.OrganisatieCP = model.Organisatiecp;
                    voorstel.EmailCP = model.Emailcp;

                }



                voorstel.OnderzoeksDomein1 = onderzoeksdomeinRepository.FindBy(model.OnderzoeksDomein1.Id);
                voorstel.OnderzoeksDomein2 = onderzoeksdomeinRepository.FindBy(model.OnderzoeksDomein2.Id);

                voorstel.Titel = model.Titel;
                voorstel.Trefwoorden = model.Trefwoorden;
                voorstel.Context = model.Context;
                voorstel.Onderzoeksvraag = model.Onderzoeksvraag;
                voorstel.AanpaksPlan = model.PlanVanAanpak;
                voorstel.ReferentieLijst = model.ReferentieLijst;
                


                switch (action)
                {
                    case "Opslaan":
                        {
                            //isDefinitief blijft false
                            s.VoorstelIndienen(voorstel, false);
                            break;
                        }
                    case "Definitief Indienen":
                        {
                            s.VoorstelIndienen(voorstel, true);
                            break;
                        }
                }

                voorstel.IsDefinitief = model.IsDefinitief;
                if (model.IsDefinitief)
                    voorstel.toVoorstelInBehandelingState();

                voorstelRepository.Add(voorstel);
                voorstelRepository.SaveChanges();
                studentRepository.SaveChanges();
                
                return RedirectToAction("Index"); 
            }
            //Als modelstate niet valid is
            return RedirectToAction("Create");
        }

        public ActionResult Details()
        {
            Voorstel voorstel = studentRepository.FindVoorstel(HttpContext.User.Identity.Name);
            
            FeedbackModel model = new FeedbackModel();
            model.Titel = voorstel.Titel;
            model.Trefwoorden = voorstel.Trefwoorden;
            model.Context = voorstel.Context;
            model.OnderzoeksDomein1 = voorstel.OnderzoeksDomein1;
            model.OnderzoeksDomein2 = voorstel.OnderzoeksDomein2;
            model.Onderzoeksvraag = voorstel.Onderzoeksvraag;
            model.ReferentieLijst = voorstel.ReferentieLijst;
            model.PlanVanAanpak = voorstel.AanpaksPlan;
            model.Voornaamcp = voorstel.VoornaamCP;
            model.Naamcp = voorstel.NaamCP;
            model.Organisatiecp = voorstel.OrganisatieCP;
            model.Emailcp = voorstel.EmailCP;
            model.IsDefinitief = voorstel.IsDefinitief;
            model.IsAanvaard = voorstel.IsAanvaard;
            model.Status = voorstel.Status;
            if (voorstel.Feedback1 != null)
            {
                model.ScoreBijdrage = voorstel.Feedback1.ScoreBijdrage;
                model.ScoreContext = voorstel.Feedback1.ScoreContext;
                model.ScoreOnderwerp = voorstel.Feedback1.ScoreOnderwerp;
                model.ScoreOnderzoeksvraag = voorstel.Feedback1.ScoreOnderzoeksvraag;
                model.ScoreReferentielijst = voorstel.Feedback1.ScoreReferentielijst;
                model.ScoreSmart = voorstel.Feedback1.ScoreSmart;
                model.ScoreTitel = voorstel.Feedback1.ScoreTitel;
                model.Suggesties = voorstel.Feedback1.Suggesties;
            }
            
            return View(model);
        }

        public ActionResult Edit()
        {
            Voorstel voorstel = studentRepository.FindVoorstel(HttpContext.User.Identity.Name);
            ViewBag.OnderzoeksDomeinen = onderzoeksdomeinRepository.FindAll().OrderBy(o => o.Naam).ToList();
            VoorstelIndienenModel model = new VoorstelIndienenModel();
            model.Titel = voorstel.Titel;
            model.Trefwoorden = voorstel.Trefwoorden;
            model.Context = voorstel.Context;
            model.Onderzoeksvraag = voorstel.Onderzoeksvraag;
            model.ReferentieLijst = voorstel.ReferentieLijst;
            model.PlanVanAanpak = voorstel.AanpaksPlan;
            model.Voornaamcp = voorstel.VoornaamCP;
            model.Naamcp = voorstel.NaamCP;
            model.Organisatiecp = voorstel.OrganisatieCP;
            model.Emailcp = voorstel.EmailCP;
            model.IsDefinitief = voorstel.IsDefinitief;
            model.Status = voorstel.Status;
            return View(model);
        }

        [HttpPost]
        public ActionResult VoorstelAanvaard()
        {
            Voorstel voorstel = studentRepository.FindVoorstel(HttpContext.User.Identity.Name);
            studentRepository.FindBy(HttpContext.User.Identity.Name).AanvaardFeedback();

            voorstelRepository.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
