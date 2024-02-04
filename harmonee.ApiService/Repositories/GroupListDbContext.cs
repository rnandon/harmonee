using harmonee.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace harmonee.ApiService.Repositories;

public class GroupListDbContext : DbContext
{
    public DbSet<GroupList> GroupLists { get; set; }

    public GroupListDbContext()
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<GroupList>().OwnsOne(
            groupList => groupList.Items,
            ownedNavigationBuilder =>
            {
                ownedNavigationBuilder.ToJson();
            });
    }
}
