using harmonee.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace harmonee.Server.Data
{
	public class FamilyContext : DbContext
	{ 
		public DbSet<FamilyRecord> Families { get; set; }
		public DbSet<FamilyMember> FamilyMembers { get; set; }
		public DbSet<FamilyEvent> FamilyEvents { get; set; }
		public DbSet<FamilyList> FamilyLists { get; set; }
		//private readonly string _connectionString;

		public FamilyContext(DbContextOptions options) : base(options)
		{
		}

		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	// Use appropriate server and connection string
		//	optionsBuilder.UseSqlServer(_connectionString);
		//	base.OnConfiguring(optionsBuilder);
		//}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// DB Config
			modelBuilder.Entity<FamilyMember>().HasKey(fm => new { fm.FamilyId, fm.UserId });
		}
	}
}
