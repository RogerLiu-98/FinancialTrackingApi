using FinancialTrackingApi.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTrackingApi.Controllers.Interfaces
{
    public interface IUserController
    {
        Task<ActionResult<IdentityResult>> Register(UserRegisterModel model);
        Task<ActionResult<AccessToken>> Login(UserLoginModel model);
        Task<ActionResult<IdentityResult>> ChangePassword(UserChangePasswordModel model);
    }
}
