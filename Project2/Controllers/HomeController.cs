using System.Web.Mvc;
using Project2.MySqlSecurity;


namespace Project2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MysqlRoleProvider roleProvider = new MysqlRoleProvider();
            ViewBag.Role = roleProvider.GetRolesForUser(HttpContext.User.Identity.Name)[0];

            if (roleProvider.GetRolesForUser(HttpContext.User.Identity.Name)[0] == "Student")
                return RedirectToAction("Index", "Student");
            if (roleProvider.GetRolesForUser(HttpContext.User.Identity.Name)[0] == "Promotor")
                return RedirectToAction("Index", "Promotor");
            if (roleProvider.GetRolesForUser(HttpContext.User.Identity.Name)[0] == "BpCoordinator")
                return RedirectToAction("Index", "BpCoordinator");

            return RedirectToAction("Login", "Account");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
