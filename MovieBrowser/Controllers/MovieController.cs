using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieBrowser.Models;
using System.Threading.Tasks;

namespace MovieBrowser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator mediator;

        public MovieController(IMediator mediator)
        {
            this.mediator = mediator;
        }
                       
        public async Task<IActionResult> Get([FromQuery]MovieQuery command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}