using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;


namespace Umbraco.Controllers
{

    public class BlogListController : RenderController
    {

        private readonly IPublishedContentQuery _publishedContentQuery;
        private readonly ILogger<BlogListController> _logger;
        private readonly IVariationContextAccessor _variationContextAccessor;

        public BlogListController(IPublishedContentQuery publishedContentQuery, ILogger<BlogListController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor, IVariationContextAccessor variationContextAccessor, ServiceContext serviceContext)
        : base(logger, compositeViewEngine, umbracoContextAccessor)
        {

            _logger = logger;
            _variationContextAccessor = variationContextAccessor;
            _publishedContentQuery = publishedContentQuery;
        }

        public override IActionResult Index()
        {

            return CurrentTemplate(CurrentPage);
        }






    }

}