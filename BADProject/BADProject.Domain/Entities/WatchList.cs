using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BADProject.Domain.Entities
{
    public class WatchList
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int AnimeId { get; set; }
        public Anime Anime { get; set; }
    }
}
