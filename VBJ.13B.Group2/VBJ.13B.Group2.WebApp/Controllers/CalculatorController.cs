using Microsoft.AspNetCore.Mvc;

namespace VBJ._13B.Group2.WebApp.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(int number1, int number2)
        {
            int sum = number1 + number2;
            ViewBag.Result = "Az összeadott számok összege: " + sum;
            return View("Index");
        }
    }
}
