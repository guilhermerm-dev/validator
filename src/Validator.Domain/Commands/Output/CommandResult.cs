using Validator.Shared.Commands;

namespace Validator.Domain.Commands.Output
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(bool valid, string message)
        {
            Valid = valid;
            Message = message;
        }

        public bool Valid { get; set; }
        public string Message { get; set; }
    }
}