using NET8BlazorDemo.Shared.Models;
using NET8BlazorDemo.Shared.Services;
using System.Net.Http.Json;

namespace NET8BlazorDemo.Client.Services
{
	public class MovieService : IMovieService
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public MovieService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<Movie> CreateMovieAsync(Movie movie)
		{
			var httpClient = _httpClientFactory.CreateClient("NET8BlazorDemoWebApi");
			var response = await httpClient.PostAsJsonAsync("/api/movies", movie);
			if (response.IsSuccessStatusCode)
			{
                return await response.Content.ReadFromJsonAsync<Movie>();
            }

			throw await HandleApiException(response);
        }

		public async Task<bool> DeleteMovieAsync(int id)
		{
            var httpClient = _httpClientFactory.CreateClient("NET8BlazorDemoWebApi");
            var response = await httpClient.DeleteAsync($"/api/movies/{id}");
			if (response.IsSuccessStatusCode)
			{
                return await response.Content.ReadFromJsonAsync<bool>();
            }

            throw await HandleApiException(response);
        }

        public async Task<IList<Movie>> GetAllMoviesAsync()
		{
            var httpClient = _httpClientFactory.CreateClient("NET8BlazorDemoWebApi");
            var response = await httpClient.GetAsync("/api/movies");
			if (response.IsSuccessStatusCode)
			{
                return await response.Content.ReadFromJsonAsync<IList<Movie>>();
            }

            throw await HandleApiException(response);
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
		{
            var httpClient = _httpClientFactory.CreateClient("NET8BlazorDemoWebApi");
            var response = await httpClient.GetAsync($"/api/movies/{id}");
			if (response.IsSuccessStatusCode)
			{
                return await response.Content.ReadFromJsonAsync<Movie>();
            }

            throw await HandleApiException(response);
        }

        public async Task<Movie> UpdateMovieAsync(Movie movie)
		{
            var httpClient = _httpClientFactory.CreateClient("NET8BlazorDemoWebApi");
            var response = await httpClient.PutAsJsonAsync("/api/movies", movie);
			if (response.IsSuccessStatusCode)
			{
                return await response.Content.ReadFromJsonAsync<Movie>();
            }

			throw await HandleApiException(response);
        }

		private async Task<Exception> HandleApiException(HttpResponseMessage response)
		{
			return await response.Content.ReadFromJsonAsync<Exception>() ?? new Exception();
        }
	}
}
