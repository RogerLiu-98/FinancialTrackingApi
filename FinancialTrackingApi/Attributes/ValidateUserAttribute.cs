using FinancialTrackingApi.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FinancialTrackingApi.Attributes
{
    public class ValidateUserAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var httpContextService = context.HttpContext.RequestServices.GetService(typeof(IHttpContextService)) as IHttpContextService;

            var userName = httpContextService.GetUserName();
            if (string.IsNullOrEmpty(userName))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
