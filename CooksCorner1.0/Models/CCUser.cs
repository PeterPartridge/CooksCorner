using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace CooksCorner1._0.Models
{
    public class CCUser : IdentityUser
    {
        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<CCUser> manager)
        //{
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        //    // Add custom user claims here
        //    return userIdentity;
        //}


        //public CCUser()
        //{
        //    votes = new List<RecipeVotesModel>();
        //}
        //public IEnumerable<RecipeVotesModel> votes { get; set; }
     
    }
}
