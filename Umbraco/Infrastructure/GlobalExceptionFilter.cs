using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using PocApp.Domain.Models;

namespace Umbraco.Infrastructure
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;
        private readonly IHostEnvironment _env;

        public GlobalExceptionFilter(
            ILogger<GlobalExceptionFilter> logger,
            IHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public void OnException(ExceptionContext context)
        {
            var error = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? context.HttpContext.TraceIdentifier,
                Message = context.Exception.Message,
                StackTrace = _env.IsDevelopment() ? context.Exception.StackTrace : null,
                StatusCode = context.Exception switch
                {
                    _ => StatusCodes.Status500InternalServerError
                }
            };

            _logger.LogError(context.Exception,
                "Error {RequestId}: {Message}",
                error.RequestId,
                error.Message);
/*
            if (IsApiRequest(context.HttpContext.Request))
            {
                context.Result = new JsonResult(error)
                {
                    StatusCode = error.StatusCode
                };
            }
            else
            {
                context.Result = new ViewResult
                {
                    ViewName = "ErrorPage",
                    ViewData = new ViewDataDictionary(
                        new EmptyModelMetadataProvider(),
                        new ModelStateDictionary())
                    {
                        Model = error
                    }
                };

                ((ViewResult)context.Result).ViewData["ErrorMessage"] = error.Message;
            }*/
            context.ExceptionHandled = true;

        }

    /*    private bool IsApiRequest(HttpRequest request)
        {
            return request.Headers["Accept"].ToString().Contains("application/json") ||
                   request.Path.StartsWithSegments("/api");
        }*/

    }
}
