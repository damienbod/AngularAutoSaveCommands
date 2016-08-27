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

        public UpdateHomeDataCommand(DomainModelMsSqlServerContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("UpdateHomeDataCommand");
        }

        public void Execute(CommandDto commandDto)
        {
            var homeData = commandDto.Payload.ToObject<HomeData>();
            var entity = _context.HomeData.First(t => t.Id == homeData.Id);
            entity.Name = homeData.Name;
            entity.Deleted = homeData.Deleted;
            _logger.LogDebug("Executed");
        }

        public void UnExecute(CommandDto commandDto)
        {
            var homeData = commandDto.Payload.ToObject<HomeData>();
            var entity = _context.HomeData.First(t => t.Id == homeData.Id);
            entity.Name = homeData.Name;
            entity.Deleted = homeData.Deleted;
            _logger.LogDebug("Unexecuted");
        }
    }
}
