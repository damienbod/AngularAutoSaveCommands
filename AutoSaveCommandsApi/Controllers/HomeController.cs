using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AutoSaveCommandsApi.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly DomainModelMsSqlServerContext _context;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger _logger;

        public HomeController(DomainModelMsSqlServerContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _loggerFactory = loggerFactory;
            _logger = loggerFactory.CreateLogger("HomeController");
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogDebug("Get all HomeData items called");
            return Ok(_context.HomeData.Where(item => item.Deleted == false).ToList());
        }
    }
}
