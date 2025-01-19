using Microsoft.AspNetCore.Mvc;
using PocApp.Domain.models.PaginatedList;
using PocApp.Domain.models.ViewComponentModels;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Umbraco.ViewComponents
{
    [ViewComponent]
    public class BlogsViewComponent : ViewComponent
    {
        private readonly UmbracoHelper umbracoHelper;
        public BlogsViewComponent(UmbracoHelper umbracoHelper)
        {
            this.umbracoHelper = umbracoHelper;
        }
        public IViewComponentResult Invoke(int? page = 0)
        {
            List<BlogsView> blogs = new List<BlogsView>();
            int pageSize = 1;

            try
            {
                var Content = umbracoHelper?.ContentAtRoot()?.FirstOrDefault(x => x.IsDocumentType("home"))?
                    .Children()?.FirstOrDefault(x => x.IsDocumentType("blogList")) as BlogList;
                if (Content == null) { return View(); }
                foreach (BlogItem blogNode in Content?.Children ?? new List<BlogItem>())
                {
                    var categories = blogNode.Categories.AncestorOrSelf<CategoryItem>();
                    BlogsView blog = new();
                    if (categories != null)
                    {
                        blog.Category = categories.CategoryName;
                    }
                    blog.Title = blogNode.Title;
                    blog.SubTitle = blogNode.Subtitle;
                    blog.BlogUrl = blogNode.Url();
                    blog.CreatedBy = blogNode.CreatorName();
                    blog.AuthorUrl = string.Empty;
                    blog.CreatedDate = blogNode.CreateDate.ToString("D");
                    blogs.Add(blog);
                }
            }
            catch
            {
            }
            var paginatedList = PaginatedList<BlogsView>.Create(blogs.AsQueryable(), page ?? 1, pageSize);

            // Pass the current page and total pages to the view
            ViewBag.CurrentPage = paginatedList.PageIndex;
            ViewBag.TotalPages = paginatedList.TotalPages;

            return View(paginatedList);

        }
    }
}
