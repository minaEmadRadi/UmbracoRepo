using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace Umbraco.Controllers
{
    public class LanguageController : SurfaceController
    {
        private readonly IVariationContextAccessor _variationContextAccessor;

        public LanguageController(
            IVariationContextAccessor variationContextAccessor,
            IUmbracoContextAccessor umbracoContextAccessor,
            IPublishedUrlProvider publishedUrlProvider,
            IUmbracoDatabaseFactory databaseFactory,
            ServiceContext serviceContext,
            AppCaches appCaches,
            IProfilingLogger logger)
            : base(umbracoContextAccessor, databaseFactory, serviceContext, appCaches, logger, publishedUrlProvider)
        {
            _variationContextAccessor = variationContextAccessor;
        }

        [HttpGet]
        public IActionResult SetCulture(string culture, string returnUrl)
        {
            _variationContextAccessor.VariationContext = new VariationContext(culture);
            return Redirect(returnUrl);
        }
    }
}
