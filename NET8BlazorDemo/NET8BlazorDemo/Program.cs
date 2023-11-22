using Microsoft.EntityFrameworkCore;
using NET8BlazorDemo.Client.Pages;
using NET8BlazorDemo.Components;
using NET8BlazorDemo.Data;

namespace NET8BlazorDemo
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorComponents()
				.AddInteractiveServerComponents()
				.AddInteractiveWebAssemblyComponents();

			// DI from docker-compose
			var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
			var dbName = Environment.GetEnvironmentVariable("DB_NAME");
			var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
			var connectionString = $"Server={dbHost};Database={dbName};User Id=sa;Password={dbPassword};TrustServerCertificate=True;";
			builder.Services.AddDbContext<NET8BlazorDemoContext>(options =>
                // TODO: Dockerize 'dotnet ef database update'
				// Uncomment for local dotnet ef db migrations
                //options.UseSqlServer(builder.Configuration.GetConnectionString("NET8BlazorDemoDb")));
                options.UseSqlServer(connectionString));


			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseWebAssemblyDebugging();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();

			app.UseStaticFiles();
			app.UseAntiforgery();

			app.MapRazorComponents<App>()
				.AddInteractiveServerRenderMode()
				.AddInteractiveWebAssemblyRenderMode()
				.AddAdditionalAssemblies(typeof(Counter).Assembly);

			app.Run();
		}
	}
}
