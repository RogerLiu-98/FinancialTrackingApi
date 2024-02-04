using FinancialTrackingApi.DataAccess.Helpers.Interfaces;
using Microsoft.AspNetCore.Http;

namespace FinancialTrackingApi.DataAccess.Helpers
{
    public class UserProvider : IUserProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetUserId()
        {
            int userId = 0;
            Int32.TryParse(_httpContextAccessor.HttpContext?.User?.Identity?.Name, out userId);
            return userId;
        }
    }
}
