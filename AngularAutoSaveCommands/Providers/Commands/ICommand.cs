using AngularAutoSaveCommands.Models;

namespace AngularAutoSaveCommands.Providers.Commands
{
    public interface ICommand
    {
        void Execute(DomainModelMsSqlServerContext context);
        void UnExecute(DomainModelMsSqlServerContext context);

        CommandDto ActualCommandDtoForNewState(string commandType);
    }
}
