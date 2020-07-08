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
		public DbSet<FieldParameter> FieldParameters { get; set; }	

		public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options)
			: base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Submission>()
				.HasMany<FieldParameter>()
				.WithOne(x => x.Submission)
				.HasForeignKey(x => x.SubmissionId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}

	public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationDataContext>
	{
		ApplicationDataContext IDesignTimeDbContextFactory<ApplicationDataContext>.CreateDbContext(string[] args)
		{
			var config = new ConfigurationBuilder()
				.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../PlumsailTest"))
				.AddJsonFile("appsettings.json", optional: true).Build();

			var optionsBuilder = new DbContextOptionsBuilder<ApplicationDataContext>();
			optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

			return new ApplicationDataContext(optionsBuilder.Options);
		}
	}
}
