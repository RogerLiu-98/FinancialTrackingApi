using FinancialTrackingApi.DataAccess.Entities;
using FinancialTrackingApi.Model;
using FinancialTrackingApi.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace FinancialTrackingApi.Service
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly ITokenService _tokenService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserService(ILogger<UserService> logger,
            ITokenService tokenService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _tokenService = tokenService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ApplicationUser?> GetUserByUsernameAsync(string username)
        {
            _logger.LogInformation($"Getting user by username {username}");
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<bool> CheckUserPasswordAsync(ApplicationUser user, string password)
        {
            _logger.LogInformation($"Checking user password for user {user.UserName}");
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<SignInResult> LoginUserAsync(ApplicationUser user, UserLoginModel model)
        {
            _logger.LogInformation($"Logging in user {model.UserName}");
            return await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
        }

        public async Task<IdentityResult> RegisterUserAsync(UserRegisterModel model)
        {
            _logger.LogInformation($"Registering user {model.UserName}");
            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                PhoneNumber = model.Phone,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
            };
            return await _userManager.CreateAsync(user, model.Password);
        }

        public async Task<IdentityResult> ChangePasswordAsync(string username, UserChangePasswordModel model)
        {
            var user = await GetUserByUsernameAsync(username);
            _logger.LogInformation($"Changing password for user {user.UserName}");
            return await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        }
    }
}
