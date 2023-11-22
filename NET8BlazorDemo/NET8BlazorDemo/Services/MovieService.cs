using Microsoft.EntityFrameworkCore;
using NET8BlazorDemo.Data;
using NET8BlazorDemo.Entities;

namespace NET8BlazorDemo.Services
{
	public class MovieService : IMovieService
	{
		private readonly NET8BlazorDemoContext _dbContext;

		public MovieService(NET8BlazorDemoContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IList<Movie>> GetAllMovies()
		{
			return await _dbContext.Movies.ToListAsync();
		}
	}
}
