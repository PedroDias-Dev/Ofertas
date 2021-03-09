using Ofertas.Comum.Commands;

namespace Ofertas.Comum.Handlers.Contracts
{
    public interface IHandlerCommand<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
