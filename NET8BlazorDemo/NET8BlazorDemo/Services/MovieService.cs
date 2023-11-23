﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<Movie> CreateMovieAsync(Movie movie)
        {
            // Simulating a long running transaction
            await Task.Delay(2000);

            _dbContext.Movies.Add(movie);
			await _dbContext.SaveChangesAsync();

			return movie;
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            // Simulating a long running transaction
            await Task.Delay(2000);

            var dbMovie = await _dbContext.Movies.Where(m => m.Id == id)
                .SingleOrDefaultAsync()
                ?? throw new KeyNotFoundException($"A movie with id:{id} was not found.");

            _dbContext.Remove(dbMovie);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IList<Movie>> GetAllMoviesAsync()
		{
			// Simulating a long running transaction
			await Task.Delay(2000);

			return await _dbContext.Movies.ToListAsync();
		}

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            // Simulating a long running transaction
            await Task.Delay(2000);

            return await _dbContext.Movies.Where(m =>  m.Id == id)
                .SingleOrDefaultAsync() 
                ?? throw new KeyNotFoundException($"A movie with id:{id} was not found.");
        }

        public async Task<Movie> UpdateMovieAsync(Movie movie)
        {
            // Simulating a long running transaction
            await Task.Delay(2000);

            var dbMovie = await _dbContext.Movies.Where(m => m.Id == movie.Id)
                .SingleOrDefaultAsync()
                ?? throw new KeyNotFoundException($"A movie with id:{movie.Id} was not found.");

            dbMovie.Name = movie.Name;
            await _dbContext.SaveChangesAsync();

            return dbMovie;
        }
    }
}
