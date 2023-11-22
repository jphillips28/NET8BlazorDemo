using NET8BlazorDemo.Entities;

namespace NET8BlazorDemo.Services
{
	public interface IMovieService
	{
		Task<IList<Movie>> GetAllMovies();
	}
}
