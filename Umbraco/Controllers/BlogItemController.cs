﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;


namespace Umbraco.Controllers
{

    public class BlogItemController : RenderController
    {

        private readonly IPublishedContentQuery _publishedContentQuery;
        private readonly ILogger<BlogItemController> _logger;
        private readonly IVariationContextAccessor _variationContextAccessor;


        public BlogItemController(IPublishedContentQuery publishedContentQuery, ILogger<BlogItemController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor, IVariationContextAccessor variationContextAccessor, ServiceContext serviceContext)
        : base(logger, compositeViewEngine, umbracoContextAccessor)
        {

            _logger = logger;
            _variationContextAccessor = variationContextAccessor;
            _publishedContentQuery = publishedContentQuery;
        }

        public override IActionResult Index()
        {
            var blogItem = CurrentPage;

            return CurrentTemplate(blogItem);
        }







    }

}