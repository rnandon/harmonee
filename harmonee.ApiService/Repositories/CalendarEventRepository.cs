using harmonee.Shared.Models;

namespace harmonee.ApiService.Repositories;

public class CalendarEventRepository : IRepository<CalendarEvent>
{
    CalendarEventDbContext _context;

    public CalendarEventRepository(CalendarEventDbContext context)
    {
        _context = context;
    }

    public CalendarEvent? Get(Guid id)
    {
        return _context.CalendarEvents.FirstOrDefault(g => g.Id == id);
    }

    public IEnumerable<CalendarEvent> Get(IEnumerable<Guid> ids)
    {
        return _context.CalendarEvents.Where(g => ids.Contains(g.Id));
    }

    public bool Add(CalendarEvent entity)
    {
        _context.CalendarEvents.Add(entity);
        _context.SaveChanges();
        return true;
    }

    public bool AddMany(IEnumerable<CalendarEvent> entities)
    {
        _context.CalendarEvents.AddRange(entities);
        _context.SaveChanges();
        return true;
    }

    public bool Remove(CalendarEvent entity)
    {
        _context.CalendarEvents.Remove(entity);
        _context.SaveChanges();
        return true;
    }

    public bool RemoveMany(IEnumerable<CalendarEvent> entities)
    {
        _context.CalendarEvents.RemoveRange(entities);
        _context.SaveChanges();
        return true;
    }

    public bool Update(CalendarEvent entity)
    {
        _context.CalendarEvents.Update(entity);
        _context.SaveChanges();
        return true;
    }

    public bool UpdateMany(IEnumerable<CalendarEvent> entities)
    {
        _context.CalendarEvents.UpdateRange(entities);
        _context.SaveChanges();
        return true;
    }
}

public interface ICalendarEventRepository
{
    public CalendarEvent? Get(Guid id);
    public IEnumerable<CalendarEvent> Get(IEnumerable<Guid> ids);
    public bool Add(CalendarEvent entity);
    public bool AddMany(IEnumerable<CalendarEvent> entities);
    public bool Remove(CalendarEvent entity);
    public bool RemoveMany(IEnumerable<CalendarEvent> entities);
    public bool Update(CalendarEvent entity);
    public bool UpdateMany(IEnumerable<CalendarEvent> entities);
}