using FinancialTrackingApi.DataAccess.Entities;
using FinancialTrackingApi.Model;
using Microsoft.AspNetCore.Identity;

namespace FinancialTrackingApi.Service.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser?> GetUserByUsernameAsync(string username);
        Task<IdentityResult> RegisterUserAsync(UserRegisterModel model);
        Task<AccessToken> LoginUserAsync(UserLoginModel model);
        Task<IdentityResult> ChangePasswordAsync(string username, UserChangePasswordModel model);
    }
}
