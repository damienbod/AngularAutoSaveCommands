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
            if (commandDto == null)
            {
                throw new ArgumentNullException("Body is not a CommandDto");
            }

            _logger.LogDebug("validating CommandType");
            if (!CommandTypes.AllowedTypes.Contains(commandDto.CommandType))
            {
                throw new ArgumentException("CommandTypes not allowed");
            }

            _logger.LogDebug("validating PayloadType");
            if (!PayloadTypes.AllowedTypes.Contains(commandDto.PayloadType))
            {
                throw new ArgumentException("PayloadType not allowed");
            }

            base.OnActionExecuting(context);
        }
    }
}
