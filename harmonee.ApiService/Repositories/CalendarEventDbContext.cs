using harmonee.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace harmonee.ApiService.Repositories;

public class CalendarEventDbContext : DbContext
{
    public DbSet<CalendarEvent> CalendarEvents { get; set; }

    public CalendarEventDbContext()
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<CalendarEvent>().OwnsOne(
            calendarEvent => calendarEvent.Attendees,
            ownedNavigationBuilder =>
            {
                ownedNavigationBuilder.ToJson();
            });
    }
}
