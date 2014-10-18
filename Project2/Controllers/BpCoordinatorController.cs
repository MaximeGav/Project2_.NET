using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using Project2.Models;
using Project2.Models.DAL;
using Project2.Models.Domain;

namespace Project2.Controllers
{
    public class BpCoordinatorController : Controller
    {
        private IVoorstelRepository voorstelRepository;
        private IPromotorRepository promotorRepository;
        private IStudentRepository studentRepository;
        private AccountRepository accountRepository;
        private IOnderzoeksdomeinRepository onderzoeksdomeinRepository;

        public BpCoordinatorController(IVoorstelRepository voorstelRepository, IOnderzoeksdomeinRepository onderzoeksdomeinRepository, IPromotorRepository promotorRepository, IStudentRepository studentRepository, AccountRepository accountRepository)
        {
            this.voorstelRepository = voorstelRepository;
            this.promotorRepository = promotorRepository;
            this.studentRepository = studentRepository;
            this.accountRepository = accountRepository;
            this.onderzoeksdomeinRepository = onderzoeksdomeinRepository;
        }

        public ActionResult Index()
        {
            List<Voorstel> voorstellen = new List<Voorstel>();
            List<Student> studenten = new List<Student>();
            List<Promotor> promotoren = new List<Promotor>();
            foreach (var student in studentRepository.FindAll())
            {
                if (student.Voorstel != null && student.Voorstel.IsDefinitief)
                {
                    voorstellen.Add(student.Voorstel);
                    studenten.Add(student);
                    promotoren.Add(student.Promotor);
                }

            }
            ViewBag.studenten = studenten;
            ViewBag.promotoren = promotoren;
            return View(voorstellen);
        }

        public ActionResult Details(int id)
        {
            Voorstel voorstel = voorstelRepository.FindBy(id);
            AdviesVragenModel model = new AdviesVragenModel();
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
            model.Vraag = voorstel.Advies.Vraag;
            model.Antwoord = voorstel.Advies.Antwoord;

            return View(model);
        }

        public ActionResult Advies()
        {
            List<Voorstel> voorstellen = new List<Voorstel>();
            List<Student> studenten = new List<Student>();
            List<Promotor> promotoren = new List<Promotor>();
            foreach (var student in studentRepository.FindAll())
            {
                if (student.Voorstel != null && student.Voorstel.IsDefinitief && student.Voorstel.Status == "Advies BPC")
                {
                    voorstellen.Add(student.Voorstel);
                    studenten.Add(student);
                    promotoren.Add(student.Promotor);
                }

            }
            ViewBag.studenten = studenten;
            ViewBag.promotoren = promotoren;
            return View(voorstellen);
        }

        public ActionResult Antwoord(int id)
        {
            Voorstel voorstel = voorstelRepository.FindBy(id);
            AdviesGevenModel model = new AdviesGevenModel();
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
            model.Vraag = voorstel.Advies.Vraag;

            return View(model);
        }

        [HttpPost]
        public ActionResult Antwoord(int id, AdviesGevenModel model)
        {
            if (ModelState.IsValid)
            {
                Voorstel voorstel = voorstelRepository.FindBy(id);
                voorstel.toVoorstelInBehandelingState();
                Advies advies = voorstel.Advies;
                advies.Antwoord = model.Antwoord;

                voorstelRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            //Als modelstate niet valid is*/
            return RedirectToAction("Index");
        }

    }
}
