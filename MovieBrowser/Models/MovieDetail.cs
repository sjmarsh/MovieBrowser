using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AutoMapper;
using MediatR;

namespace MovieBrowser.Models
{
    public class MovieDetailQuery : IRequest<MovieDetailQueryResult>
    {
        [Required]
        public string Title { get; set; }
    }

    public class MovieDetailQueryHandler : IRequestHandler<MovieDetailQuery, MovieDetailQueryResult>
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public MovieDetailQueryHandler(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

        public async Task<MovieDetailQueryResult> Handle(MovieDetailQuery request, CancellationToken cancellationToken)
        {
            MovieDetailQueryResult result = null;
            var settings = await mediator.Send(new SettingsQuery());
            string moviePath = Path.Combine(settings.MoviesFolderPath, request.Title); 

            var serializer = new XmlSerializer(typeof(MovieDetailXml));

            var metaFilePath = moviePath + @"\movie.xml";

            using (var xmlStream = new FileStream(metaFilePath, FileMode.Open))
            {
                var movieDetail = serializer.Deserialize(xmlStream) as MovieDetailXml;
                if (movieDetail != null)
                {
                    result = mapper.Map<MovieDetailQueryResult>(movieDetail);
                    GetActors(movieDetail, result);
                    await GetCoverArt(moviePath, result);
                }
            }

            return await Task.FromResult(result);
        }

        private void GetActors(MovieDetailXml movieDetail, MovieDetailQueryResult result)
        {
            if (movieDetail.Persons != null && movieDetail.Persons.Any())
            {
                var actors = movieDetail.Persons.Where(p => p.Type == "Actor").Take(5);
                result.Actors = actors.Select(a => a.Name).ToArray();
            }
        }

        private static async Task GetCoverArt(string path, MovieDetailQueryResult result)
        {
            var coverPath = path + "\\folder.jpg";
            byte[] imageArray = await File.ReadAllBytesAsync(coverPath);
            result.CoverArt = Convert.ToBase64String(imageArray);
        }
    }

    public class MovieDetailQueryResult
    {
        public string LocalTitle { get; set; }

        public string ProductionYear { get; set; }

        public string ContentRating { get; set; }

        public int RunningTime { get; set; }

        public string Overview { get; set; }

        public string[] Genres { get; set; }

        public string[] Actors { get; set; }

        public string CoverArt { get; set; }
    }
}
