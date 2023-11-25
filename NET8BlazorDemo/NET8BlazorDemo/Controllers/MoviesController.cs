using Microsoft.AspNetCore.Mvc;
using NET8BlazorDemo.Shared.Entities;
using NET8BlazorDemo.Shared.Services;

namespace NET8BlazorDemo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		private readonly IMovieService _movieService;

		public MoviesController(IMovieService movieService)
		{
			_movieService = movieService;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Movie>> GetMovieByIdAsync(int id)
		{
			try
			{
				return Ok(await _movieService.GetMovieByIdAsync(id));
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
		}

		[HttpGet]
		public async Task<ActionResult<IList<Movie>>> GetAllMoviesAsync()
		{
			try
			{
				return Ok(await _movieService.GetAllMoviesAsync());
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
		}

		[HttpPost]
		public async Task<ActionResult<Movie>> CreateMovieAsync(Movie movie)
		{
			try
			{
				return Ok(await _movieService.CreateMovieAsync(movie));
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
		}

		[HttpPut]
		public async Task<ActionResult<Movie>> UpdateMovieAsync(Movie movie)
		{
			try
			{
				return Ok(await _movieService.UpdateMovieAsync(movie));
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
		}

		[HttpDelete]
		public async Task<ActionResult<bool>> DeleteMovieAsync(int id)
		{
			try
			{
				return Ok(await _movieService.DeleteMovieAsync(id));
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
		}
	}
}
