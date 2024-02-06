using FinancialTrackingApi.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FinancialTrackingApi.Common
{
    public class HttpContextService : IHttpContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserName()
        {
            try
            {
                var userName = _httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(s => s.Type == ClaimTypes.NameIdentifier)?.Value;
                return userName;
            }
            catch (Exception ex)
            {
                throw new UnauthorizedAccessException("User not found", ex);
            }
        }
    }
}
