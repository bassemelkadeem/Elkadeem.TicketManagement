using Elkadeem.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using Elkadeem.TicketManagement.Application.Features.Events.Commands.RemoveEvent;
using Elkadeem.TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using Elkadeem.TicketManagement.Application.Features.Events.Queries.GetEventDetailQuery;
using Elkadeem.TicketManagement.Application.Features.Events.Queries.GetEventsListQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Elkadeem.TicketManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator
                ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet(Name = "GetAllEvents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<EventListItemModel>>> GetAllEvents()
        {
            var result = await _mediator.Send(new GetEventsListQuery());
            return Ok(result);
        }


        [HttpGet("{id}", Name = "GetEventById")]
        public async Task<ActionResult<EventDetailModel>> GetEventById(Guid id)
        {
            var getEventDetailQuery = new GetEventDetailQuery() { EventId = id };
            var result = await _mediator.Send(getEventDetailQuery);
            return Ok(result);
        }

        [HttpPost(Name = "AddEvent")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEventCommand createEventCommand)
        {
            var id = await _mediator.Send(createEventCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateEventCommand updateEventCommand)
        {
            await _mediator.Send(updateEventCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteEventCommand = new RemoveEventCommand() { EventId = id };
            await _mediator.Send(deleteEventCommand);
            return NoContent();
        }
    }
}
