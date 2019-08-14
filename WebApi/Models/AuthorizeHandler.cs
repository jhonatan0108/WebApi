using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebApi.Models
{
    public class AuthorizeHandler : System.Web.Mvc.AuthorizeAttribute
    {
        //Entities context = new Entities(); // my entity  
        private readonly string[] allowedroles;
        public AuthorizeHandler(params string[] user)
        {
            this.allowedroles = user;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            //foreach (var role in allowedroles)
            //{
            //    var user = context.AppUser.Where(m => m.UserID == GetUser.CurrentUser/* getting user form current context */ && m.Role == role &&
            //    m.IsActive == true); // checking active users with allowed roles.  
            //    if (user.Count() > 0)
            //    {
            //        authorize = true; /* return true if Entity has current user(active) with specific role */
            //    }
            //}
            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}