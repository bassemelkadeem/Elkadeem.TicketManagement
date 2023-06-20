using Elkadeem.TicketManagement.Presentation.Contracts;
using Elkadeem.TicketManagement.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Elkadeem.TicketManagement.Presentation.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        public async Task<IActionResult> Index(bool includeHistory = false)
        {
            var categories = await _categoryService.GetCategoryWithEvents(includeHistory);
            return View(categories);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _categoryService.AddCategory(model);
                if (response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["Errors"] = response.ValidationErrors;
                }
            }

            return View(model);
        }
    }
}
