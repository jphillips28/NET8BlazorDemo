using NET8BlazorDemo.Entities;

namespace NET8BlazorDemo.Services
{
	public interface IMovieService
	{
		Task<Movie> GetMovieByIdAsync(int id);
		Task<IList<Movie>> GetAllMoviesAsync();
		Task<Movie> CreateMovieAsync(Movie movie);
		Task<Movie> UpdateMovieAsync(Movie movie);
		Task<bool> DeleteMovieAsync(int id);
	}
}
