using Angular2AutoSaveCommands.Models;
using Angular2AutoSaveCommands.Providers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

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
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is invalid");
            }

            if (!validateCommandType(value))
            {
                return BadRequest($"CommandType: {value.CommandType} is invalid");
            }

            if (!validatePayloadType(value))
            {
                return BadRequest($"PayloadType: {value.CommandType} is invalid");
            }

            _commandHandler.Execute(value);
            return Ok(value);
        }

        private bool validateCommandType(CommandDto value)
        {
            return true;
        }

        private bool validatePayloadType(CommandDto value)
        {
            return true;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var about = new AboutData();
            about.Description = "test data";

            var command = new CommandDto();
            command.ActualClientRoute = "http://daminbod.com";
            command.CommandType = CommandTypes.ADD;
            command.PayloadType = PayloadTypes.ABOUT;
            command.Payload = JObject.FromObject(about);
            return Ok(command);
        }
    }
}
