using Angular2AutoSaveCommands.Models;

namespace Angular2AutoSaveCommands.Providers.Commands
{
    public interface ICommand
    {
        void Execute(DomainModelMsSqlServerContext context);
        void UnExecute(DomainModelMsSqlServerContext context);
    }
}
