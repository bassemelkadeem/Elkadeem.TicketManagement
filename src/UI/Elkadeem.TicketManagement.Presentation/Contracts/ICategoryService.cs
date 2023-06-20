using Elkadeem.TicketManagement.Presentation.Services.Base;
using Elkadeem.TicketManagement.Presentation.ViewModels;

namespace Elkadeem.TicketManagement.Presentation.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllCategories();

        Task<IEnumerable<CategoryWithEventsViewModel>> GetCategoryWithEvents(bool includeHistory = false);

        Task<CreateCategoryCommandResponse> AddCategory(CreateCategoryViewModel model);
    }
}
