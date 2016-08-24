using Angular2AutoSaveCommands.Models;
using Microsoft.AspNetCore.Mvc;

namespace Angular2AutoSaveCommands.Controllers
{
    [Route("api/[controller]")]
    public class CommandController<T> : Controller where T : class
    {
        [HttpPost]
        public IActionResult Post([FromBody]CommandDto<T> value)
        {
            return new CreatedAtRouteResult("anyroute", null);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CommandDto<T> value)
        {
            return new OkResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return new NoContentResult();
        }
    }
}
