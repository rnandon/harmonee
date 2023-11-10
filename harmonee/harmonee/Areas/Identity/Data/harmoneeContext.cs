using harmonee.Areas.Core.Data;
using harmonee.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace harmonee.Data;

public class harmoneeContext : IdentityDbContext<User>
{
    public harmoneeContext(DbContextOptions<harmoneeContext> options)
        : base(options)
    {
    }

    public DbSet<Family> Families { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<ChatMessage> ChatMessages { get; set; }
    public DbSet<UserChatHistory> UserChatHistories { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.Entity<UserChatHistory>().HasKey(uch => new { uch.ChatId, uch.UserId });
    }
}
