using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.Data;
using SecretSanta.Api.Dto;

namespace SecretSanta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository Repository { get; }

        public UsersController(IUserRepository repository)
        {
            Repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return Repository.List();
        }

        [HttpGet("{id}")]
        public ActionResult<User?> Get(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }
            User? user = Repository.GetItem(id);
            if (user is null) return NotFound();
            return user;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Delete(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }
            if (Repository.Remove(id))
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        public ActionResult<User?> Post([FromBody] User? myUser)
        {
            if (myUser is null)
            {
                return BadRequest();
            }
            return Repository.Create(myUser);
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]UpdatedUser? updatedEvent)
        {
            if (updatedEvent is null)
            {
                return BadRequest();
            }
            User? foundEvent = Repository.GetItem(id);
            if (foundEvent is not null)
            {
                if (!string.IsNullOrWhiteSpace(updatedEvent.FirstName))
                {
                    foundEvent.FirstName = updatedEvent.FirstName;
                }

                Repository.Save(foundEvent);
                return Ok();
            }
            return NotFound();
        }
    }
}
    
    

