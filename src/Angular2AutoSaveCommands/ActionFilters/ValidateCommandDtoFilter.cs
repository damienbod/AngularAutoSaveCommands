using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Angular2AutoSaveCommands.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

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
            if (commandDto != null)
            {
                _logger.LogDebug("validating PayloadType");

                _logger.LogDebug("validating CommandType");

                var dd = commandDto.PayloadType;
            }

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogWarning("ClassFilter OnActionExecuted");
            base.OnActionExecuted(context);
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            _logger.LogWarning("ClassFilter OnResultExecuting");
            base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            _logger.LogWarning("ClassFilter OnResultExecuted");
            base.OnResultExecuted(context);
        }
    }
}
