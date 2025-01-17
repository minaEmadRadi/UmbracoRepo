﻿namespace PocApp.Domain.Models.ViewComponentModels
{
    public class BlogsView
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string BlogUrl { get; set; }
        public string CreatedBy { get; set; }
        public string AuthorUrl { get; set; }
        public string CreatedDate { get; set; }
        public string Category { get; set; }

    }
}
