using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieBrowser.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MovieBrowser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieDetailController : ControllerBase
    {
        private IMapper _mapper;

        public MovieDetailController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<MovieDetail> Get(string title)
        {
            MovieDetail result = null;
            string moviePath = @"c:\Movies\" + title; // TODO config

            var serializer = new XmlSerializer(typeof(MovieDetailXml));

            var metaFilePath = moviePath + @"\movie.xml";

            using (var xmlStream = new FileStream(metaFilePath, FileMode.Open))
            {
                var movieDetail = serializer.Deserialize(xmlStream) as MovieDetailXml;
                if (movieDetail != null)
                {
                    result = _mapper.Map<MovieDetail>(movieDetail);
                    GetActors(movieDetail, result);
                    await GetCoverArt(moviePath, result);
                }
            }
            
            return result;
        }

        private void GetActors(MovieDetailXml movieDetail, MovieDetail result)
        {
            if(movieDetail.Persons!= null && movieDetail.Persons.Any())
            {
                var actors = movieDetail.Persons.Where(p => p.Type == "Actor").Take(5);
                result.Actors = actors.Select(a => a.Name).ToArray();
            }
        }

        private static async Task GetCoverArt(string path, MovieDetail result)
        {
            var coverPath = path + "\\folder.jpg";
            byte[] imageArray = await System.IO.File.ReadAllBytesAsync(coverPath);
            result.CoverArt = Convert.ToBase64String(imageArray);
        }
    }
}