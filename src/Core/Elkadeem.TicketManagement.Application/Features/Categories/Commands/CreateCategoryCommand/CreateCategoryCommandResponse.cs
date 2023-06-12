using Elkadeem.TicketManagement.Application.Responses;

namespace Elkadeem.TicketManagement.Application.Features.Categories.Commands.CreateCategoryCommand
{
    public class CreateCategoryCommandResponse : BaseResponse
    {
        public CreatedCategoryDto CreatedCategoryDto { get; set; } = default!;
    }
}
