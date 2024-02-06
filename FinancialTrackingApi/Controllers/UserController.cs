using Asp.Versioning;
using FinancialTrackingApi.Attributes;
using FinancialTrackingApi.Common.Interfaces;
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
        private readonly ITokenService _tokenService;
        private readonly IHttpContextService _httpContextService;

        public UserController(IUserService userService, ITokenService tokenService, IHttpContextService httpContextService)
        {
            _userService = userService;
            _tokenService = tokenService;
            _httpContextService = httpContextService;
        }

        [HttpPatch("change-password", Name = "ChangePassword")]
        [SwaggerOperation(Summary = "Change user password", OperationId = "ChangePassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ValidateUser]
        public async Task<ActionResult<IdentityResult>> ChangePassword([FromBody][SwaggerRequestBody] UserChangePasswordModel model)
        {
            var userName = _httpContextService.GetUserName();
            var user = await _userService.GetUserByUsernameAsync(userName);
            if (user == null)
            {
                return NotFound("User not found");
            }
            var result = await _userService.ChangePasswordAsync(userName, model);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("login", Name = "Login")]
        [SwaggerOperation(Summary = "Login a user", OperationId = "Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<AccessToken>> Login([FromBody][SwaggerRequestBody] UserLoginModel model)
        {
            var user = await _userService.GetUserByUsernameAsync(model.UserName);
            if (user == null)
            {
                return Unauthorized("User not found");
            }
            var passwordCorrect = await _userService.CheckUserPasswordAsync(user, model.Password);
            if (!passwordCorrect)
            {
                return Unauthorized("Invalid password");
            }
            var result = await _userService.LoginUserAsync(user, model);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
            var token = await _tokenService.GenerateAccessTokenAsync(user);
            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost("register", Name = "Register")]
        [SwaggerOperation(Summary = "Register a new user", OperationId = "Register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
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
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
            return Ok(result);
        }
    }
}
