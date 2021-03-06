﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace MovieBrowser.Models
{
    public class MovieQuery : IRequest<MovieQueryResult>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }

    public class MovieQueryHandler : IRequestHandler<MovieQuery, MovieQueryResult>
    {
        private readonly IMediator mediator;

        public MovieQueryHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<MovieQueryResult> Handle(MovieQuery request, CancellationToken cancellationToken)
        {
            var result = new MovieQueryResult();

            var settings = await mediator.Send(new SettingsQuery());

            var di = new DirectoryInfo(settings.MoviesFolderPath); 
            var directories = di.GetDirectories();
            List<DirectoryInfo> pagedDirectories;

            if (request.Skip == 0 && request.Take == 0)
            {
                pagedDirectories = directories.ToList();
            }
            else
            {
                pagedDirectories = directories.Skip(request.Skip).Take(request.Take).ToList();
                double pages = (double)directories.Count() / request.Take;
                result.TotalPages = Convert.ToInt32(Math.Ceiling(pages));
            }
            
            foreach (var dir in pagedDirectories)
            {
                var movie = new Movie
                {
                    Title = dir.Name,
                    Path = dir.FullName
                };
                var imageFile = Path.Combine(dir.FullName, "folder.jpg");
                if (File.Exists(imageFile))
                {
                    using (var img = await Task.Run(() => Image.Load(imageFile)))
                    {
                        img.Mutate(x => x.Resize(160, 240));
                        movie.CoverArt = img.ToBase64String(ImageFormats.Jpeg);
                        result.Movies.Add(movie);
                    }
                }
            }
            
            return await Task.FromResult(result);
        }
    }

    public class MovieQueryResult
    {
        public MovieQueryResult()
        {
            Movies = new List<Movie>();
        }

        public List<Movie> Movies { get; set; }

        public int TotalPages { get; set; }
    }

    public class Movie
    {
        public string Title { get; set; }

        public string Path { get; set; }

        public string CoverArt { get; set; }
    }
}
