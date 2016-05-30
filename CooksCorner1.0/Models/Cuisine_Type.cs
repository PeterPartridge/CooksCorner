using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooksCorner1._0.Models
{
   public class Cuisine_Type
    {
       //this should make one to many relationship. Their is one cusine type and many recipes. 
       public Cuisine_Type()
       {
       Recipes = new List<RecipeModel>();
       }

       [Key]
       public int CusineId { get; set; }
       
      [Required(ErrorMessage = "Please enter a country this dish is from")]
      [DisplayName("Country")]
       public string type_of_Cusine { get; set; }
       
       public ICollection<RecipeModel> Recipes { get; set; }
    }
}
