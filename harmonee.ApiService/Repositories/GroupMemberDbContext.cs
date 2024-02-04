using harmonee.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace harmonee.ApiService.Repositories;

public class GroupMemberDbContext : DbContext
{
    public DbSet<GroupMember> GroupMembers { get; set; }

    public GroupMemberDbContext()
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
