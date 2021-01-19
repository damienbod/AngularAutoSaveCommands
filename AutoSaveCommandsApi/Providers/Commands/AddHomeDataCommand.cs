using System;
using System.Linq;
using AutoSaveCommandsApi.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace AutoSaveCommandsApi.Providers.Commands
{
    public class AddHomeDataCommand : ICommandAdd
    {
        private readonly ILogger _logger;
        private readonly CommandDto _commandDto;

        private HomeData _homeData;

        public AddHomeDataCommand(ILoggerFactory loggerFactory, CommandDto commandDto)
        {
            _logger = loggerFactory.CreateLogger("AddHomeDataCommand");
            _commandDto = commandDto;
        }

        public void Execute(DomainModelMsSqlServerContext context)
        {
            _homeData = _commandDto.Payload.ToObject<HomeData>();
            if (_homeData.Id > 0)
            {
                _homeData.Deleted = false;
                context.HomeData.Update(_homeData);
            }
            else
            {
                context.HomeData.Add(_homeData);
            }
            
            _logger.LogDebug("Executed");
        }

        public void UnExecute(DomainModelMsSqlServerContext context)
        {
            _homeData = _commandDto.Payload.ToObject<HomeData>();
            var entity = context.HomeData.First(t => t.Id == _homeData.Id);
            entity.Deleted = true;
            _logger.LogDebug("Unexecuted");
        }

        public void UpdateIdforNewItems()
        {
            _commandDto.Payload = JObject.FromObject(_homeData);
        }

        public CommandDto ActualCommandDtoForNewState(string commandType)
        {
            return _commandDto;
        }
    }
}
