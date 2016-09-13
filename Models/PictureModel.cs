using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace CooksCorner1._0.Models
{

    public class PictureModel
    {
        [Key]
        public int PictureId { get; set; }
        public byte[] picture { get; set; }
        public DateTime datePictureAdded { get; set; }


    }
}
