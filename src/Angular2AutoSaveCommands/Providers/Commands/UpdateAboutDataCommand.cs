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
        private readonly CommandDto _commandDto;
        private AboutData _previousAboutData;

        public UpdateAboutDataCommand(DomainModelMsSqlServerContext context, ILoggerFactory loggerFactory, CommandDto commandDto)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("UpdateAboutDataCommand");
            _commandDto = commandDto;
        }

        public void Execute()
        {
            _previousAboutData = new AboutData();

            var aboutData = _commandDto.Payload.ToObject<AboutData>();
            var entity = _context.AboutData.First(t => t.Id == aboutData.Id);

            _previousAboutData.Description = entity.Description;
            _previousAboutData.Deleted = entity.Deleted;

            entity.Description = aboutData.Description;
            entity.Deleted = aboutData.Deleted;
            _logger.LogDebug("Executed");
        }

        public void UnExecute()
        {
            var aboutData = _commandDto.Payload.ToObject<AboutData>();
            var entity = _context.AboutData.First(t => t.Id == aboutData.Id);

            entity.Description = _previousAboutData.Description;
            entity.Deleted = _previousAboutData.Deleted;
            _logger.LogDebug("Unexecuted");
        }
    }
}
