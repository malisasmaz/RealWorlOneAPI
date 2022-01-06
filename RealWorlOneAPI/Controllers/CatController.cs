using Microsoft.AspNetCore.Mvc;
using RealWorlOneAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        /// <param name="rotation"></param>
        /// <response code="401">Unauthorized user</response> 
        [HttpGet("{rotation}")]
        public IActionResult Get(int rotation) {

            return File(cat.GetByRotate(rotation), "image/jpeg");
        }
    }
}
