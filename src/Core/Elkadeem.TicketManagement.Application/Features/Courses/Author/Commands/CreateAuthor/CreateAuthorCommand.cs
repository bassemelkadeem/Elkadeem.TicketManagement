using Elkadeem.TicketManagement.Application.Features.Courses.Author.Models;
using MediatR;

namespace Elkadeem.TicketManagement.Application.Features.Courses.Author.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<AuthorDto>
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public DateTimeOffset DateOfBirth { get; set; }

        public required string MainCategory { get; set; }
    }
}
