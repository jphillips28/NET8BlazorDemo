using NET8BlazorDemo.Shared.Entities;
using NET8BlazorDemo.Shared.Services;
using System.Net.Http.Json;

namespace NET8BlazorDemo.Client.Services
{
	public class MovieService : IMovieService
	{
		private readonly HttpClient _httpClient;

		public MovieService()
		{
			_httpClient = new HttpClient
			{
				BaseAddress = new Uri("https://localhost:5001")
			};
		}

		public async Task<Movie> CreateMovieAsync(Movie movie)
		{
			var response = await _httpClient.PostAsJsonAsync("/api/movies", movie);
			if (response.IsSuccessStatusCode)
			{
                return await response.Content.ReadFromJsonAsync<Movie>();
            }

			throw await HandleApiException(response);
        }

		public async Task<bool> DeleteMovieAsync(int id)
		{
			var response = await _httpClient.DeleteAsync($"/api/movies/{id}");
			if (response.IsSuccessStatusCode)
			{
                return await response.Content.ReadFromJsonAsync<bool>();
            }

            throw await HandleApiException(response);
        }

        public async Task<IList<Movie>> GetAllMoviesAsync()
		{
			var response = await _httpClient.GetAsync("/api/movies");
			if (response.IsSuccessStatusCode)
			{
                return await response.Content.ReadFromJsonAsync<IList<Movie>>();
            }

            throw await HandleApiException(response);
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
		{
			var response = await _httpClient.GetAsync($"/api/movies/{id}");
			if (response.IsSuccessStatusCode)
			{
                return await response.Content.ReadFromJsonAsync<Movie>();
            }

            throw await HandleApiException(response);
        }

        public async Task<Movie> UpdateMovieAsync(Movie movie)
		{
			var response = await _httpClient.PutAsJsonAsync("/api/movies", movie);
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
