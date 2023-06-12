using MediatR;

namespace Elkadeem.TicketManagement.Application.Features.Categories.Queries.GetCategoryDetailsQuery
{
    public class GetCategoryDetailsQuery : IRequest<CategoryDetailsItemModel>
    {
        public Guid CategoryId { get; set; }
    }
}
