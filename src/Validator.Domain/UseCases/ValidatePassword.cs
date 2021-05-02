using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Validator.Domain.ValueObjects;

namespace Validator.Domain.UseCases
{
    public class ValidatePassword
    {
        private readonly ILogger _logger;
        public ValidatePassword(ILogger<ValidatePassword> logger)
        {
            _logger = logger;
        }
        public bool Execute(Password password)
        {
            _logger.LogInformation("Validation password through the Validate Password use case");
            return password.IsValid();
        }
    }
}