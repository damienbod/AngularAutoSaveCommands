using System;
using System.Linq;
using AngularAutoSaveCommands.Models;
using Microsoft.Extensions.Logging;

namespace AngularAutoSaveCommands.Providers.Commands
{
    public class DeleteAboutDataCommand : ICommand
    {
        private readonly ILogger _logger;
        private readonly CommandDto _commandDto;

        public DeleteAboutDataCommand(ILoggerFactory loggerFactory, CommandDto commandDto)
        {
            _logger = loggerFactory.CreateLogger("DeleteAboutDataCommand");
            _commandDto = commandDto;
        }

        public void Execute(DomainModelMsSqlServerContext context)
        {
            var aboutData = _commandDto.Payload.ToObject<AboutData>();
            var entity = context.AboutData.First(t => t.Id == aboutData.Id);
            entity.Deleted = true;
            _logger.LogDebug("Executed");
        }

        public void UnExecute(DomainModelMsSqlServerContext context)
        {
            var aboutData = _commandDto.Payload.ToObject<AboutData>();
            var entity = context.AboutData.First(t => t.Id == aboutData.Id);
            entity.Deleted = false;
            _logger.LogDebug("Unexecuted");
        }

        public CommandDto ActualCommandDtoForNewState(string commandType)
        {
            return _commandDto;
        }
    }
}
