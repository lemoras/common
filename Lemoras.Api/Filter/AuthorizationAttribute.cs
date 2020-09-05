using Lemoras.Domain.Parts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lemoras.Api.Filter
{
    public class AuthorizationAttribute : ActionFilterAttribute
    {
        private readonly IApplicationContext _applicationContext;

        public AuthorizationAttribute(IApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (_applicationContext.UserId <= 0)
            {
                context.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.Forbidden);
            }
        }
    }
}
