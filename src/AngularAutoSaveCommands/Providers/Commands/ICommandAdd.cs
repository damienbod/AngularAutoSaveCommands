using AngularAutoSaveCommands.Models;

namespace AngularAutoSaveCommands.Providers.Commands
{
    public interface ICommandAdd : ICommand
    {
        void UpdateIdforNewItems();
    }
}
