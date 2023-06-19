using Microsoft.AspNetCore.Mvc;

namespace Elkadeem.TicketManagement.Presentation.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
