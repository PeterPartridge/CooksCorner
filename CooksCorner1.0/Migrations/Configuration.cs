namespace CooksCorner1._0.Migrations
{
    using CooksCorner1._0.Models;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CooksCorner1._0.Models.CooksCornerDBset>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CooksCorner1.0.Models.CooksCornerDBset";
        }

        protected override void Seed(CooksCorner1._0.Models.CooksCornerDBset context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );


            //if (System.Diagnostics.Debugger.IsAttached == false)
           //     System.Diagnostics.Debugger.Launch();


            context.CuisineDB.AddOrUpdate(i => i.type_of_Cusine,
                new Cuisine_Type {type_of_Cusine = "American" },
                new Cuisine_Type {type_of_Cusine = "Belgian" },
                new Cuisine_Type {type_of_Cusine = "Chinese" },
                new Cuisine_Type {type_of_Cusine = "Japnese" },
                new Cuisine_Type {type_of_Cusine = "Australian" },
                new Cuisine_Type {type_of_Cusine = "Danish" },
                new Cuisine_Type {type_of_Cusine = "Netherlands" },
                new Cuisine_Type {type_of_Cusine = "Thai" },
                new Cuisine_Type {type_of_Cusine = "Jamacian" },
                new Cuisine_Type {type_of_Cusine = "African" },
                new Cuisine_Type {type_of_Cusine = "Swedish" },
                new Cuisine_Type {type_of_Cusine = "English" },
                new Cuisine_Type {type_of_Cusine = "Scottish" },
                new Cuisine_Type {type_of_Cusine = "Welsh" },
                new Cuisine_Type {type_of_Cusine = "Irish" },
                new Cuisine_Type {type_of_Cusine = "West Indian" },
                new Cuisine_Type {type_of_Cusine = "Indian" },
                new Cuisine_Type {type_of_Cusine = "South Korean" }             
                              );
            context.DiffDB.AddOrUpdate(x => x.Diffculty, 
                new DiffcultyModel {Diffculty =1 },
                new DiffcultyModel {Diffculty =2 },
                new DiffcultyModel {Diffculty =3 },
                new DiffcultyModel {Diffculty =4 },
                new DiffcultyModel {Diffculty =5 },
                new DiffcultyModel {Diffculty =6 },
                new DiffcultyModel {Diffculty =7 },
                new DiffcultyModel {Diffculty =8 },
                new DiffcultyModel {Diffculty =9 },
                new DiffcultyModel {Diffculty =10 }
                               );
                               
        }
    }
}
