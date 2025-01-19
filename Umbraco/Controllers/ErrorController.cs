using Microsoft.AspNetCore.Mvc;
using PocApp.Domain.Models;

namespace Umbraco.Controllers
{
    public class ErrorController : Controller
    {

        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var error = new ErrorViewModel
            {
                StatusCode = statusCode,
                Title = GetErrorTitle(statusCode),
                Message = GetErrorMessage(statusCode)
            };

            _logger.LogError("HTTP Error {StatusCode}: {Message}", statusCode, error.Message);

            return View("_ErrorPage", error);
        }

        public IActionResult ShowError(string message, string details = null)
        {
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return Json(new { success = false, message, details });
            }

            var error = new ErrorViewModel
            {
                Title = "Error",
                Message = message,
                Details = details
            };

            return View("_ErrorPage", error);
        }

        private string GetErrorTitle(int statusCode) => statusCode switch
        {
            404 => "Page Not Found",
            401 => "Unauthorized",
            403 => "Forbidden",
            500 => "Server Error",
            _ => "Error"
        };

        private string GetErrorMessage(int statusCode) => statusCode switch
        {
            404 => "The page you're looking for doesn't exist.",
            401 => "You must be logged in to access this resource.",
            403 => "You don't have permission to access this resource.",
            500 => "An unexpected error occurred on our server.",
            _ => "An error occurred while processing your request."
        };
    }
}
