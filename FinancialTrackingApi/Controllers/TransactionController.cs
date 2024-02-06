using Asp.Versioning;
using FinancialTrackingApi.Attributes;
using FinancialTrackingApi.Common.Interfaces;
using FinancialTrackingApi.Controllers.Interfaces;
using FinancialTrackingApi.Model;
using FinancialTrackingApi.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FinancialTrackingApi.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("/api/transaction/v1")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ValidateUser]
    public class TransactionController : ControllerBase, ITransactionController
    {
        private readonly IUserService _userService;
        private readonly ITransactionService _transactionService;
        private readonly IValidationService _validationService;
        private readonly IHttpContextService _httpContextService;

        public TransactionController(IUserService userService, ITransactionService transactionService, IValidationService validationService, IHttpContextService httpContextService)
        {
            _userService = userService;
            _transactionService = transactionService;
            _validationService = validationService;
            _httpContextService = httpContextService;
        }

        [HttpPost("create-transaction", Name = "CreateTransaction")]
        [SwaggerOperation(Summary = "Create a new transaction", OperationId = "CreateTransaction")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TransactionModel>> CreateTransaction([FromBody] TransactionCreateModel transaction)
        {
            var userName = _httpContextService.GetUserName();
            var user = await _userService.GetUserByUsernameAsync(userName);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var validationResult = await _validationService.ValidateModelAsync(transaction);
            if (!validationResult.IsValid || validationResult.Errors.Any())
            {
                return BadRequest(validationResult.Errors);
            }

            var result = await _transactionService.CreateTransactionAsync(transaction, user.Id);
            return Ok(result);
        }

        [HttpPatch("update-transaction", Name = "UpdateTransaction")]
        [SwaggerOperation(Summary = "Update a transaction", OperationId = "UpdateTransaction")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TransactionModel>> UpdateTransaction(TransactionUpdateModel transaction)
        {
            var userName = _httpContextService.GetUserName();
            var user = await _userService.GetUserByUsernameAsync(userName);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var validationResult = await _validationService.ValidateModelAsync(transaction);
            if (!validationResult.IsValid || validationResult.Errors.Any())
            {
                return BadRequest(validationResult.Errors);
            }

            var result = await _transactionService.UpdateTransactionAsync(transaction, user.Id);
            return Ok(result);
        }
    }
}
