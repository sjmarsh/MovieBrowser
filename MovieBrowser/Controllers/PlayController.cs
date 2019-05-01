using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace MovieBrowser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string title)
        {
            string moviePath = @"c:\Movies\" + title; // TODO config

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