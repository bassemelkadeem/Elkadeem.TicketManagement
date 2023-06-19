using Microsoft.AspNetCore.Mvc;

namespace Elkadeem.TicketManagement.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
