using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MeghanGroceryList.Models
{
    public class BasicAuthenticationAttribute : ActionFilterAttribute
    {
        private const string Realm = "MyRealm";
        private const string UserName = "";
        private const string Password = "list";

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var authorizationHeader = filterContext.RequestContext.HttpContext.Request.Headers["Authorization"];

            if (authorizationHeader != null && authorizationHeader.StartsWith("Basic"))
            {
                var credentials = Encoding.ASCII.GetString(
                    Convert.FromBase64String(authorizationHeader.Substring(6))
                    ).Split(':');

                if (credentials[0].Equals(UserName) && credentials[1].Equals(Password))
                {
                    base.OnActionExecuting(filterContext);
                    return;
                }
            }

            // send require authentication
            var response = filterContext.HttpContext.Response;
            response.StatusCode = 401;
            response.AddHeader("WWW-Authenticate", String.Format("Basic realm=\"{0}\"", Realm));
            response.End();
        }
    }
}