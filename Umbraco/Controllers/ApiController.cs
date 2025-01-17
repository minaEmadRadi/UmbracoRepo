using Microsoft.AspNetCore.Mvc;
using Umbraco.App_Code.Models.ViewComponentModels;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.Common.Controllers;


namespace Umbraco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : UmbracoApiController
    {
        private readonly IContentService _contentService;
        private readonly IUrlProvider _urlProvider;
        private readonly IUserService _userService;
        private readonly IPublishedContentQuery _publishedContentQuery;


        public ApiController(
            IContentService contentService,
            IUrlProvider urlProvider,
            IUserService userService,
    IPublishedContentQuery publishedContentQuery)
        {
            _contentService = contentService;
            _urlProvider = urlProvider;
            _userService = userService;
            _publishedContentQuery = publishedContentQuery;

        }
        [HttpGet]
        public IActionResult GetPagedItems(int page = 1, int pageSize = 10)
        {
            long totalRecords;

            var items = _contentService.GetPagedChildren(
                id: 1103,
                pageIndex: page - 1,
                pageSize: pageSize,
                totalRecords: out totalRecords
            )
            .Select(item => new BlogsView
            {

                Id = item.Id,
                Title = item.GetValue<string>("title"),
                SubTitle = item.GetValue<string>("Subtitle"),
                BlogUrl = GetUrlString(_publishedContentQuery.Content(item.Id)),
                CreatedBy = _userService.GetUserById(item.CreatorId)?.Name,
                CreatedDate = item.CreateDate.ToString("D"),
                Category = GetCategory(item)
            });

            var result = new PaginatedResult<dynamic>
            {
                Items = items,
                CurrentPage = page,
                PageSize = pageSize,
                TotalItems = (int)totalRecords,
                TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize)
            };

            return Ok(result);
        }
        private string GetCategory(IContent content)
        {
            var categoryId = content.GetValue<int?>("categoryId");
            if (categoryId.HasValue)
            {
                var categoryContent = _contentService.GetById(categoryId.Value);
                return categoryContent?.GetValue<string>("categoryName");
            }
            return null;
        }
        private string GetUrlString(IPublishedContent content)
        {
            if (content == null) return null;

            var urlInfo = _urlProvider.GetUrl(
                content,
                UrlMode.Absolute,
                culture: null,
                current: null
            );

            return urlInfo?.Text;
        }
    }
    public class PaginatedResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
    }
}