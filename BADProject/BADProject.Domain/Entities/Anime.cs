using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BADProject.Domain.Entities
{
    public class Anime
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Release_date { get; set; }
        public int GenreId {  get; set; }
        public Genre Genre { get; set; }
        public string ImageURL { get; set; }
        public ICollection<Reviews> Reviews { get; set; }

    }
}
