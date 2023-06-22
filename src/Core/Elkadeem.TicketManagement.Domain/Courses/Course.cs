namespace Elkadeem.TicketManagement.Domain.Courses
{
    public class Course
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public Author Author { get; set; } = default!;

        public Guid AuthorId { get; set; }

        public Course(string title)
        {
            Title = title;
        }
    }
}
