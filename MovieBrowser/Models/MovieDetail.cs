using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBrowser.Models
{
    public class MovieDetail
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
