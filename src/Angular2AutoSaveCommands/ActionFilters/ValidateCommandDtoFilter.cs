using Angular2AutoSaveCommands.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Angular2AutoSaveCommands.ActionFilters
{
    public class ValidateCommandDtoFilter : ActionFilterAttribute
    {
        private readonly ILogger _logger;

        public ValidateCommandDtoFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("ValidatePayloadTypeFilter");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var commandDto = context.ActionArguments["commandDto"] as CommandDto;
            if (commandDto == null)
            {
                context.HttpContext.Response.StatusCode = 400;
                context.Result = new ContentResult()
                {
                    Content = "The body is not a CommandDto type"
                };
                return;
            }

            _logger.LogDebug("validating CommandType");
            if (!CommandTypes.AllowedTypes.Contains(commandDto.CommandType))
            {
                context.HttpContext.Response.StatusCode = 400;
                context.Result = new ContentResult()
                {
                    Content = "CommandTypes not allowed"
                };
                return;
            }

            _logger.LogDebug("validating PayloadType");
            if (!PayloadTypes.AllowedTypes.Contains(commandDto.PayloadType))
            {
                context.HttpContext.Response.StatusCode = 400;
                context.Result = new ContentResult()
                {
                    Content = "PayloadType not allowed"
                };
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
