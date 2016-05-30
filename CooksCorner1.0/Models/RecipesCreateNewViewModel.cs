using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CooksCorner1._0.Models
{
    public class RecipesCreateNewViewModel
    {

        public int RecipeId { get; set; }
        [Required]
        [MinLength(3, ErrorMessage="Please add a title")]
        public string Title { get; set; }
        [Required]
        [MinLength(10, ErrorMessage="Please tell us more about how you found this recipe")]
        [Display(Name = "Story about how you found this recipe")]
        public string Blurb { get; set; }
        
        [Required]
        [MinLength(10, ErrorMessage="Please add more more to your ingrediants section")]
        public string Ingrediants { get; set; }
        
        [Required]
        [MinLength(10, ErrorMessage="Please add more to your Method section")]
        public string Instructions { get; set; }
        [Required(ErrorMessage = "Please add a time from 0 Minutes to 59mins")]
        [Range(0,59,ErrorMessage="Please add a time from 0 Minutes to 59mins")]
        public int PrepTimeMins { get; set; }
        [Required(ErrorMessage = "Please add a time from 0 Hours to 24 Hours")]
        [Range(0,24,ErrorMessage="Please add a time from 0 Hours to 24 Hours")]
        public int PrepTimeHours { get; set; }
        [Required(ErrorMessage = "Please add a time from 0 Hours to 24 Hours")]
        [Range(0,24,ErrorMessage = "Please add a time from 0 hours to 24 hours")]
        public int CookingTimeHours { get; set; }
        [Required(ErrorMessage = "Please add a time from 0 Minutes to 59mins")]
        [Range(0,59,ErrorMessage = "Please add a time from 0 mins to 59 mins")]
        public int CookingTimeMins { get; set; }

        [Required(ErrorMessage="Please select a Country")]
        public int CusineId { get; set; }
        [Required(ErrorMessage = "Please select a diffculty type")]
        public int DiffcultyId { get; set; }

        public string AuthorName { get; set; }

        [ForeignKey("CusineId")]
        public virtual Cuisine_Type Cuisine { get; set; }

        [ForeignKey("DiffcultyId")]
        public virtual DiffcultyModel Difficulty { get; set; }
       


        public virtual ICollection<File> Images { get; set; }

        public virtual ICollection<CommentModel> comments { get; set; }

    }
}