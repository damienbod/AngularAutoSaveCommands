using Angular2AutoSaveCommands.Models;

namespace Angular2AutoSaveCommands.Providers
{
    public interface ICommandHandler 
    {
        void Execute(CommandDto commandDto);
        CommandDto Undo();
        CommandDto Redo();
    }
}
