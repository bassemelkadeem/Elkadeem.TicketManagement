using MediatR;

namespace Elkadeem.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListQuery
{
    public class GetCategoriesListQuery : IRequest<List<CategoryItemModel>>
    {
    }
}
