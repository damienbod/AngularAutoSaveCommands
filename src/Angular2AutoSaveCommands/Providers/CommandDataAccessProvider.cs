using System;
using Angular2AutoSaveCommands.Models;
using Microsoft.Extensions.Logging;

namespace Angular2AutoSaveCommands.Providers
{
    public class CommandDataAccessProvider : ICommandDataAccessProvider
    {
        private readonly DomainModelMsSqlServerContext _context;
        private readonly ILogger _logger;

        public CommandDataAccessProvider(DomainModelMsSqlServerContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("DataAccessMsSqlServerProvider");
        }

        public void AddCommand(CommandEntity command)
        {
            throw new NotImplementedException();
        }

        public void Redo()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
