using Microsoft.AspNetCore.Mvc;

namespace VBJ._13B.Group2.WebApp.Controllers
{
    public class HelloController : Controller
    {
        // /Hello -> ami a feladatban volt
        public IActionResult Index()
        {
            ViewBag.Message = "Hello world";
            return View();
        }
    }
}
