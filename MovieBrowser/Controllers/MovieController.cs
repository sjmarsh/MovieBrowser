using Microsoft.AspNetCore.Mvc;
using MovieBrowser.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.Collections.Generic;
using System.IO;

namespace MovieBrowser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
     
        public IActionResult Get()
        {
            var result = GetMovies();

            return  Ok(result);
        }

        private List<Movie> GetMovies()
        {
            var movies = new List<Movie>();

            var di = new DirectoryInfo(@"C:\Movies");  // TODO config this.
            var directories = di.GetDirectories();

            foreach (var dir in directories)
            {
                var movie = new Movie {
                    Title = dir.Name,
                    Path = dir.FullName
                };
                using (var img = Image.Load(dir.FullName + "\\folder.jpg"))
                {
                    img.Mutate(x => x.Resize(160, 240));
                    movie.CoverArt = img.ToBase64String(ImageFormats.Jpeg);
                    movies.Add(movie);
                }
            }
            
            return movies;
         }
    }
}