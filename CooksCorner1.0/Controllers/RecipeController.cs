using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CooksCorner1._0.Models;
using Antlr.Runtime.Misc;
using System.Net;
using System.Data.Entity;
using System.Data;
using System.IO;
using PagedList;
using System.Collections;

namespace CooksCorner1._0.Controllers
{
    public class RecipeController : Controller
    {
        CooksCornerDBset _db = new CooksCornerDBset();
      

        // GET: Recipe
        public ActionResult Index(string searchString = null, string CSearchString = null, string DSearchString = null, int page = 1)
        {
            //dropdown for Cusine type
            var CusineList = new List<string>();

            var CusineQuery = from C in _db.CuisineDB
                              orderby C.type_of_Cusine
                              select C.type_of_Cusine;

            CusineList.AddRange(CusineQuery.Distinct());

            ViewBag.CSearchString = new SelectList(CusineList);


            //dropdown for diffculty
            var DiffcultyList = new List<int>();

            var DiffcultyQuery = from x in _db.DiffDB
                                 orderby x.Diffculty
                                 select x.Diffculty;

            DiffcultyList.AddRange(DiffcultyQuery.Distinct());

            ViewBag.DSearchString = new SelectList(DiffcultyList);
          
            //search string
            var model = _db.RecipeDB.OrderByDescending(c => c.Title)
                .Where(r => searchString == null || r.Title.Contains(searchString)).ToArray()
                .Where(c => CSearchString == null || c.Cuisine.type_of_Cusine.Contains(CSearchString)).ToArray()
                .Where(x => DSearchString == null || x.Difficulty.Diffculty.ToString().Contains(DSearchString))
                .Select(r => new RecipeModel
                {
                    RecipeId = r.RecipeId,
                    Title = r.Title,
                    Difficulty = r.Difficulty,
                    Ingrediants = r.Ingrediants,
                    Instructions = r.Instructions,
                    Cuisine = r.Cuisine,
                    CookingTimeMins = r.CookingTimeMins,
             CookingTimeHours = r.CookingTimeHours,  
             PrepTimeMins = r.PrepTimeMins,
             PrepTimeHours = r.PrepTimeHours,
                    AuthorName = r.AuthorName,
                 
                }).ToPagedList(page, 10);
             
    
        if (Request.IsAjaxRequest())
        {
            return PartialView("_RecipeSearch", model);
        }

            
          return View(model);
        }
      
        




        // get edit view 
        [Authorize]
        public ActionResult recipeEdit(int? id )
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RecipeModel recipe = _db.RecipeDB.Include(i => i.Images).SingleOrDefault(s => s.RecipeId == id);

           // view model for edit view 

            var viewModel = new EditViewModle
       {
           RecipeId = recipe.RecipeId,
           Title = recipe.Title,
           Blurb = recipe.Blurb,
           PrepTimeHours = recipe.PrepTimeHours,
           PrepTimeMins = recipe.PrepTimeMins,
           CookingTimeMins = recipe.CookingTimeMins,
           CookingTimeHours = recipe.CookingTimeHours,
           Images = recipe.Images,
           Instructions = recipe.Instructions,
           Ingrediants = recipe.Ingrediants,
           AuthorName = recipe.AuthorName,
           DiffcultyId = recipe.DiffcultyId,
           CusineId = recipe.CusineId,
           Cusines = new SelectList (_db.CuisineDB, "CusineId","type_of_Cusine", recipe.CusineId ),
           Diffculties = new SelectList(_db.DiffDB, "DiffcultyId", "Diffculty", recipe.DiffcultyId)


       }; 

            if (recipe == null)
            {
                return HttpNotFound();
            }

            return View(viewModel);
        }


