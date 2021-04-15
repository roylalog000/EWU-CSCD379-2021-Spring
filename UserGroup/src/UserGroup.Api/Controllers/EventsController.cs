using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace UserGroup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        // /api/events
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return DeleteMe.Events;
        }

        // /api/events/<index>
        [HttpGet("{index}")]
        public string Get(int index)
        {
            return DeleteMe.Events[index];
        }

        //DELETE /api/events/<index>
        [HttpDelete("{index}")]
        public void Delete(int index)
        {
            DeleteMe.Events.RemoveAt(index);
        }

        // POST /api/events
        [HttpPost]
        public void Post([FromBody] string eventName)
        {
            DeleteMe.Events.Add(eventName);
        }
    }
}
