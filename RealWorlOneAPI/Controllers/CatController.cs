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

        // GET cat
        [HttpGet]
        public IActionResult Get() {

            return File(cat.Get(), "image/jpeg");
        }
    }
}
