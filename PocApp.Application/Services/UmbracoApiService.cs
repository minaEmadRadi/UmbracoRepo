using System.Text.Json;
using Microsoft.Extensions.Logging;
using PocApp.Domain.Interfaces;
namespace PocApp.Application.Services
{
    public class UmbracoApiService : IUmbracoApiService
    {
        private readonly ILogger<UmbracoApiService> _logger;

        public UmbracoApiService( ILogger<UmbracoApiService> logger)
        {
            _logger = logger;
        }

    }
}
