# Umbraco CMS Blog Portal


## About The Project

**Umbraco_CMS_BlogPortal** is a modern blogging platform built on **Umbraco CMS**, offering a flexible and customizable experience for content creators.

### Features
* **Localization Support**: Available in **English** and **Arabic**.
* **Content Delivery API**: Seamlessly integrate content into any front-end application.
* **Image Cropping**: Optimize and crop images dynamically within Umbraco.
* **User-friendly CMS**: Easily manage blog posts, categories, and tags.
* **SEO Optimization**: Built-in SEO-friendly URL structure.
* **Responsive Design**: Fully optimized for mobile and desktop.

### Coming Soon
* **Advanced Analytics Dashboard**
* **Customizable Themes**
* **Social Media Integration**
* **Multi-user Role Management**

### Built With
* [Umbraco CMS](https://umbraco.com/)
* [.NET](https://dotnet.microsoft.com/)
* [SQL Server](https://www.microsoft.com/en-us/sql-server)
* [Angular](https://angular.io/) (for front-end integration)

## Getting Started

### Installation
1. Clone the repository:
   ```sh
   git clone https://github.com/minaEmadRadi/UmbracoRepo.git
   ```
2. Navigate to the project folder:
   ```sh
   cd UmbracoRepo
   ```
3. Install dependencies:
   ```sh
   dotnet restore
   ```
4. Set up the database and configure **Umbraco** settings.
dotnet new install Umbraco.Templates::13.6.0-rc --force

dotnet new sln --name "POC"
dotnet new umbraco --force -n "Umbraco" --friendly-name "Administrator" --email "admin@example.com" --password "1234567890" --connection-string "server=(localdb)\MSSQLLocalDB;database=umbracoPOC;user id=umbraco;password=umbraco;TrustServerCertificate=true;" --connection-string-provider-name "Microsoft.Data.SqlClient"
dotnet sln add "Umbraco"

#Add starter kit
dotnet add "Umbraco" package clean --version 4.1.0

dotnet run --project "Umbraco"
#Running


"Runtomtime":{
	"Mode":"development"
},
"ModelsBuilder":{
	"ModelsMode":"SourceCodeAuto"
}

### Development Server
Run the following command to start the development server:
```sh
   dotnet run
```
Navigate to `http://localhost:5000/` in your browser to access the blog portal.


## Contact
Project Link: [https://github.com/minaEmadRadi/UmbracoRepo](https://github.com/minaEmadRadi/UmbracoRepo)


## Further Help
For more details, visit the [Umbraco Documentation](https://our.umbraco.com/documentation/).

