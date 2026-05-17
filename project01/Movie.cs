using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<Review> Reviews { get; set; }
        public List<Watchlist> Watchlists { get; set; }
    }
}