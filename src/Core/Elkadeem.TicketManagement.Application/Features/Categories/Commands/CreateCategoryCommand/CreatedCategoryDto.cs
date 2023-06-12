namespace Elkadeem.TicketManagement.Application.Features.Categories.Commands.CreateCategoryCommand
{
    public class CreatedCategoryDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
