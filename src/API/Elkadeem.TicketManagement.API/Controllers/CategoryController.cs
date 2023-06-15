using Elkadeem.TicketManagement.Application.Features.Categories.Commands.CreateCategoryCommand;
using Elkadeem.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListQuery;
using Elkadeem.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEventsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Elkadeem.TicketManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator 
                ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("all", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryItemModel>>> GetAllCategories()
        {
            var dtos = await _mediator.Send(new GetCategoriesListQuery());
            return Ok(dtos);
        }

        [HttpGet("allwithevents", Name = "GetAllCategoriesWithEvent")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryItemWithEventsModel>>> GetAllCategoriesWithEvent(bool includeHistory = false)
        {
            var query = new GetCategoriesListWithEventsQuery { IncludeHistory = includeHistory };
            var dtos = await _mediator.Send(query);
            return Ok(dtos);
        }

        [HttpPost("addnewcategory", Name = "CreateNewCategory")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CreateCategoryCommandResponse>> CreateNewCategory([FromBody]CreateCategoryCommand createCategoryCommand)
        {
            var response = await _mediator.Send(createCategoryCommand);
            return Ok(response);
        }
    }
}
