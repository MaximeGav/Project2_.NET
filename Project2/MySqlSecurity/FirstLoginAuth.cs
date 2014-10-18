using Project2.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Project2.MySqlSecurity
{
    public class FirstLoginAuth : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authorized = base.AuthorizeCore(httpContext);
            if (!authorized)
            {
                // The user is not authorized => no need to go any further
                return false;
            }

            // We have an authenticated user, let's get his username
            string authenticatedUser = httpContext.User.Identity.Name;

            // and check if he has completed his profile
            if (this.IsFirstLogin(authenticatedUser))
            {
                // we store some key into the current HttpContext so that 
                // the HandleUnauthorizedRequest method would know whether it
                // should redirect to the Login or CompleteProfile page
                httpContext.Items["redirectToPasswordRequest"] = true;
                return false;
            }

            return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Items.Contains("redirectToPasswordRequest"))
            {
                var routeValues = new RouteValueDictionary(new
                {
                    controller = "Account",
                    action = "FirstLogin",
                });
                filterContext.Result = new RedirectToRouteResult(routeValues);
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }

        private bool IsFirstLogin(string user)
        {
            // You know what to do here => go hit your database to verify if the
            // current user has already completed his profile by checking
            // the corresponding field
            MySqlWebSecurity security = new MySqlWebSecurity(new AppContext());
            return security.IsFirstLogin(user);
        }
    }
}