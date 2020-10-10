using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace GoogleKeepClone_API.Services
{
    public class JWTAuthAttribute : ActionFilterAttribute
    {
        private string _role;
        private List<string> roles { get; set; }
        public JWTAuthAttribute(string role = "")
        {
            if (role.Length > 0)
            {
                _role = role;
                roles = role.Split(',').ToList();
            }
        }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var authorization = actionContext.Request.Headers.Authorization;
            if (authorization!=null && authorization.Scheme=="Bearer")
            {
                var token = authorization.Parameter;
                var authService = new JWTService();
                if (authService.IsTokenValid(token))
                {
                    var claim = authService.GetTokenClaims(token)
                    .FirstOrDefault(x => x.Type.Equals(ClaimTypes.Role)).Value;
                    if (!String.IsNullOrEmpty(_role))
                    {
                        var exist = roles.Where(a => a == claim).FirstOrDefault();
                        if (exist == null)  //pass when role is ""
                        {
                            actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Forbidden, "Sorry, You don't have access to this site.");
                        }
                    }
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Forbidden, "Sorry, Your token is no longer valid!");
                }
            }
            else
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Forbidden, "Sorry,Bearer token is needed");
            }
        }

    }
}
