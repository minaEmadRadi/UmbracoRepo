using PocApp.Application.Services;
using PocApp.Domain.Interfaces;
using Umbraco.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
builder.Services.AddScoped<IUmbracoApiService, UmbracoApiService>();

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});


builder.CreateUmbracoBuilder()
   .AddBackOffice()
   .AddWebsite()
   .AddDeliveryApi()
   .AddComposers()
   .Build();

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