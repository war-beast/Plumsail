using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PlumsailTest.DAL.Entities;

namespace PlumsailTest.DAL
{
	public sealed class ApplicationDataContext : DbContext
	{
		public DbSet<Submission> Submissions { get; set; }

		public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options)
			: base(options)
		{
			Database.EnsureCreated();
		}
	}

	public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationDataContext>
	{
		ApplicationDataContext IDesignTimeDbContextFactory<ApplicationDataContext>.CreateDbContext(string[] args)
		{
			var config = new ConfigurationBuilder()
				.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Etishop"))
				.AddJsonFile("appsettings.json", optional: true).Build();

			var optionsBuilder = new DbContextOptionsBuilder<ApplicationDataContext>();
			optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

			return new ApplicationDataContext(optionsBuilder.Options);
		}
	}
}
