using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using System.Windows.Forms;
using Project2.Models;
using Project2.Models.DAL;
using Project2.Models.Domain;
using Project2.MySqlSecurity;
using FormCollection = System.Web.Mvc.FormCollection;

namespace Project2.Controllers
{
    [FirstLoginAuth]
    public class PromotorController : Controller
    {
        private IVoorstelRepository voorstelRepository;
        private IPromotorRepository promotorRepository;
        private IStudentRepository studentRepository;
        private AccountRepository accountRepository;

        public PromotorController(IVoorstelRepository voorstelRepository, IPromotorRepository promotorRepository, IStudentRepository studentRepository, AccountRepository accountRepository)
        {
            this.voorstelRepository = voorstelRepository;
            this.promotorRepository = promotorRepository;
            this.studentRepository = studentRepository;
            this.accountRepository = accountRepository;
        }

        public ActionResult Index()
        {
            List<Voorstel> voorstellen = new List<Voorstel>();
            Promotor p = promotorRepository.FindBy(HttpContext.User.Identity.Name);
            List<Student> studenten = new List<Student>();
            foreach (var student in studentRepository.FindAll())
            {
                if (student.Promotor == p && (student.Voorstel != null) && student.Voorstel.IsDefinitief)
                { 
                    voorstellen.Add(student.Voorstel);
                    studenten.Add(student);
                }

            }
            ViewBag.studenten = studenten;
            return View(voorstellen);
        }

        public ActionResult Details(int id)
        {
            Voorstel voorstel = voorstelRepository.FindBy(id);
            
            FeedbackModel model = new FeedbackModel();
            model.Titel = voorstel.Titel;
            model.Id = voorstel.id;
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
            model.Status = voorstel.Status;
            if (voorstel.Feedback1 != null)
            {
                model.ScoreTitel = voorstel.Feedback1.ScoreTitel;
                model.ScoreContext = voorstel.Feedback1.ScoreContext;
                model.ScoreSmart = voorstel.Feedback1.ScoreSmart;
                model.ScoreOnderzoeksvraag = voorstel.Feedback1.ScoreOnderzoeksvraag;
                model.ScoreBijdrage = voorstel.Feedback1.ScoreBijdrage;
                model.ScoreOnderwerp = voorstel.Feedback1.ScoreOnderwerp;
                model.ScoreReferentielijst = voorstel.Feedback1.ScoreReferentielijst;
                model.Suggesties = voorstel.Feedback1.Suggesties;
            }

            return View(model);
        }

        public ActionResult Feedback(int id)
        {
            Voorstel voorstel = voorstelRepository.FindBy(id);
            FeedbackModel model = new FeedbackModel();
            model.Titel = voorstel.Titel;
            model.OnderzoeksDomein1 = voorstel.OnderzoeksDomein1;
            model.OnderzoeksDomein2 = voorstel.OnderzoeksDomein2;
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
            if (voorstel.Feedback1 != null)
            {
                model.ScoreTitel = voorstel.Feedback1.ScoreTitel;
                model.ScoreContext = voorstel.Feedback1.ScoreContext;
                model.ScoreSmart = voorstel.Feedback1.ScoreSmart;
                model.ScoreOnderzoeksvraag = voorstel.Feedback1.ScoreOnderzoeksvraag;
                model.ScoreBijdrage = voorstel.Feedback1.ScoreBijdrage;
                model.ScoreOnderwerp = voorstel.Feedback1.ScoreOnderwerp;
                model.ScoreReferentielijst = voorstel.Feedback1.ScoreReferentielijst;
                model.Suggesties = voorstel.Feedback1.Suggesties;
            }
          
            return View(model);
        }

        [HttpPost]
        public ActionResult Feedback(int id, FeedbackModel model)
        {
            if (ModelState.IsValid)
            {
                Promotor p = promotorRepository.FindBy(HttpContext.User.Identity.Name);
                Voorstel voorstel = voorstelRepository.FindBy(id);
                Student s = studentRepository.FindBy(voorstel);
                Feedback feedback = new Feedback();

                feedback.ScoreTitel = model.ScoreTitel;
                feedback.ScoreContext = model.ScoreContext;
                feedback.ScoreSmart = model.ScoreSmart;
                feedback.ScoreOnderzoeksvraag = model.ScoreOnderzoeksvraag;
                feedback.ScoreBijdrage = model.ScoreBijdrage;
                feedback.ScoreOnderwerp = model.ScoreOnderwerp;
                feedback.ScoreReferentielijst = model.ScoreReferentielijst;
                feedback.Suggesties = model.Suggesties;

                if (Request.Form["button"] != null)
                {
                    string selectedStatus = Request.Form["button"];
                    switch (selectedStatus)
                    {
                        case "Opslaan":
                            voorstel.toVoorstelInBehandelingState();
                            voorstel.Feedback1 = feedback;
                            break;
                        case "Goedkeuren":
                            if (model.Suggesties.IsEmpty())
                            {
                                s.VoorstelGoedkeuren(voorstel);
                            }
                            else
                            {
                                feedback.Suggesties = model.Suggesties;
                                s.VoorstelGoedkeurenMetOpmerkingen(voorstel);
                            }
                            feedback.IsDefinitief = true;
                            voorstel.Feedback1 = feedback;
                            break;
                        case "Advies vragen":
                            return RedirectToAction("Advies", new { id = voorstel.id });
                            break;
                        case "Afkeuren":
                            s.VoorstelAfkeuren();
                            studentRepository.SaveChanges();
                            voorstelRepository.Delete(voorstel);
                            break;
                    }
                }

                

                
                voorstelRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            //Als modelstate niet valid is
            return RedirectToAction("Feedback");
        }

        public ActionResult Advies(int id)
        {
            Voorstel voorstel = voorstelRepository.FindBy(id);
            AdviesVragenModel model = new AdviesVragenModel();
            model.Titel = voorstel.Titel;
            model.OnderzoeksDomein1 = voorstel.OnderzoeksDomein1;
            model.OnderzoeksDomein2 = voorstel.OnderzoeksDomein2;
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
        public ActionResult Advies(int id, AdviesVragenModel model)
        {
            if (ModelState.IsValid)
            {
                Voorstel voorstel = voorstelRepository.FindBy(id);
                voorstel.geefVraagAdvies(model.Vraag);
                voorstelRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
