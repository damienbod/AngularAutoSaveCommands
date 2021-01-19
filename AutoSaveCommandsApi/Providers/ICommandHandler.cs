using System.Collections.Generic;
using AutoSaveCommandsApi.Models;

namespace AutoSaveCommandsApi.Providers
{
    public interface ICommandHandler 
    {
        void Execute(CommandDto commandDto);
        CommandDto Undo();
        CommandDto Redo();

        List<CommandEntity> GetAll();
    }
}
