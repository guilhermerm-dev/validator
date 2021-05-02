namespace Validator.Shared.Commands
{
    public interface ICommandResult
    {
        bool Valid { get; set; }
        string Message { get; set; }
    }
}