using Microsoft.EntityFrameworkCore;
using NET8BlazorDemo.Entities;

namespace NET8BlazorDemo.Data
{
	public class NET8BlazorDemoContext : DbContext
	{
		public NET8BlazorDemoContext(DbContextOptions<NET8BlazorDemoContext> options)
			: base(options) { }

		public DbSet<Movie> Movies { get; set; }
	}
}
