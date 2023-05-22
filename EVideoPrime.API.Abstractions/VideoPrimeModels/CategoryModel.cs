using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVideoPrime.API.Abstractions.Models.VideoPrime
{
    public class CategoryModel
    {
        public CategoryModel()
        {
            Movies = new List<MovieModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual IEnumerable<MovieModel> Movies { get; set; }
    }
}
