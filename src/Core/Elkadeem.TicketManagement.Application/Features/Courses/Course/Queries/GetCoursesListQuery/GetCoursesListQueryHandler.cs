using AutoMapper;
using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Courses;
using MediatR;

namespace Elkadeem.TicketManagement.Application.Features.Courses.Course.Queries.GetCoursesListQuery
{
    public class GetCoursesListQueryHandler : IRequestHandler<GetCoursesListQuery, List<CourseListItemDto>>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public GetCoursesListQueryHandler(
            ICourseRepository courseRepository,
            IMapper mapper)
        {
            _courseRepository = courseRepository
                ?? throw new ArgumentNullException(nameof(courseRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<CourseListItemDto>> Handle(GetCoursesListQuery request, CancellationToken cancellationToken)
        {
            var events = await _courseRepository.GetAllAsync();
            return _mapper.Map<List<CourseListItemDto>>(events);
        }
    }
}
