using System;
using Validator.Shared.Commands;
using Validator.Domain.UseCases;
using Validator.Domain.ValueObjects;
using Validator.Domain.Commands.Output;
using Microsoft.Extensions.Logging;
using Validator.Domain.Commands;

namespace Validator.Domain.Handlers
{
    public class ValidatorHandler : ICommandHandler<ValidatePasswordCommand>
    {
        private readonly ILogger _logger;
        private readonly ValidatePassword _validatePassword;

        public ValidatorHandler(ValidatePassword validatePassword, ILogger<ValidatorHandler> logger)
        {
            _validatePassword = validatePassword;
            _logger = logger;
        }

        public ICommandResult Handle(ValidatePasswordCommand command)
        {
            if (command.IsValid())
            {
                _logger.LogInformation("ValidatePasswordCommand is valid - processing command through the command handler");
                Password password = new Password(command.Password);
                bool valid = _validatePassword.Execute(password);
                if (valid)
                {
                    _logger.LogInformation("Password is valid");
                    return new CommandResult(valid, "Password is valid!");
                }
                else
                {
                    _logger.LogInformation("Password isn't valid");
                    return new CommandResult(valid, "Password isn't valid!");
                }
            }
            else
            {
                _logger.LogError("Failed to validate command");
                throw new ArgumentNullException(nameof(command), "Command is null or empty");
            }
        }
    }
}