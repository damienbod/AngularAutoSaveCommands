using System.Collections.Generic;
using Angular2AutoSaveCommands.Models;

namespace AngularAutoSaveCommands.Providers
{
    public interface ICommandHandler 
    {
        void Execute(CommandDto commandDto);
        CommandDto Undo();
        CommandDto Redo();

        List<CommandEntity> GetAll();
    }
}
