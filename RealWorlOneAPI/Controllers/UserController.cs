using Microsoft.AspNetCore.Mvc;
using RealWorlOneAPI.Models;
using RealWorlOneAPI.Services;

namespace RealWorlOneAPI.Controllers {
    [BasicAuthorization]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository) {
            this.userRepository = userRepository;
        }

        // GET user/admin
        [HttpGet("{username}")]
        public IActionResult Get(string username) {
            if (string.IsNullOrEmpty(username)) {
                return BadRequest();
            }
            var user = userRepository.GetById(username);

            return Json(user);
        }

        // POST user
        [HttpPost]
        public IActionResult Post([FromBody] User value) {
            if (value == null) {
                return BadRequest();
            }
            var createdUser = userRepository.Add(value);

            return Json(createdUser);
        }

        // PUT user
        [HttpPut]
        public IActionResult Put([FromBody] User value) {
            if (value == null) {
                return BadRequest();
            }
            var note = userRepository.GetById(value.Username);

            if (note == null) {
                return NotFound();
            }

            value.Username = value.Username;
            userRepository.Update(value);

            return NoContent();
        }


        // DELETE user
        [HttpDelete]
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
