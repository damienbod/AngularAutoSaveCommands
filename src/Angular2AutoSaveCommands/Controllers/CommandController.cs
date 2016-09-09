using Angular2AutoSaveCommands.ActionFilters;
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

        [ServiceFilter(typeof(ValidatePayloadTypeFilter))]
        [ServiceFilter(typeof(ValidationCommandTypeFilter))]
        [HttpPost]
        [Route("Execute")]
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

        [HttpPost]
        [Route("Undo")]
        public IActionResult Undo()
        {
            var commandDto = _commandHandler.Undo();
            return Ok(commandDto);
        }

        [HttpPost]
        [Route("Redo")]
        public IActionResult Redo()
        {
            var commandDto = _commandHandler.Redo();
            return Ok(commandDto);
        }

        // TODO
        private bool validateCommandType(CommandDto value)
        {
            return true;
        }

        // TODO
        private bool validatePayloadType(CommandDto value)
        {
            return true;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_commandHandler.GetAll());          
        }
    }
}
