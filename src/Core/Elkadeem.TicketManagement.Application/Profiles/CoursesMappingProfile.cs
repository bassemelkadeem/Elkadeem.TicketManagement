using AutoMapper;
using Elkadeem.TicketManagement.Application.Extensions;
using Elkadeem.TicketManagement.Application.Features.Courses.Author.Commands.CreateAuthor;
using Elkadeem.TicketManagement.Application.Features.Courses.Author.Models;
using Elkadeem.TicketManagement.Application.Features.Courses.Course.Queries.GetCoursesListQuery;
using Elkadeem.TicketManagement.Domain.Courses;

namespace Elkadeem.TicketManagement.Application.Profiles
{
    public class CoursesMappingProfile : Profile
    {
        public CoursesMappingProfile()
        {
            CreateMap<Course, CourseListItemDto>();
            CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.Name, options =>
            {
                options.MapFrom(src => src.FirstName + " " + src.LastName);
            })
                .ForMember(dest => dest.Age, options =>
            {
                options.MapFrom(src => src.DateOfBirth.GetCurrentAge());
            });

            CreateMap<CreateAuthorCommand, Author>();

        }
    }
}
