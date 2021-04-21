using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UserGroup.Business;
using UserGroup.Data;

namespace UserGroup.Api.Controllers
{
    //POCO
    //Plain Old C# Object
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
        public Event? Get(int id)
        {
            return EventManager.GetItem(id);
        }

        //DELETE /api/events/<index>
        [HttpDelete("{index}")]
        public ActionResult Delete(int index)
        {
            if (index < 0)
            {
                return NotFound();
            }
            DeleteMe.Events.RemoveAt(index);
            return Ok();
        }

        // POST /api/events
        [HttpPost]
        public void Post([FromBody] Event myEvent)
        {
            Console.WriteLine(myEvent.Name);
            Console.WriteLine(myEvent.Id);
            //DeleteMe.Events.Add(eventName);
        }

        // PUT /api/events/<index>
        [HttpPut("{index}")]
        public void Put(int index, [FromBody]string eventName)
        {
            //DeleteMe.Events[index] = eventName; 
        }
    }
}
