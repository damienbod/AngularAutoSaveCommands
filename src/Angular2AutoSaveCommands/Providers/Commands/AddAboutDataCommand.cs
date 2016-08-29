using System;
using System.Linq;
using Angular2AutoSaveCommands.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Angular2AutoSaveCommands.Providers.Commands
{
    public class AddAboutDataCommand : ICommandAdd
    {
        private readonly ILogger _logger;
        private readonly CommandDto _commandDto;
        private AboutData _aboutData;

        public AddAboutDataCommand(ILoggerFactory loggerFactory, CommandDto commandDto)
        {
            _logger = loggerFactory.CreateLogger("AddAboutDataCommand");
            _commandDto = commandDto;
        }

        public void Execute(DomainModelMsSqlServerContext context)
        {
            _aboutData = _commandDto.Payload.ToObject<AboutData>();
            if(_aboutData.Id > 0)
            {
                _aboutData.Deleted = false;
                context.AboutData.Update(_aboutData);
            }
            else
            {
                context.AboutData.Add(_aboutData);
            }
            
            _logger.LogDebug("Executed");
        }

        public void UnExecute(DomainModelMsSqlServerContext context)
        {
            _aboutData = _commandDto.Payload.ToObject<AboutData>();
            _aboutData.Deleted = true;
            var entity = context.AboutData.First(t => t.Id == _aboutData.Id);
            entity.Deleted = true;
            _logger.LogDebug("Unexecuted");
        }

        public void UpdateIdforNewItems()
        {
            _commandDto.Payload = JObject.FromObject(_aboutData);
        }

        public CommandDto ActualCommandDtoForNewState(string commandType)
        {
            var aboutData = _commandDto.Payload.ToObject<AboutData>();
            var commandDto = new CommandDto();
            commandDto.ActualClientRoute = _commandDto.ActualClientRoute;
            commandDto.CommandType = _commandDto.CommandType;
            commandDto.PayloadType = _commandDto.PayloadType;
            aboutData.Deleted = _aboutData.Deleted;

            commandDto.Payload = JObject.FromObject(aboutData);
            return commandDto;

        }
    }
}
