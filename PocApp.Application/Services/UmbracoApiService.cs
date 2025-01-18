using System.Text.Json;
using Microsoft.Extensions.Logging;
using PocApp.Domain.Interfaces;
using PocApp.Domain.Models;
using PocApp.Domain.Models.ViewComponentModels;
namespace PocApp.Application.Services
{
    public class UmbracoApiService : IUmbracoApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<UmbracoApiService> _logger;

        public UmbracoApiService(HttpClient httpClient, ILogger<UmbracoApiService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<BlogsView>> GetContentChildrenByIdAsync(string alias)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/v2/content?fetch=Children:{alias}");
                response.EnsureSuccessStatusCode();

                var jsonString = await response.Content.ReadAsStringAsync();
                var umbracoBlogResponse = JsonSerializer.Deserialize<UmbracoBlogResponse>(jsonString);

                return umbracoBlogResponse?.Items.Select(x => UmbracoContentMapper.MapToBlogView(x)).ToList();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Failed to fetch Umbraco content for contentId: {ContentId}", alias);
                throw new Exception("Failed to fetch Umbraco content", ex);
            }
        }
    }
}
