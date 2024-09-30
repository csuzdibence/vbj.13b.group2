using Microsoft.AspNetCore.Mvc;

namespace VBJ._13B.Group2.WebApp.Controllers
{
    /// <summary>
    /// MVC Controller -> Benne View is lehet html
    /// </summary>
    public class HomeController : Controller
    {
        // Get request a rootra -> localhost:valamiPort
        public IActionResult Index()
        {
            return View();
        }
        
        // Get request a Privacy nézetre -> localhost:valamiPort/Home/Privacy
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
