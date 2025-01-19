using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using PocApp.Application.Services;
using PocApp.Domain.Interfaces;
using PocApp.Domain.Models;
using Umbraco.Cms.Web.Website.Controllers;
using Umbraco.Controllers;
using Umbraco.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
builder.Services.Configure<UmbracoConfig>(configuration.GetSection("Umbraco"));
builder.Services.AddScoped<IUmbracoApiService, UmbracoApiService>();

builder.Services.AddHttpClient<IUmbracoApiService>((serviceProvider, client) =>
{
    var config = serviceProvider.GetRequiredService<IOptions<UmbracoConfig>>().Value;

    client.BaseAddress = new Uri("https://localhost:44355/umbraco/delivery/api/v2/content");
    if (!config.CMS.DeliveryApi.PublicAccess)
    {
        client.DefaultRequestHeaders.Add("Api-Key", config.CMS.DeliveryApi.ApiKey);
    }
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});

builder.Services.Configure<UmbracoRenderingDefaultsOptions>(c =>
{
    c.DefaultControllerType = typeof(BlogListController);
});
builder.CreateUmbracoBuilder()
   .AddBackOffice()
   .AddWebsite()
   .AddDeliveryApi()
.AddComposers()
   .Build();
builder.Services.AddTransient<LanguageController>();

WebApplication app = builder.Build();

await app.BootUmbracoAsync();

app.UseUmbraco()
   .WithMiddleware(u =>
   {
       u.UseBackOffice();
       u.UseWebsite();
   })
   .WithEndpoints(u =>
   {
       u.UseInstallerEndpoints();
       u.UseBackOfficeEndpoints();
       u.UseWebsiteEndpoints();
   });



await app.RunAsync();