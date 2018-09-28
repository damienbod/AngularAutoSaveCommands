using System;
using System.Linq;
using AngularAutoSaveCommands.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace AngularAutoSaveCommands.Providers.Commands
{
    public class UpdateHomeDataCommand : ICommand
    {
        private readonly ILogger _logger;
        private readonly CommandDto _commandDto;
        private HomeData _previousHomeData;

        public UpdateHomeDataCommand( ILoggerFactory loggerFactory, CommandDto commandDto)
        {
            _logger = loggerFactory.CreateLogger("UpdateHomeDataCommand");
            _commandDto = commandDto;
        }

        public void Execute(DomainModelMsSqlServerContext context)
        {
            _previousHomeData = new HomeData();

            var homeData = _commandDto.Payload.ToObject<HomeData>();
            var entity = context.HomeData.First(t => t.Id == homeData.Id);

            _previousHomeData.Name = entity.Name;
            _previousHomeData.Deleted = entity.Deleted;
            _previousHomeData.Id = entity.Id;

            entity.Name = homeData.Name;
            entity.Deleted = homeData.Deleted;
            _logger.LogDebug("Executed");
        }

        public void UnExecute(DomainModelMsSqlServerContext context)
        {
            var homeData = _commandDto.Payload.ToObject<HomeData>();
            var entity = context.HomeData.First(t => t.Id == homeData.Id);
            entity.Name = _previousHomeData.Name;
            entity.Deleted = _previousHomeData.Deleted;
            _logger.LogDebug("Unexecuted");
        }

        public CommandDto ActualCommandDtoForNewState(string commandType)
        {
            if (commandType == CommandTypes.UNDO)
            {
                var commandDto = new CommandDto();
                commandDto.ActualClientRoute = _commandDto.ActualClientRoute;
                commandDto.CommandType = _commandDto.CommandType;
                commandDto.PayloadType = _commandDto.PayloadType;
                commandDto.Payload = JObject.FromObject(_previousHomeData);
                return commandDto;
            }
            else
            {
                return _commandDto;
            } 
        }
    }
}
