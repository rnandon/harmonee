using harmonee.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace harmonee.ApiService.Repositories;

public class GroupDbContext : DbContext
{
    public DbSet<Group> Groups { get; set; }

    public GroupDbContext()
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Group>().OwnsOne(
            g => g.Members,
            ownedNavigationBuilder =>
            {
                ownedNavigationBuilder.ToJson();
            })
            .OwnsOne(
            g => g.Calendar,
            ownedNavigationBuilder =>
            {
                ownedNavigationBuilder.ToJson();
            })
            .OwnsOne(
            g => g.Lists,
            ownedNavigationBuilder =>
            {
                ownedNavigationBuilder.ToJson();
            });
    }
}
