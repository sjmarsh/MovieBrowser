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
    public class MovieDetailCommand : IRequest<MovieDetailCommandResult>
    {
        [Required]
        public string Title { get; set; }
    }

    public class MovieDetailCommandHandler : IRequestHandler<MovieDetailCommand, MovieDetailCommandResult>
    {
        private readonly IMapper mapper;

        public MovieDetailCommandHandler(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<MovieDetailCommandResult> Handle(MovieDetailCommand request, CancellationToken cancellationToken)
        {
            MovieDetailCommandResult result = null;
            string moviePath = @"c:\Movies\" + request.Title; // TODO config

            var serializer = new XmlSerializer(typeof(MovieDetailXml));

            var metaFilePath = moviePath + @"\movie.xml";

            using (var xmlStream = new FileStream(metaFilePath, FileMode.Open))
            {
                var movieDetail = serializer.Deserialize(xmlStream) as MovieDetailXml;
                if (movieDetail != null)
                {
                    result = mapper.Map<MovieDetailCommandResult>(movieDetail);
                    GetActors(movieDetail, result);
                    await GetCoverArt(moviePath, result);
                }
            }

            return result;
        }

        private void GetActors(MovieDetailXml movieDetail, MovieDetailCommandResult result)
        {
            if (movieDetail.Persons != null && movieDetail.Persons.Any())
            {
                var actors = movieDetail.Persons.Where(p => p.Type == "Actor").Take(5);
                result.Actors = actors.Select(a => a.Name).ToArray();
            }
        }

        private static async Task GetCoverArt(string path, MovieDetailCommandResult result)
        {
            var coverPath = path + "\\folder.jpg";
            byte[] imageArray = await File.ReadAllBytesAsync(coverPath);
            result.CoverArt = Convert.ToBase64String(imageArray);
        }
    }

    public class MovieDetailCommandResult
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
