using System.Text.Json.Serialization;
using PocApp.Domain.models.ViewComponentModels;

namespace PocApp.Domain.Models
{
    public class UmbracoBlogResponse
    {
        public int Total { get; set; }
        [JsonPropertyName("items")]
        public List<BlogItem> Items { get; set; }
    }

    public class BlogItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Route Route { get; set; }
        public BlogProperties Properties { get; set; }
    }

    public class Route
    {
        public string Path { get; set; }
    }

    public class BlogProperties
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        [JsonPropertyName("bodyText")]
        public BodyText BodyText { get; set; }
        public List<CategoryItem> Categories { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public class BodyText
    {
        public string Markup { get; set; }
    }

    public class CategoryItem
    {
        public string Name { get; set; }
    }
    public static class UmbracoContentMapper
    {
        public static BlogsView MapToBlogView(BlogItem item)
        {
            if (item == null) return null;

            return new BlogsView
            {
                GUId = item.Id,
                Name = item.Name,
                Title = item.Properties?.Title ?? string.Empty,
                SubTitle = item.Properties?.Subtitle ?? string.Empty,
                BlogBody = item.Properties?.BodyText?.Markup ?? string.Empty,
                BlogUrl = item.Route?.Path ?? string.Empty,
                CreatedDate = item.CreateDate.ToString("D"),
                PublishDate = item.Properties?.CreationDate.ToString("D") ?? string.Empty,
                Category = item.Properties?.Categories?.FirstOrDefault()?.Name ?? string.Empty,
                CreatedBy = string.Empty,
                AuthorUrl = string.Empty
            };
        }

    }
}
