using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CooksCorner1._0.Models
{    
    public class CooksCornerDBset : IdentityDbContext<CCUser>
    {

        public CooksCornerDBset() : base ("name =DefaultConnection")
        {

        }
       
        public DbSet<RecipeModel> RecipeDB { get; set; }
        public DbSet<Cuisine_Type> CuisineDB { get; set; }
        public DbSet<DiffcultyModel> DiffDB { get; set; }
        public DbSet<File> ImagesDB { get; set; }
        public DbSet<CommentModel> CommentDB { get; set; }
        
       
    }
}