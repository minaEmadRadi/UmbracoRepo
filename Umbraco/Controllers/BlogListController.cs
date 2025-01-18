using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;


namespace Umbraco.Controllers
{

    public class BlogListController : RenderController
    {

        private readonly IPublishedContentQuery _publishedContentQuery;
        private readonly ILogger<BlogListController> _logger;
        private readonly IVariationContextAccessor _variationContextAccessor;
        private readonly int pagesize = 1;
        private readonly int page = 1;

        public BlogListController(IPublishedContentQuery publishedContentQuery, ILogger<BlogListController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor, IVariationContextAccessor variationContextAccessor, ServiceContext serviceContext)
        : base(logger, compositeViewEngine, umbracoContextAccessor)
        {

            _logger = logger;
            _variationContextAccessor = variationContextAccessor;
            _publishedContentQuery = publishedContentQuery;
        }

        public override IActionResult Index()
        {

            var content = _publishedContentQuery?.Content(Guid.Parse("c3284a36-2187-48f7-93ed-6b235668aaa5"))
                //?.ChildrenOfType("blogItem")?
                //.Where(x => x.IsVisible())
                //.OrderByDescending(x => x.CreateDate)?
                //.Select(content => new BlogsView
                //{
                //    Title = content?.Value<string>("title")!,
                //    SubTitle = content?.Value<string>("subtitle")!,
                //    BlogBody = content?.Value<string>("bodyText")!,
                //    BlogUrl = content?.Url()!,
                //    CreatedDate = content?.CreateDate.ToString("D")!,
                //    PublishDate = content?.Value<DateTime>("creationDate").ToString("D")!,
                //    Category = content?.Value<IEnumerable<IPublishedContent>>("categories")?
                //   .FirstOrDefault()?
                //   .Value<string>("name") ?? string.Empty,
                //})
                //.Skip((page - 1) * pagesize)
                //.Take(pagesize)
                //.ToList();
                .AncestorOrSelf<BlogList>();



            //ViewBag.page = page;
            return CurrentTemplate(content);
        }

        [HttpGet]
        public IActionResult SetCulture(string culture)
        {
            _variationContextAccessor.VariationContext = new VariationContext(culture);
            return Ok($"Culture set to {culture}");
        }





    }

}