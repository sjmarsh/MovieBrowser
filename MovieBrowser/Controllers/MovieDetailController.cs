using Microsoft.AspNetCore.Mvc;
using MovieBrowser.Models;
using System.Threading.Tasks;
using MediatR;

namespace MovieBrowser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieDetailController : ControllerBase
    {
        private readonly IMediator mediator;

        public MovieDetailController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Get(string title)
        {
            var result = await mediator.Send(new MovieDetailQuery { Title = title});
            return Ok(result);
        }
    }
}