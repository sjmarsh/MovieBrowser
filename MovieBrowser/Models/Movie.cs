using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace MovieBrowser.Models
{
    public class MovieCommand : IRequest<List<MovieCommandResult>>
    {
    }

    public class MovieCommandHandler : IRequestHandler<MovieCommand, List<MovieCommandResult>>
    {
        public async Task<List<MovieCommandResult>> Handle(MovieCommand request, CancellationToken cancellationToken)
        {
            var movies = new List<MovieCommandResult>();

            var di = new DirectoryInfo(@"C:\Movies");  // TODO config this.
            var directories = di.GetDirectories();

            foreach (var dir in directories)
            {
                var movie = new MovieCommandResult
                {
                    Title = dir.Name,
                    Path = dir.FullName
                };
                using (var img = await Task.Run(() => Image.Load(dir.FullName + "\\folder.jpg")))
                {
                    img.Mutate(x => x.Resize(160, 240));
                    movie.CoverArt = img.ToBase64String(ImageFormats.Jpeg);
                    movies.Add(movie);
                }
            }

            return movies;
        }
    }

    public class MovieCommandResult
    {
        public string Title { get; set; }

        public string Path { get; set; }

        public string CoverArt { get; set; }
    }
}
