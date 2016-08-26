using System;
using Angular2AutoSaveCommands.Models;
using Microsoft.Extensions.Logging;

namespace Angular2AutoSaveCommands.Providers
{
    public class HomeDataAccessProvider : IHomeDataAccessProvider
    {
        private readonly DomainModelMsSqlServerContext _context;
        private readonly ILogger _logger;

        public HomeDataAccessProvider(DomainModelMsSqlServerContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("DataAccessMsSqlServerProvider");
        }

        public void AddHomeData(AboutData aboutData)
        {
            throw new NotImplementedException();
        }

        public void DeleteHomeData(AboutData aboutData)
        {
            throw new NotImplementedException();
        }

        public void UpdateHometData(AboutData aboutData)
        {
            throw new NotImplementedException();
        }
    }
}
