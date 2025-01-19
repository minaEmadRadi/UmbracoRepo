using Microsoft.AspNetCore.Mvc;
using PocApp.Domain.models.ViewComponentModels;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Umbraco.ViewComponents
{
    [ViewComponent]
    public class HeaderViewComponent : ViewComponent
    {
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;
        public HeaderViewComponent(IUmbracoContextAccessor umbracoContextAccessor)
        {
            _umbracoContextAccessor = umbracoContextAccessor;
        }
        public IViewComponentResult Invoke()
        {
            HeaderView headerView = new();
            try
            {
                var umbracoContext = _umbracoContextAccessor.GetRequiredUmbracoContext()?.PublishedRequest?.PublishedContent;
                var categories = umbracoContext?.AncestorOrSelf<BlogItem>()?.Categories?.AncestorOrSelf<CategoryItem>();

                if (umbracoContext != null)
                {
                    headerView.Title = umbracoContext.Value<string>("title");
                    headerView.SubTitle = umbracoContext.Value<string>("subtitle");
                    headerView.ImageUrl = umbracoContext.Value<IPublishedContent>("headerImage")?.Url();
                    headerView.IsBlog = umbracoContext.IsDocumentType("blogItem");
                    headerView.CreatedBy = umbracoContext.CreatorName();
                    headerView.AuthorUrl = string.Empty;
                    headerView.CreatedDate = umbracoContext.CreateDate.ToString("D");
                    headerView.Category = categories != null ? categories.CategoryName : string.Empty;
                    return View(headerView);
                }
                else
                {
                    return View(headerView);
                }
            }
            catch
            {
                throw;
            }

        }
    }
}
