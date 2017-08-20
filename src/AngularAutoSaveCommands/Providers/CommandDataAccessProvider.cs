using System;
using Angular2AutoSaveCommands.Models;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace AngularAutoSaveCommands.Providers
{
    public class CommandDataAccessProvider : ICommandDataAccessProvider
    {
        public static long ActiveCommand = 0;
        private readonly DomainModelMsSqlServerContext _context;
        private readonly ILogger _logger;

        public CommandDataAccessProvider(DomainModelMsSqlServerContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("DataAccessMsSqlServerProvider");
        }

        public void AddCommand(CommandEntity command)
        {
            _context.CommandEntity.Add(command);
            _context.Add(command);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
