using Angular2AutoSaveCommands.Models;

namespace Angular2AutoSaveCommands.Providers.Commands
{
    public interface ICommand
    {
        void Execute(CommandDto commandDto);
        void UnExecute(CommandDto commandDto);
    }
}
