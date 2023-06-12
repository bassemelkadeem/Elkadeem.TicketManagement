using MediatR;

namespace Elkadeem.TicketManagement.Application.Features.Categories.Commands.CreateCategoryCommand
{
    public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; } = string.Empty;
    }
}
