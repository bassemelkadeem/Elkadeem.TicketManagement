using AutoMapper;
using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Tickets;
using MediatR;

namespace Elkadeem.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEventsQuery
{
    public class GetCategoriesListWithEventsQueryHandler : IRequestHandler<GetCategoriesListWithEventsQuery, List<CategoryItemWithEventsModel>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesListWithEventsQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository
                ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<CategoryItemWithEventsModel>> Handle(GetCategoriesListWithEventsQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllCategoriesWithEventsAsync(request.IncludeHistory);
            return _mapper.Map<List<CategoryItemWithEventsModel>>(categories);
        }
    }
}
