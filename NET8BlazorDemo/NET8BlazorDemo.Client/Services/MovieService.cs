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
			return await response.Content.ReadFromJsonAsync<Movie>();
		}

		public async Task<bool> DeleteMovieAsync(int id)
		{
			var response = await _httpClient.DeleteAsync($"/api/movies/{id}");
			return await response.Content.ReadFromJsonAsync<bool>();
		}

		public async Task<IList<Movie>> GetAllMoviesAsync()
		{
			return await _httpClient.GetFromJsonAsync<IList<Movie>>("/api/movies");
		}

		public async Task<Movie> GetMovieByIdAsync(int id)
		{
			return await _httpClient.GetFromJsonAsync<Movie>($"/api/movies/{id}");
		}

		public async Task<Movie> UpdateMovieAsync(Movie movie)
		{
			var reponse = await _httpClient.PutAsJsonAsync("/api/movies", movie);
			return await reponse.Content.ReadFromJsonAsync<Movie>();
		}
	}
}
