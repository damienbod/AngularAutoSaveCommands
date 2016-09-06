using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Angular2AutoSaveCommands.Controllers
{
    [Route("api/[controller]")]
    public class AboutController : Controller
    {
        private readonly DomainModelMsSqlServerContext _context;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger _logger;

        public AboutController(DomainModelMsSqlServerContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _loggerFactory = loggerFactory;
            _logger = loggerFactory.CreateLogger("AboutController");
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogDebug("Get all AboutData items called");
            return Ok(_context.AboutData.Where(item => item.Deleted == false).ToList());
        }
    }
}
