using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Umbraco.Infrastructure
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(
            ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception,
                "Error {RequestId}: {Message}",
                Activity.Current?.Id ?? context.HttpContext.TraceIdentifier,
                context.Exception.Message);

            context.ExceptionHandled = true;

        }

    }
}
