using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MVCProject2.Infrastructure
{
    public class CustomAuthFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Cookies.ContainsKey("UserId"))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Controller", "Users" }, { "Action", "Login" } });
            }
            base.OnActionExecuting(context);
        }
    }
}
