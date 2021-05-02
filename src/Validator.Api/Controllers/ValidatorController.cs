using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Validator.Domain.Commands;
using Validator.Domain.Handlers;
using Validator.Shared.Commands;

namespace Validator.Api
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ValidatorController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ValidatorHandler _validatorHandler;
        public ValidatorController(ValidatorHandler validatorHandler, ILogger<ValidatorController> logger)
        {
            _validatorHandler = validatorHandler;
            _logger = logger;
        }

        [HttpPost("Password/Validate")]
        public ActionResult<ICommandResult> Validate([FromBody] ValidatePasswordCommand command)
        {
            _logger.LogInformation("Starting to validate password");
            return Ok(_validatorHandler.Handle(command));
        }
    }
}