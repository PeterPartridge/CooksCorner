using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CooksCorner1._0.Models
{
    public class CommentModel
    {
        [Key]
        public int id { get; set;}
        [Required]
        public string Author { get; set; }
        
        public string comment { get; set;}

         public int RecipeId { get; set; }

         public DateTime MessageTime { get; set; }

        [ForeignKey("RecipeId")]
        public virtual RecipeModel Recipes { get; set; }


    }
}