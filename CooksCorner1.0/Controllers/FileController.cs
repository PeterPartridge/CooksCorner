using CooksCorner1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CooksCorner1._0.Controllers
{
    public class FileController : Controller
    {
        private CooksCornerDBset _db = new CooksCornerDBset(); 

        //get file
        public ActionResult Index(int id)
        {
            var fileToRetrive = _db.ImagesDB.Find(id);
            return File(fileToRetrive.Content, fileToRetrive.ContentType);
        }
    }
}