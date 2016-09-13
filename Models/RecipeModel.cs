using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CooksCorner1._0.Models
{
    public class RecipeModel
    {     
        public RecipeModel()
        {
        comments = new List<CommentModel>();
    }


        [Key]
        public int RecipeId { get; set; }
        
        public string Title { get; set; }
        
        public string Ingrediants { get; set; }
        
        public string Instructions { get; set; }

        public int PrepTimeMins { get; set; }

        public int PrepTimeHours { get; set; }

        public int CookingTimeHours { get; set; }

        public int CookingTimeMins { get; set; }
        
        public int CusineId { get; set; }
        
        public int DiffcultyId { get; set; }
       
        public string AuthorName { get; set; }
        
        [ForeignKey("CusineId")]
        public virtual Cuisine_Type Cuisine { get; set; }

        [ForeignKey("DiffcultyId")]
        public virtual DiffcultyModel Difficulty { get; set; }


        public int PictureId { get; set; }

        [ForeignKey("PictureId")]
        public virtual PictureModel Pictures { get; set; }


        public virtual ICollection<CommentModel> comments { get; set; }

        public string Blurb { get; set; }

    }
}