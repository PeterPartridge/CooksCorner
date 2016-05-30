using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CooksCorner1._0.Models
{
    public class EditViewModle
    {
      
        public int RecipeId { get; set; }
        
        [MinLength(3, ErrorMessage="Please add a title.")]
        public string Title { get; set; }
        
        [MinLength(10, ErrorMessage="Please put more words in your Ingrediants section")]
        public string Ingrediants { get; set; }
        
        [MinLength(30, ErrorMessage="Please put more words in your Method section")]
        public string Instructions { get; set; }

        [Required(ErrorMessage = "Please add a time from 0 Minutes to 59mins")]
        [Range(0, 59, ErrorMessage = "Please add a time from 0 Minutes to 59mins")]
        public int PrepTimeMins { get; set; }
        [Required(ErrorMessage = "Please add a time from 0 Hours to 24 Hours")]
        [Range(0, 24, ErrorMessage = "Please add a time from 0 Hours to 24 Hours")]
        public int PrepTimeHours { get; set; }
        [Required(ErrorMessage = "Please add a time from 0 Hours to 24 Hours")]
        [Range(0, 24, ErrorMessage = "Please add a time from 0 hours to 24 hours")]
        public int CookingTimeHours { get; set; }
        [Required(ErrorMessage = "Please add a time from 0 Minutes to 59mins")]
        [Range(0, 59, ErrorMessage = "Please add a time from 0 mins to 59 mins")]
        public int CookingTimeMins { get; set; }


        public string AuthorName { get; set; }  

        public int CusineId { get; set; }
        public int DiffcultyId { get; set; }

        public IEnumerable<SelectListItem> Cusines { get; set; }
        
        public IEnumerable<SelectListItem> Diffculties { get; set; }      
        
        public virtual ICollection<File> Images { get; set; }

        
        [MinLength(5, ErrorMessage="Please tell us how you found this recipe")]
    [Display(Name="Story about how you found this recipe")]
        public string Blurb { get; set; }

    }
}