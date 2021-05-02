using System.Threading.Tasks;
using Validator.Shared.Commands;

namespace Validator.Shared.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        ICommandResult Handle(T comand);
    }
}