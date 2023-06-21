using AutoMapper;
using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Tickets;
using MediatR;

namespace Elkadeem.TicketManagement.Application.Features.Categories.Queries.GetCategoryDetailsQuery
{
    public class GetCategoryDetailsQueryHandler : IRequestHandler<GetCategoryDetailsQuery, CategoryDetailsItemModel>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryDetailsQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository
                ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CategoryDetailsItemModel> Handle(GetCategoryDetailsQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
            return _mapper.Map<CategoryDetailsItemModel>(category);
        }
    }
}
