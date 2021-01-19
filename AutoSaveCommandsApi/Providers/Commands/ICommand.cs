using AutoSaveCommandsApi.Models;

namespace AutoSaveCommandsApi.Providers.Commands
{
    public interface ICommand
    {
        void Execute(DomainModelMsSqlServerContext context);
        void UnExecute(DomainModelMsSqlServerContext context);

        CommandDto ActualCommandDtoForNewState(string commandType);
    }
}
