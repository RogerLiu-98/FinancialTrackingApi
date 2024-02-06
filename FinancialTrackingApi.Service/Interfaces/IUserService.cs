using FinancialTrackingApi.DataAccess.Entities;
using FinancialTrackingApi.Model;
using Microsoft.AspNetCore.Identity;

namespace FinancialTrackingApi.Service.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser?> GetUserByUsernameAsync(string username);
        Task<bool> CheckUserPasswordAsync(ApplicationUser user, string password);
        Task<IdentityResult> RegisterUserAsync(UserRegisterModel model);
        Task<SignInResult> LoginUserAsync(ApplicationUser user, UserLoginModel model);
        Task<IdentityResult> ChangePasswordAsync(string username, UserChangePasswordModel model);
    }
}
