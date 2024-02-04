using FinancialTrackingApi.DataAccess.Entities;
using FinancialTrackingApi.Model;

namespace FinancialTrackingApi.Service.Interfaces
{
    public interface ITokenService
    {
        Task<AccessToken> GenerateAccessTokenAsync(ApplicationUser user);
    }
}
