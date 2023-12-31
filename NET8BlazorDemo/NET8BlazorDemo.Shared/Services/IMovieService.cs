﻿using NET8BlazorDemo.Shared.Models;

namespace NET8BlazorDemo.Shared.Services
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
