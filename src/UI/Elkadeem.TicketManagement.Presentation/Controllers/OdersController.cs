using Microsoft.AspNetCore.Mvc;

namespace Elkadeem.TicketManagement.Presentation.Controllers
{
    public class OdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
