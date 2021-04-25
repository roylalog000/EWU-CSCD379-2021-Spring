using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.Business;
using SecretSanta.Data;

namespace SecretSanta.Api.Controllers
{
    //POCO
    //Plain Old C# Object

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository UserRepository { get; }

        public UsersController(IUserRepository userRepository)
        {
            UserRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        // /api/events
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return UserRepository.List();
        }

        // /api/events/<index>
        [HttpGet("{index}")]
        public ActionResult<User?> Get(int index)
        {
            if(index < 0)
            {
                return NotFound();
            }
            User? returnedUser = UserRepository.GetItem(index);
            return returnedUser;
        }

        //DELETE /api/users/<index>
        [HttpDelete("{index}")]
        public ActionResult Delete(int index)
        {
            if (index < 0)
            {
                return NotFound();
            }
            if (UserRepository.Remove(index))
            {
                return Ok();
            }
            return NotFound();
        }

        //POST /api/events
        [HttpPost]
        public ActionResult<User?> Post([FromBody]User? myUser)
        {
            if(myUser is null)
            {
                return BadRequest();
            }
            return UserRepository.Create(myUser);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id,[FromBody]User? updatedUser)
        {
            if(updatedUser is null)
            {
                return BadRequest();
            }
            User? foundUser = UserRepository.GetItem(id);
            if(foundUser is not null)
            {
                foundUser.FirstName = updatedUser.FirstName;
                foundUser.LastName = updatedUser.LastName;

                UserRepository.Save(foundUser);
                return Ok();
            }
            return NotFound();
        }
    }
}
