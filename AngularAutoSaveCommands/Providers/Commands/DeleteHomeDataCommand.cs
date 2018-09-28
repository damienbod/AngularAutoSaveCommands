using System;
using System.Linq;
using AngularAutoSaveCommands.Models;
using Microsoft.Extensions.Logging;

namespace AngularAutoSaveCommands.Providers.Commands
{
    public class DeleteHomeDataCommand : ICommand
    {
        private readonly ILogger _logger;
        private readonly CommandDto _commandDto;

        public DeleteHomeDataCommand(ILoggerFactory loggerFactory, CommandDto commandDto)
        {
            _logger = loggerFactory.CreateLogger("DeleteHomeDataCommand");
            _commandDto = commandDto;
        }

        public void Execute(DomainModelMsSqlServerContext context)
        {
            var homeData = _commandDto.Payload.ToObject<HomeData>();
            var entity = context.HomeData.First(t => t.Id == homeData.Id);
            entity.Deleted = true;
            _logger.LogDebug("Executed");
        }

        public void UnExecute(DomainModelMsSqlServerContext context)
        {
            var homeData = _commandDto.Payload.ToObject<HomeData>();
            var entity = context.HomeData.First(t => t.Id == homeData.Id);
            entity.Deleted = false;
            _logger.LogDebug("Unexecuted");
        }

        public CommandDto ActualCommandDtoForNewState(string commandType)
        {
            return _commandDto;
        }
    }
}
