using Microsoft.AspNetCore.Mvc;

namespace Elkadeem.TicketManagement.Presentation.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
