using Angular2AutoSaveCommands.Models;
using Angular2AutoSaveCommands.Providers;
using Microsoft.AspNetCore.Mvc;

namespace Angular2AutoSaveCommands.Controllers
{
    [Route("api/[controller]")]
    public class CommandController : Controller
    {
        private readonly ICommandHandler _commandHandler;
        public CommandController(ICommandHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }

        [HttpPost]
        public IActionResult Post([FromBody]CommandDto value)
        {
            _commandHandler.Execute(value);
            return Ok(value);
        }

    }
}
