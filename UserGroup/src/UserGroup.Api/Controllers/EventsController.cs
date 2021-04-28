using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserGroup.Api.Dto;
using UserGroup.Business;
using UserGroup.Data;

namespace UserGroup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private IEventManager EventManager { get; }

        public EventsController(IEventManager eventManager)
        {
            EventManager = eventManager ?? throw new ArgumentNullException(nameof(eventManager));
        }

        // /api/events
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return EventManager.List();
        }

        // /api/events/<index>
        [HttpGet("{id}")]
        public ActionResult<Event?> Get(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }
            Event? returnedEvent = EventManager.GetItem(id);
            return returnedEvent;
        }

        //DELETE /api/events/<index>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Delete(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }
            if (EventManager.Remove(id))
            {
                return Ok();
            }
            return NotFound();
        }

        // POST /api/events
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Event), StatusCodes.Status200OK)]
        public ActionResult<Event?> Post([FromBody] Event? myEvent)
        {
            if (myEvent is null)
            {
                return BadRequest();
            }
            return EventManager.Create(myEvent);
        }

        // PUT /api/events/<id>
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]UpdateEvent? updatedEvent)
        {
            if (updatedEvent is null)
            {
                return BadRequest();
            }
            Event? foundEvent = EventManager.GetItem(id);
            if (foundEvent is not null)
            {
                if (!string.IsNullOrWhiteSpace(updatedEvent.Name))
                {
                    foundEvent.Name = updatedEvent.Name;
                }

                EventManager.Save(foundEvent);
                return Ok();
            }
            return NotFound();
        }
    }
}
