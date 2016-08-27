using System;
using System.Linq;
using Angular2AutoSaveCommands.Models;
using Microsoft.Extensions.Logging;

namespace Angular2AutoSaveCommands.Providers.Commands
{
    public class UpdateHomeDataCommand : ICommand
    {
        private readonly DomainModelMsSqlServerContext _context;
        private readonly ILogger _logger;
        private readonly CommandDto _commandDto;
        private HomeData _previousHometData;

        public UpdateHomeDataCommand(DomainModelMsSqlServerContext context, ILoggerFactory loggerFactory, CommandDto commandDto)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("UpdateHomeDataCommand");
            _commandDto = commandDto;
        }

        public void Execute()
        {
            _previousHometData = new HomeData();

            var homeData = _commandDto.Payload.ToObject<HomeData>();
            var entity = _context.HomeData.First(t => t.Id == homeData.Id);

            _previousHometData.Name = entity.Name;
            _previousHometData.Deleted = entity.Deleted;

            entity.Name = homeData.Name;
            entity.Deleted = homeData.Deleted;
            _logger.LogDebug("Executed");
        }

        public void UnExecute()
        {
            var homeData = _commandDto.Payload.ToObject<HomeData>();
            var entity = _context.HomeData.First(t => t.Id == homeData.Id);
            entity.Name = _previousHometData.Name;
            entity.Deleted = _previousHometData.Deleted;
            _logger.LogDebug("Unexecuted");
        }
    }
}
