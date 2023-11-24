using Microsoft.EntityFrameworkCore;
using NET8BlazorDemo.Data.Entities;

namespace NET8BlazorDemo.Data.DbContexts
{
	public class NET8BlazorDemoContext : DbContext
	{
		public NET8BlazorDemoContext(DbContextOptions<NET8BlazorDemoContext> options)
			: base(options) { }

		public DbSet<Movie> Movies { get; set; }
	}
}
