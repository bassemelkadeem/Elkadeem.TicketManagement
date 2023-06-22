using Elkadeem.TicketManagement.Application.Features.Courses.Author.Commands.CreateAuthor;
using Elkadeem.TicketManagement.Application.Features.Courses.Author.Models;
using Elkadeem.TicketManagement.Application.Features.Courses.Author.Queries.GetAuthorByIdQuery;
using Elkadeem.TicketManagement.Application.Features.Courses.Author.Queries.GetAuthorsListQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Elkadeem.CourseLibraryAPI.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ILogger<AuthorController> _logger;

        public AuthorController(
            ISender sender,
            ILogger<AuthorController> logger)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorDto>>> GetAuthors()
        {
            _logger.LogInformation("Start getting all authors");
            var authors = await _sender.Send(new GetAuthorsListQuery());
            _logger.LogInformation($"Authors count is {authors.Count}");
            return Ok(authors);
        }

        [HttpGet("{id:guid}", Name = "GetAuthor")]
        public async Task<ActionResult<AuthorDto>> GetAuthor(Guid id)
        {
            _logger.LogInformation($"Start getting author with id {id}");
            var author = await _sender.Send(new GetAuthorByIdQuery() { AuthorId = id });
            if (author == null)
                return NotFound();

            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDto>> CreateNewAuthor([FromBody] CreateAuthorCommand request)
        {
            var createdAuthor = await _sender.Send(request);
            return CreatedAtRoute(
                "GetAuthor",
                new { id = createdAuthor.Id },
                createdAuthor);
        }
    }
}
