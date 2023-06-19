using AutoMapper;
using Elkadeem.TicketManagement.Presentation.Contracts;
using Elkadeem.TicketManagement.Presentation.Services.Base;
using Elkadeem.TicketManagement.Presentation.ViewModels;

namespace Elkadeem.TicketManagement.Presentation.Services
{
    public class CategoryService : BaseDataService, ICategoryService
    {
        private readonly IMapper mapper;

        public CategoryService(IClient client,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
            : base(client, httpContextAccessor)
        {
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategories()
        {
            var allCategories = await _client.GetAllCategoriesAsync();
            var mappedCategories = mapper.Map<List<CategoryViewModel>>(allCategories);
            return mappedCategories;
        }

        public async Task<IEnumerable<CategoryWithEventsViewModel>> GetCategoryWithEvents(bool includeHistory = false)
        {
            var allCategoriesWithEvents = await _client.GetAllCategoriesWithEventAsync(includeHistory);
            var mappedCategoriesWithEvents = mapper.Map<List<CategoryWithEventsViewModel>>(allCategoriesWithEvents);
            return mappedCategoriesWithEvents;
        }
    }
}
