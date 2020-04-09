using Microsoft.AspNetCore.Mvc;

namespace ITFriends.Panda.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CustomView()
        {
            return View("TestView");
        }
    }
}