using Elkadeem.TicketManagement.Application.Features.Courses.Author.Models;
using MediatR;

namespace Elkadeem.TicketManagement.Application.Features.Courses.Author.Queries.GetAuthorByIdQuery
{
    public class GetAuthorByIdQuery : IRequest<AuthorDto>
    {
        public Guid AuthorId { get; set; }
    }
}
