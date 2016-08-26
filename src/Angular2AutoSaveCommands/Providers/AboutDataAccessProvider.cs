using System;
using Angular2AutoSaveCommands.Models;
using Microsoft.Extensions.Logging;

namespace Angular2AutoSaveCommands.Providers
{
    public class AboutDataAccessProvider : IAboutDataAccessProvider
    {
        private readonly DomainModelMsSqlServerContext _context;
        private readonly ILogger _logger;

        public AboutDataAccessProvider(DomainModelMsSqlServerContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("DataAccessMsSqlServerProvider");
        }

        public void AddAboutData(AboutData aboutData)
        {
            throw new NotImplementedException();
        }

        public void DeleteAboutData(AboutData aboutData)
        {
            throw new NotImplementedException();
        }

        public void UpdateAboutData(AboutData aboutData)
        {
            throw new NotImplementedException();
        }
    }
}
