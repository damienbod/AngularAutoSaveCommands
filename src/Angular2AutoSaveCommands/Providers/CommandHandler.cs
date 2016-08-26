using System;
using Angular2AutoSaveCommands.Models;

namespace Angular2AutoSaveCommands.Providers
{
    public class CommandHandler : ICommandHandler
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public CommandHandler(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        public void Execute(CommandDto commandDto)
        {
            throw new NotImplementedException();
        }
    }
}
