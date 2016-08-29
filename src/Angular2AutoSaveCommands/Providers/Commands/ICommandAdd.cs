using Angular2AutoSaveCommands.Models;

namespace Angular2AutoSaveCommands.Providers.Commands
{
    public interface ICommandAdd : ICommand
    {
        void UpdateIdforNewItems();
    }
}
