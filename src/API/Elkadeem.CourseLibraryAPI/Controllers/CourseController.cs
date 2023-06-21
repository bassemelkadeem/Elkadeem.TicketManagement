using Elkadeem.TicketManagement.Application.Features.Courses.Course.Queries.GetCoursesListQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Elkadeem.CourseLibraryAPI.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CourseController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ILogger<CourseController> _logger;

        public CourseController(
            ISender sender,
            ILogger<CourseController> logger)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult> GetCourses()
        {
            _logger.LogInformation("Start getting courses list");
            var events = await _sender.Send(new GetCoursesListQuery());
            _logger.LogInformation($"Courses count is {events.Count}");
            return Ok(events);
        }
    }
}