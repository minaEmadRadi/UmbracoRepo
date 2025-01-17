namespace PocApp.Domain.Models
{
    public class UmbracoDeliveryApiConfig
    {
        public bool Enabled { get; set; }
        public bool PublicAccess { get; set; }
        public string ApiKey { get; set; }
        public List<string> DisallowedContentTypeAliases { get; set; } = new();
        public bool RichTextOutputAsJson { get; set; }
    }

    public class UmbracoCmsConfig
    {
        public UmbracoDeliveryApiConfig DeliveryApi { get; set; }
    }

    public class UmbracoConfig
    {
        public UmbracoCmsConfig CMS { get; set; }
    }
}
