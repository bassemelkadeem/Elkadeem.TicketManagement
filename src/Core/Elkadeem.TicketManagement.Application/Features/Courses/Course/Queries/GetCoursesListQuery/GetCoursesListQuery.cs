using MediatR;

namespace Elkadeem.TicketManagement.Application.Features.Courses.Course.Queries.GetCoursesListQuery
{
    public class GetCoursesListQuery : IRequest<List<CourseListItemDto>>
    {
    }
}
