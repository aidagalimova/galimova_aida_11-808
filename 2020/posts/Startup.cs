using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace posts
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<BlogEntriesStorage>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			
			app.UseStaticFiles(new StaticFileOptions
			{
				FileProvider = new PhysicalFileProvider(
			Path.Combine(Directory.GetCurrentDirectory(), "Files")),
				RequestPath = "/Files"
			});

			app.UseRouting();
			
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGet("/", new HomeController().GetForm);
				endpoints.MapPost("/Home/AddEntry", new HomeController().AddBlogEntry);
				endpoints.MapGet("/GetPosts", new HomeController().GetPosts);
				endpoints.MapGet("/Remove", new HomeController().RemovePost);
				endpoints.MapGet("/Edit", new HomeController().EditPost);
				endpoints.MapPost("/SavePost", new HomeController().SavePost);
				endpoints.MapPost("/AddComment", new HomeController().AddComment);
			});

		}
	}
}