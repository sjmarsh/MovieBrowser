using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Processing;
using MovieBrowser.Models;

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

            var di = new DirectoryInfo(@"C:\Movies");
            var directories = di.GetDirectories();

            foreach (var dir in directories)
            {
                var movie = new Movie {
                    Title = dir.Name,
                    Path = dir.FullName
                };
                using (var img = Image.Load(dir.FullName + "\\folder.jpg"))
                {
                    img.Mutate(x => x.Resize(140, 200));
                    //img.Save("thumb.jpg");
                    movie.CoverArt = img.ToBase64String(ImageFormats.Jpeg);
                    movies.Add(movie);
                }
            }
            
            return movies;
         }
    }
}