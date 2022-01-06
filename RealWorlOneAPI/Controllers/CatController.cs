using Microsoft.AspNetCore.Mvc;
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

        // GET cat
        [HttpGet]
        public IActionResult Get() {

            return File(cat.Get(), "image/jpeg");
        }

        // GET /rotation
        [HttpGet("{rotation}")]
        public IActionResult Get(int rotation) {

            return File(cat.GetByRotate(rotation), "image/jpeg");
        }
    }
}