        //post edit view
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult recipeEdit([Bind(Exclude = "vote")] EditViewModle recipe,HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RecipeModel Recipes = new RecipeModel();

                    Recipes.AuthorName = recipe.AuthorName;
                    Recipes.Blurb = recipe.Blurb;
                    Recipes.DiffcultyId = recipe.DiffcultyId;
                    Recipes.Images = recipe.Images;
                    Recipes.Ingrediants = recipe.Ingrediants;
                    Recipes.Instructions = recipe.Instructions;
                    Recipes.Title = recipe.Title;
                    Recipes.CookingTimeHours = recipe.CookingTimeHours;
                    Recipes.CookingTimeMins = recipe.CookingTimeMins;
                    Recipes.PrepTimeHours = recipe.PrepTimeHours;
                    Recipes.PrepTimeMins = recipe.PrepTimeMins;
                    Recipes.RecipeId = recipe.RecipeId;
                    Recipes.CusineId = recipe.CusineId;
                    
                      if (upload != null && upload.ContentLength > 0)
                    {
                        var foodImage = new CooksCorner1._0.Models.File
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.foodImage,
                            ContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            foodImage.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        Recipes.Images = new List<CooksCorner1._0.Models.File> { foodImage };
                    }



                  

                   _db.Entry(Recipes).State = EntityState.Modified;
                    _db.SaveChanges();

                    return RedirectToAction("Details", recipe);
                }
            }

            catch (DataException)
            {
                ModelState.AddModelError("", "An error has occured saving your edit");
            }

            //for cusine and diffculty drop down bar's
          //  setCusineAndDifficultyViewBag(recipe.DiffcultyId, recipe.CusineId);

          return View(recipe);
        }





        // cretit new get
        [Authorize]
           public ActionResult CreateNew()
        {

            //for cusine and diffculty drop down bar's
            setCusineAndDifficultyViewBag();

            
              

            return View();   
        }


        //create a new recipe
           [HttpPost]
           [Authorize]
           [ValidateAntiForgeryToken]
        public ActionResult CreateNew([Bind()] RecipeModel recipe, HttpPostedFileBase upload)
           {
                  

               try
               {
                   if (ModelState.IsValid)
                   {
                       if (upload != null && upload.ContentLength > 0)
                       {
                           var foodImage = new CooksCorner1._0.Models.File
                           {
                               FileName = System.IO.Path.GetFileName(upload.FileName),
                               FileType = FileType.foodImage,
                               ContentType = upload.ContentType
                           };
                           using (var reader = new System.IO.BinaryReader(upload.InputStream))
                           {
                               foodImage.Content = reader.ReadBytes(upload.ContentLength);
                           }
                           recipe.Images = new List<CooksCorner1._0.Models.File> { foodImage };
                       }

                       var user = HttpContext.GetOwinContext().Request.User.Identity.Name;
                       recipe.AuthorName = user;
                   }
                       _db.RecipeDB.Add(recipe);
                       _db.SaveChanges();

                       return RedirectToAction("index");
                   }
               


               catch (DataException)
               {
                   ModelState.AddModelError("", "An error has occured saving your recipe");
               }

               setCusineAndDifficultyViewBag();

               return View(recipe);
           }





           public ActionResult recipeDetails(int? id)
         {

             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }

             RecipeModel recipe = _db.RecipeDB.Include(i => i.Images).Include(x => x.comments).SingleOrDefault(s => s.RecipeId == id);

             if (recipe == null)
             {
                 return HttpNotFound();
             }

             return View(recipe);
         }

        // get comments for a recipe
        [HttpGet]
           public ActionResult _addComment(int? Id)
           {
               RecipeModel recipe = _db.RecipeDB.Include(i => i.comments).SingleOrDefault(s => s.RecipeId == Id);
               //var comment = _db.CommentDB.OrderBy(x => x.MessageTime).Where(x => x.RecipeId == Id).ToArray().Select(x => new CommentModel 
               //{
               //id = x.id,
               //MessageTime = x.MessageTime,
               //comment = x.comment,
               //Author = x.Author,
               //RecipeId = x.RecipeId
               //});
               
              
               return PartialView(recipe);
           }


        //post  a new comment
    [Authorize]
        [HttpPost]
           public ActionResult _addComment(CommentModel Com)
           {
               var recipe = new RecipeModel();
               var user = HttpContext.GetOwinContext().Request.User.Identity.Name;
               Com.Author = user;
               Com.MessageTime = DateTime.Now;
            try
               {
                   if (ModelState.IsValid)
                   {
                       //var user = HttpContext.GetOwinContext().Request.User.Identity.Name;
                                  

                   }
                       _db.CommentDB.Add(Com);
                       _db.SaveChanges();     
                
                return PartialView("_addComment", recipe);
                   }
               
               catch (DataException)
               {
                   ModelState.AddModelError("", "An error has occured saving your recipe");
               }

               
              

               return PartialView(Com);

           }


        //this is for users to acces their recipes

        public ActionResult userRecipes(string searchString= null)

        {        var model = _db.RecipeDB.OrderByDescending(c => c.Title).Where(r => searchString == null).ToArray().Where(r=> r.AuthorName == User.Identity.Name)
    .Select(r => new RecipeModel
    {
        RecipeId = r.RecipeId,
        Title = r.Title,
        Difficulty = r.Difficulty,
        Ingrediants = r.Ingrediants,
        Instructions = r.Instructions,
        Cuisine = r.Cuisine,
        Images = r.Images,
        AuthorName = r.AuthorName,
        PrepTimeHours = r.PrepTimeHours,
        PrepTimeMins = r.PrepTimeMins,
        CookingTimeMins = r.CookingTimeMins,
        CookingTimeHours = r.CookingTimeHours,
        comments = r.comments.ToList(),
    }).ToList();

            return View(model);
        }

//view bag for cusine and diffcullty 
            private void setCusineAndDifficultyViewBag(int? CusineId = null, int? DiffcultyId = null)
            {
                if (CusineId == null)
                    ViewBag.CusineId = new SelectList(_db.CuisineDB, "CusineId", "type_of_cusine");

                else
                    ViewBag.CusineId = new SelectList(_db.CuisineDB.ToArray(), "CusineId", "type_of_cusine", CusineId);

                if (DiffcultyId == null)
                    ViewBag.DiffcultyID = new SelectList(_db.DiffDB, "DiffcultyId", "Diffculty");

                else
                    ViewBag.DiffcultyID = new SelectList(_db.DiffDB.ToArray(), "DiffcultyId", "Diffculty", DiffcultyId);
            }

           
       }
    }
