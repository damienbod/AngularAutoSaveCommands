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

        public AddHomeDataCommand(DomainModelMsSqlServerContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("AddHomeDataCommand");
        }

        public void Execute(CommandDto commandDto)
        {
            var homeData = commandDto.Payload.ToObject<HomeData>();
            _context.HomeData.Add(homeData);
            _logger.LogDebug("Executed");
        }

        public void UnExecute(CommandDto commandDto)
        {
            var homeData = commandDto.Payload.ToObject<HomeData>();
            var entity = _context.HomeData.First(t => t.Id == homeData.Id);
            entity.Deleted = true;
            _logger.LogDebug("Unexecuted");
        }
    }
}
