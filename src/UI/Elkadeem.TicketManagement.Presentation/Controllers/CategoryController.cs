using Elkadeem.TicketManagement.Presentation.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Elkadeem.TicketManagement.Presentation.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        public async Task<IActionResult> Index(bool includeHistory = false)
        {
            var categories = await categoryService.GetCategoryWithEvents(includeHistory);
            return View(categories);
        }
    }
}
