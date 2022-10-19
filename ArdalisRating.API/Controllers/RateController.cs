using ArdalisRating.Application.Handlers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArdalisRating.API.Controllers
{
    [Route("api/Rate")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly IRatingEngine ratingEngine;

        public RateController(IRatingEngine ratingEngine)
        {
            this.ratingEngine = ratingEngine;
        }

        [HttpPost]
        public IActionResult Post_Rate([FromBody] string body)
        {
            ratingEngine.Rate(text: body);

            return Ok(ratingEngine.Rating);
        }
    }
}