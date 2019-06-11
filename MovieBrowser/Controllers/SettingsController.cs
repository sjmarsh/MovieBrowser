using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieBrowser.Models;
using System.Threading.Tasks;

namespace MovieBrowser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly IMediator mediator;

        public SettingsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await mediator.Send(new SettingsQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Settings settings)
        {
            var result = await mediator.Send(new SettingsCommand { Settings = settings });
            return result ? Ok(result) : (IActionResult)BadRequest();
        }
    }
}
