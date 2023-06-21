using AutoMapper;
using Elkadeem.TicketManagement.Application.Features.Courses.Course.Queries.GetCoursesListQuery;
using Elkadeem.TicketManagement.Domain.Courses;

namespace Elkadeem.TicketManagement.Application.Profiles
{
    public class CoursesMappingProfile : Profile
    {
        public CoursesMappingProfile()
        {
            CreateMap<Course, CourseListItemDto>();

        }
    }
}
