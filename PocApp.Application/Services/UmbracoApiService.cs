using PocApp.Domain.Interfaces;

namespace PocApp.Application.Services
{
    public class UmbracoApiService
    {
        private readonly IUmbracoApiService _productRepository;

        public UmbracoApiService(IUmbracoApiService productRepository)
        {
            _productRepository = productRepository;
        }


        // Add other business logic methods here
    }
}
