﻿namespace Elkadeem.TicketManagement.Domain.Courses
{
    public class Author
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTimeOffset DateOfBirth { get; set; }

        public string MainCategory { get; set; }

        public ICollection<Course> Courses { get; set; }
            = new List<Course>();

        public Author(string firstName, string lastName, string mainCategory)
        {
            FirstName = firstName;
            LastName = lastName;
            MainCategory = mainCategory;
        }
    }
}
