using System;
using System.Linq;
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

        public void AddHomeData(HomeData homeData)
        {
            _context.HomeData.Attach(homeData);
        }

        public void DeleteHomeData(HomeData homeData)
        {
            var entity = _context.HomeData.First(t => t.Id == homeData.Id);
            entity.Deleted = true;
        }

        public void UpdateHomeData(HomeData homeData)
        {
            var entity = _context.HomeData.First(t => t.Id == homeData.Id);
            entity.Name = homeData.Name;
            entity.Deleted = homeData.Deleted;
        }
    }
}
