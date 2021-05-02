using Validator.Shared.Commands;

namespace Validator.Domain.Commands
{
    public class ValidatePasswordCommand : ICommand
    {
        public ValidatePasswordCommand(string password) : this()
        {
            Password = password;
        }
        public ValidatePasswordCommand()
        {

        }

        public string Password { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Password);
        }
    }
}