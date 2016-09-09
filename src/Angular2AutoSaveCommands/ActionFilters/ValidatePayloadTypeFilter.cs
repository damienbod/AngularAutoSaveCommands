using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Angular2AutoSaveCommands.ActionFilters
{
    public class ValidatePayloadTypeFilter : ActionFilterAttribute
    {
        private readonly ILogger _logger;

        public ValidatePayloadTypeFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("ValidatePayloadTypeFilter");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogWarning("ClassFilter OnActionExecuting");
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
