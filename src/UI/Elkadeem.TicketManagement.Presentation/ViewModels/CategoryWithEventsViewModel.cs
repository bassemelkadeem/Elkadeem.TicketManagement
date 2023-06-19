namespace Elkadeem.TicketManagement.Presentation.ViewModels
{
    public class CategoryWithEventsViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<EventNestedViewModel> Events { get; set; } = new List<EventNestedViewModel>();
    }
}
