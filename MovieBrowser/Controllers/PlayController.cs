using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieBrowser.Models;

namespace MovieBrowser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayController : ControllerBase
    {
        private readonly IMediator mediator;

        public PlayController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string title)
        {
            var settings = await mediator.Send(new SettingsQuery());
            string moviePath = Path.Combine(settings.MoviesFolderPath, title);

            var di = new DirectoryInfo(moviePath);
            var movieFile = di.GetFiles().FirstOrDefault(f => f.Extension == ".mp4" || f.Extension == ".m4v");

            if (movieFile != null && movieFile.Exists)
            {
                return File(System.IO.File.OpenRead(movieFile.FullName), "video/mp4");
            }

            return new BadRequestResult();
                        
        }
    }
}