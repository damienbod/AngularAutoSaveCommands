using System;
using Angular2AutoSaveCommands.Models;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Angular2AutoSaveCommands.Providers
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

            //var lastAdded = _context.CommandEntity
            //           .OrderByDescending(p => p.Id)
            //           .FirstOrDefault();

            //if (lastAdded != null && lastAdded.Id != ActiveCommand)
            //{
            //    var itemsToDelete = _context.CommandEntity.Where(s => s.Id > 0);
            //    _context.CommandEntity.RemoveRange(itemsToDelete);
            //}

            _context.Add(command);
        }

        public void Redo()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
