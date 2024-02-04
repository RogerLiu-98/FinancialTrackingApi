using FinancialTrackingApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTrackingApi.Controllers.Interfaces
{
    public interface IUserController
    {
        Task<IActionResult> Register(UserRegisterModel model);
        Task<ActionResult<AccessToken>> Login(UserLoginModel model);
        Task<IActionResult> ChangePassword(UserChangePasswordModel model);
    }
}
