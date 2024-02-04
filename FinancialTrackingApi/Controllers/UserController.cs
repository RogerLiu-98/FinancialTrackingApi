using Asp.Versioning;
using FinancialTrackingApi.Controllers.Interfaces;
using FinancialTrackingApi.Model;
using FinancialTrackingApi.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FinancialTrackingApi.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("/api/user/v1")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class UserController : ControllerBase, IUserController
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("user-change-password", Name = "ChangePassword")]
        [SwaggerOperation(Summary = "Change user password", OperationId = "ChangePassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IdentityResult>> ChangePassword(UserChangePasswordModel model)
        {
            var userName = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(s => s.Type == "sub").Value;
            var user = await _userService.GetUserByUsernameAsync(userName);
            if (user == null)
            {
                return NotFound("User not found");
            }
            var result = await _userService.ChangePasswordAsync(userName, model);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("user-login", Name = "Login")]
        [SwaggerOperation(Summary = "Login a user", OperationId = "Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<AccessToken>> Login(UserLoginModel model)
        {
            var result = await _userService.LoginUserAsync(model);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("user-register", Name = "Register")]
        [SwaggerOperation(Summary = "Register a new user", OperationId = "Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IdentityResult>> Register([FromBody][SwaggerRequestBody] UserRegisterModel model)
        {
            var user = await _userService.GetUserByUsernameAsync(model.UserName);
            if (user != null)
            {
                return Conflict("User already exists");
            }
            var result = await _userService.RegisterUserAsync(model);
            return Ok(result);
        }
    }
}
