using System;
using System.Linq;
using Angular2AutoSaveCommands.Models;
using Microsoft.Extensions.Logging;

namespace Angular2AutoSaveCommands.Providers.Commands
{
    public class UpdateAboutDataCommand : ICommand
    {
        private readonly DomainModelMsSqlServerContext _context;
        private readonly ILogger _logger;

        public UpdateAboutDataCommand(DomainModelMsSqlServerContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("UpdateAboutDataCommand");
        }

        public void Execute(CommandDto commandDto)
        {
            var aboutData = commandDto.Payload.ToObject<AboutData>();
            var entity = _context.AboutData.First(t => t.Id == aboutData.Id);
            entity.Description = aboutData.Description;
            entity.Deleted = aboutData.Deleted;
            _logger.LogDebug("Executed");
        }

        public void UnExecute(CommandDto commandDto)
        {
            var aboutData = commandDto.Payload.ToObject<AboutData>();
            var entity = _context.AboutData.First(t => t.Id == aboutData.Id);
            entity.Description = aboutData.Description;
            entity.Deleted = aboutData.Deleted;
            _logger.LogDebug("Unexecuted");
        }
    }
}
