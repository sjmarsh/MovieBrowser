using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieBrowser.Models;

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

        public async Task <MovieDetail> Get()
        {
            MovieDetail result = null;

            var serializer = new XmlSerializer(typeof(MovieDetailXml));

            using (var xmlStream = new FileStream(@"c:\Movies\Big Hero 6\movie.xml", FileMode.Open))
            {
                var movieDetail = serializer.Deserialize(xmlStream) as MovieDetailXml;
                if (movieDetail != null)
                {
                    result = _mapper.Map<MovieDetail>(movieDetail);
                    GetActors(movieDetail, result);
                    await GetCoverArt(result);
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

        private static async Task GetCoverArt(MovieDetail result)
        {
            var coverPath = @"c:\Movies\Big Hero 6\folder.jpg";
            byte[] imageArray = await System.IO.File.ReadAllBytesAsync(coverPath);
            result.CoverArt = Convert.ToBase64String(imageArray);
        }
    }
}