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
        private const int DefaultPageSize = 10;
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
        public IActionResult Index()
        {
            var paginatedList = GetPaginatedBlogs(1, 2);
            SetViewBag(paginatedList, 1);
            return View("~/Views/Partials/_BlogList.cshtml", paginatedList);
        }

        public IActionResult Index(int page = 1, int pageSize = DefaultPageSize)
        {
            var paginatedList = GetPaginatedBlogs(page, pageSize);
            SetViewBag(paginatedList, page);
            return View("~/Views/Partials/_BlogList.cshtml", paginatedList);
        }
        private PaginatedList<BlogsView> GetPaginatedBlogs(int page = 1, int pageSize = DefaultPageSize)
        {
            var allBlogItems = _publishedContentQuery?
                .Content(BlogListNodeId)?
                .ChildrenOfType("blogItem")?
                .Where(x => x.IsVisible())?
                .OrderByDescending(x => x.CreateDate);

            if (allBlogItems == null) return new PaginatedList<BlogsView>(new List<BlogsView>(), 0, page, pageSize);

            var totalItems = allBlogItems.Count();

            var paginatedItems = allBlogItems
                .Select(content => new BlogsView
                {
                    Title = content.Value<string>("title") ?? string.Empty,
                    SubTitle = content.Value<string>("subtitle") ?? string.Empty,
                    BlogBody = content.Value<string>("bodyText") ?? string.Empty,
                    BlogUrl = content.Url() ?? string.Empty,
                    CreatedDate = content.CreateDate.ToString("D"),
                    PublishDate = content.Value<DateTime>("creationDate").ToString("D"),
                    Category = content.Value<IEnumerable<IPublishedContent>>("categories")?
                        .FirstOrDefault()?
                        .Value<string>("name") ?? string.Empty,
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
