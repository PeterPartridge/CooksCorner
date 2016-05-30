using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CooksCorner1._0.Models
{
    public class DiffcultyModel
    {
        public DiffcultyModel()
        {
            Recipes = new List<RecipeModel>();
    }

        [Key]
        public int DiffcultyId { get; set; }

        public int Diffculty { get; set; }

        public IEnumerable<RecipeModel> Recipes { get; set; }
    }
}