using Microsoft.AspNetCore.Mvc;
using RealWorlOneAPI.Models;
using RealWorlOneAPI.Services;

namespace RealWorlOneAPI.Controllers {
    [BasicAuthorization]
    [ApiController]
    [Route("api/[controller]")]
    public class CatController : Controller {

        private readonly ICat cat;

        public CatController(ICat cat) {
            this.cat = cat;
        }

        /// <summary>
        /// Get upside down cat image
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/Cat
        ///
        /// </remarks>
        /// <returns>image/jpeg</returns>
        /// <response code="401">Unauthorized user</response> 
        [HttpGet]
        public IActionResult Get() {

            return File(cat.Get(), "image/jpeg");
        }

        /// <summary>
        /// Get rotated cat image with rotation value
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/Cat/{rotation}
        ///     {
        ///        "rotation": 90
        ///     }
        ///
        /// </remarks>
        /// <param name="rotation">Rotate options 0-90-180-270</param>
        /// <response code="401">Unauthorized user</response> 
        [HttpGet("{rotation}")]
        public IActionResult Get(Rotate rotation) {

            return File(cat.GetByRotate(rotation), "image/jpeg");
        }
    }
}
