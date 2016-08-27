using System;
using System.Linq;
using Angular2AutoSaveCommands.Models;
using Microsoft.Extensions.Logging;

namespace Angular2AutoSaveCommands.Providers.Commands
{
    public class AddHomeDataCommand : ICommand
    {
        private readonly DomainModelMsSqlServerContext _context;
        private readonly ILogger _logger;
        private readonly CommandDto _commandDto;

        public AddHomeDataCommand(DomainModelMsSqlServerContext context, ILoggerFactory loggerFactory, CommandDto commandDto)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("AddHomeDataCommand");
            _commandDto = commandDto;
        }

        public void Execute()
        {
            var homeData = _commandDto.Payload.ToObject<HomeData>();
            _context.HomeData.Add(homeData);
            _logger.LogDebug("Executed");
        }

        public void UnExecute()
        {
            var homeData = _commandDto.Payload.ToObject<HomeData>();
            var entity = _context.HomeData.First(t => t.Id == homeData.Id);
            entity.Deleted = true;
            _logger.LogDebug("Unexecuted");
        }
    }
}
