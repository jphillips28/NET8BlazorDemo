using Microsoft.EntityFrameworkCore;
using NET8BlazorDemo.Client.Pages;
using NET8BlazorDemo.Components;
using NET8BlazorDemo.Data;
using NET8BlazorDemo.Services;

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

			builder.Services.AddDbContext<NET8BlazorDemoContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("NET8BlazorDemoDb")));

            builder.Services.AddScoped<IMovieService, MovieService>();

            var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseWebAssemblyDebugging();
				using (var scope = app.Services.CreateScope())
				{
					var dbContext = scope.ServiceProvider.GetRequiredService<NET8BlazorDemoContext>();
					if (dbContext.Database.GetPendingMigrations().Any())
					{
						dbContext.Database.Migrate();
					}
				}
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
