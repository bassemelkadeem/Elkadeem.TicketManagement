using AutoMapper;
using Elkadeem.TicketManagement.Application.Interfaces.Persistence;
using MediatR;

namespace Elkadeem.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListQuery
{
    public class GetCategoriesListQueryHandler
        : IRequestHandler<GetCategoriesListQuery, List<CategoryItemModel>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesListQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository
                ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<CategoryItemModel>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var allCategories = (await _categoryRepository.GetAllAsync()).OrderBy(c => c.Name);
            return _mapper.Map<List<CategoryItemModel>>(allCategories);
        }
    }
}
