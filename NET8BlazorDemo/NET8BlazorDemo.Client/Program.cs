using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NET8BlazorDemo.Client.Services;
using NET8BlazorDemo.Shared.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<IMovieService, MovieService>();

await builder.Build().RunAsync();
