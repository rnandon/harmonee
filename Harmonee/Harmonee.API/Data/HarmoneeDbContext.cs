using Harmonee.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Harmonee.API.Data;

public class HarmoneeDbContext : DbContext
{
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupMember> GroupMembers { get; set; }
    public DbSet<GroupList> GroupLists { get; set; }
    public DbSet<CalendarEvent> CalendarEvents { get; set; }
    public DbSet<HarmoneeUser> Users { get; set; }

    public HarmoneeDbContext(DbContextOptions<HarmoneeDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<GroupList>().OwnsMany(g => g.Items, builder => { builder.ToJson(); });
    }
}
