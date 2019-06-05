using AutoMapper;
using MovieBrowser.Models;

namespace MovieBrowser.Profiles
{
    public class MovieDetailProfile : Profile
    {
        public MovieDetailProfile()
        {
            CreateMap<MovieDetailXml, MovieDetailCommandResult>();
        }
    }
}
