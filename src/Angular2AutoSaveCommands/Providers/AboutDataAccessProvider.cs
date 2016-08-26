using System;
using System.Linq;
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
            _context.AboutData.Add(aboutData);
        }

        public void DeleteAboutData(AboutData aboutData)
        {
            var entity = _context.AboutData.First(t => t.Id == aboutData.Id);
            entity.Deleted = true;
        }

        public void UpdateAboutData(AboutData aboutData)
        {
            var entity = _context.AboutData.First(t => t.Id == aboutData.Id);
            entity.Description = aboutData.Description;
            entity.Deleted = aboutData.Deleted;
        }
    }
}
