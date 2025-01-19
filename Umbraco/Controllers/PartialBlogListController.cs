using Microsoft.AspNetCore.Mvc;
using PocApp.Domain.models.PaginatedList;
using PocApp.Domain.models.ViewComponentModels;
using Umbraco.Cms.Core;
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
    public class PartialBlogListController : SurfaceController
    {
        private readonly IPublishedContentQuery _publishedContentQuery;
        private const int DefaultPageSize = 1;
        private readonly Guid BlogListNodeId = Guid.Parse("c3284a36-2187-48f7-93ed-6b235668aaa5");
        private readonly ILogger<PartialBlogListController> _logger;

        public PartialBlogListController(
           IUmbracoContextAccessor umbracoContextAccessor,
            IUmbracoDatabaseFactory databaseFactory,
            ServiceContext services,
            AppCaches appCaches,
            IProfilingLogger profilingLogger,
            IPublishedUrlProvider publishedUrlProvider,
            ILogger<PartialBlogListController> logger,
            IPublishedContentQuery publishedContentQuery)
            : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)

        {
            _logger = logger;
            _publishedContentQuery = publishedContentQuery;
        }


        public IActionResult Index(int page = 1, int pageSize = DefaultPageSize, string? currentCulture = "en-Us")
        {
            var paginatedList = GetPaginatedBlogs(page, pageSize, currentCulture);
            SetViewBag(paginatedList, page);
            return PartialView("~/Views/Partials/_BlogList.cshtml", paginatedList);
        }
        private PaginatedList<BlogsView> GetPaginatedBlogs(int page = 1, int pageSize = DefaultPageSize, string? currentCulture = "en-Us")
        {

            var allBlogItems = _publishedContentQuery?
                .Content(BlogListNodeId)?
                .ChildrenOfType("blogItem")?
                .Where(x => x.IsVisible())?
                .OrderByDescending(x => x.CreateDate);
            //throw new Exception();

            if (allBlogItems == null) return new PaginatedList<BlogsView>(new List<BlogsView>(), 0, page, pageSize);

            var totalItems = allBlogItems.Count();

            var paginatedItems = allBlogItems
                .Select(content => new BlogsView
                {
                    Title = content.Value<string>("title", culture: currentCulture) ?? string.Empty,
                    SubTitle = content.Value<string>("subtitle", culture: currentCulture) ?? string.Empty,
                    BlogBody = content.Value<string>("bodyText", culture: currentCulture) ?? string.Empty,
                    BlogUrl = content.Url(culture: currentCulture) ?? string.Empty, // Apply culture to URL
                    CreatedDate = content.CreateDate.ToString("D"), // Apply culture to date formatting
                    PublishDate = content.Value<DateTime>("creationDate", culture: currentCulture).ToString("D"), // Apply culture to date formatting
                    Category = content.Value<IEnumerable<IPublishedContent>>("categories", culture: currentCulture)?
            .FirstOrDefault()?
            .Value<string>("name", culture: currentCulture) ?? string.Empty,
                })
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PaginatedList<BlogsView>(paginatedItems, totalItems, page, pageSize);
        }

        private void SetViewBag(PaginatedList<BlogsView> paginatedList, int page)
        {
            ViewBag.Page = page;
            ViewBag.PrevDisabled = !paginatedList.HasPreviousPage ? "d-none" : "";
            ViewBag.NextDisabled = !paginatedList.HasNextPage ? "d-none" : "";
            ViewBag.TotalPages = paginatedList.TotalPages;
        }
    }
}
