using Elkadeem.TicketManagement.Application.Features.Courses.Author.Models;
using MediatR;

namespace Elkadeem.TicketManagement.Application.Features.Courses.Author.Queries.GetAuthorsListQuery
{
    public class GetAuthorsListQuery : IRequest<List<AuthorDto>>
    {
    }
}
