using AngularAutoSaveCommands.ActionFilters;
using AngularAutoSaveCommands.Models;
using AngularAutoSaveCommands.Providers;
using Microsoft.AspNetCore.Mvc;

namespace AngularAutoSaveCommands.Controllers
{
    [Route("api/[controller]")]
    public class CommandController : Controller
    {
        private readonly ICommandHandler _commandHandler;
        public CommandController(ICommandHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }

        [ServiceFilter(typeof(ValidateCommandDtoFilter))]
        [HttpPost]
        [Route("Execute")]
        public IActionResult Post([FromBody]CommandDto commandDto)
        {
            _commandHandler.Execute(commandDto);
            return Ok(commandDto);
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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_commandHandler.GetAll());          
        }
    }
}
