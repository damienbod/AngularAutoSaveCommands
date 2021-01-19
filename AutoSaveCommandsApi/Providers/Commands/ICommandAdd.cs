using AutoSaveCommandsApi.Models;

namespace AutoSaveCommandsApi.Providers.Commands
{
    public interface ICommandAdd : ICommand
    {
        void UpdateIdforNewItems();
    }
}
