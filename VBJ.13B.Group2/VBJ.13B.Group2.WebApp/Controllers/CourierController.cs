using Microsoft.AspNetCore.Mvc;

namespace VBJ._13B.Group2.WebApp.Controllers
{
    // [ApiController] -> attribútum

    /// <summary>
    /// API Controller -> benne nem lehet html
    /// 
    /// Ez a kontroller elérhető a localhost:valamiPort/api/Courier
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CourierController : ControllerBase
    {
        // api/Courier/Hello ->  Get Request
        [HttpGet]
        [Route(nameof(Hello))]
        public string Hello(string name)
        {
            return "Hello " + name; 
        }
    }
}
