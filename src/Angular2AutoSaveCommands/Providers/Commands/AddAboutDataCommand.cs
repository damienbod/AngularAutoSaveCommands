using System;
using System.Linq;
using Angular2AutoSaveCommands.Models;
using Microsoft.Extensions.Logging;

namespace Angular2AutoSaveCommands.Providers.Commands
{
    public class AddAboutDataCommand : ICommand
    {
        private readonly DomainModelMsSqlServerContext _context;
        private readonly ILogger _logger;

        public AddAboutDataCommand(DomainModelMsSqlServerContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("AddAboutDataCommand");
        }

        public void Execute(CommandDto commandDto)
        {
            var aboutData = commandDto.Payload.ToObject<AboutData>();
            _context.AboutData.Add(aboutData);
            _logger.LogDebug("Executed");
        }

        public void UnExecute(CommandDto commandDto)
        {
            var aboutData = commandDto.Payload.ToObject<AboutData>();
            var entity = _context.AboutData.First(t => t.Id == aboutData.Id);
            entity.Deleted = true;
            _logger.LogDebug("Unexecuted");
        }
    }
}
