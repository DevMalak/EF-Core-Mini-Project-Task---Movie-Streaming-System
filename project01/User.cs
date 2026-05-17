using System.Collections.Generic;

namespace project01
{
  
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public List<Review> Reviews { get; set; }
        public List<Watchlist> Watchlists { get; set; }
    }
}