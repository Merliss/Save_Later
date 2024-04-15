using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaveLater.Application.Functions.Events.Commands.CreateEvent;
using SaveLater.Application.Functions.Events.Commands.DeleteEvent;
using SaveLater.Application.Functions.Events.Commands.UpdateEvent;
using SaveLater.Application.Functions.Events.Queries.GetEvent;
using SaveLater.Application.Functions.Events.Queries.GetEventListByDate;

namespace SaveLater.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebinarController : Controller
    {
        private readonly IMediator _mediator;

        public WebinarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/geteventfordate", Name = "GetPagedEventsForDate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PageEventByDateViewModel>> GetPagedOrdersForMonth(SearchEventsOptions searchOptionsWebinars, int page, int pagesize, DateTime? date)
        {
            var getWebinarForMonthQuery = new GetEventsByDateQuery()
            { Date = date, Page = page, PageSize = pagesize, Options = searchOptionsWebinars };
            var pageWebinarsByDateViewModel = await _mediator.Send(getWebinarForMonthQuery);

            return Ok(pageWebinarsByDateViewModel);
        }


        [HttpPost(Name = "AddEvent")]
        public async Task<ActionResult<int>> Create([FromBody] CreateEventCommand createWebinarCommand)
        {
            var result = await _mediator.Send(createWebinarCommand);
            return Ok(result.Id);
        }

        [HttpGet("{id}", Name = "GetEvent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<EventViewModel>> GetWebinarById(int id)
        {
            var result = await _mediator.Send((new GetEventQuery() { Id = id }));
            return Ok(result);
        }

        [HttpPut(Name = "UpdateEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateEventCommand updatePostCommand)
        {
            await _mediator.Send(updatePostCommand);


            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deletepostCommand = new DeleteEventCommand() { Id = id };
            await _mediator.Send(deletepostCommand);
            return NoContent();
        }
    }
}
