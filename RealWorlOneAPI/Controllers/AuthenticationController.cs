using Microsoft.AspNetCore.Mvc;
using RealWorlOneAPI.Models;
using RealWorlOneAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealWorlOneAPI.Controllers {
    [BasicAuthorization]
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : Controller {
        private readonly IUserRepository userRepository;

        public AuthenticationController(IUserRepository userRepository) {
            this.userRepository = userRepository;
        }

        // POST authentication login
        [HttpPost("/login")]
        public IActionResult Post([FromBody] User value) {
            if (value == null) {
                return BadRequest();
            }
            var createdUser = userRepository.Add(value);

            return CreatedAtRoute("GetUser", new { username = createdUser.Username }, createdUser);
        }

        // POST authentication logout
        [HttpPost("/logout")]
        public IActionResult Put( [FromBody] User value) {
            if (value == null) {
                return BadRequest();
            }
            var note = userRepository.GetById(value.Username);

            if (note == null) {
                return NotFound();
            }

            userRepository.Update(value);

            return NoContent();
        }


        // DELETE user/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody] User value) {
            var user = userRepository.GetById(value.Username);
            if (user == null) {
                return NotFound();
            }
            userRepository.Delete(user);


            return NoContent();
        }
    }
}
