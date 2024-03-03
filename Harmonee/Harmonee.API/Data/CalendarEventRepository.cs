using Harmonee.Shared.Interfaces;
using Harmonee.Shared.Models;

namespace Harmonee.API.Data;

public class CalendarEventRepository : IRepository<CalendarEvent>
{
    private readonly HarmoneeDbContext _context;

    public CalendarEventRepository(HarmoneeDbContext context)
    {
        _context = context;
    }

    public bool Create(CalendarEvent entity)
    {
        if (_context.CalendarEvents.Any(g => g.Id == entity.Id))
        {
            return false;
        }

        _context.CalendarEvents.Add(entity);
        _context.SaveChanges();
        return true;
    }

    public bool Delete(Guid id)
    {
        var entityToRemove = _context.CalendarEvents.FirstOrDefault(g => g.Id == id);
        if (entityToRemove is null)
        {
            return false;
        }

        _context.CalendarEvents.Remove(entityToRemove);
        _context.SaveChanges();
        return true;
    }

    public bool Delete(IEnumerable<Guid> ids)
    {
        var entitiesToRemove = _context.CalendarEvents.Where(g => ids.Contains(g.Id));
        if (entitiesToRemove is null || entitiesToRemove.Count() == 0)
        {
            return false;
        }

        _context.CalendarEvents.RemoveRange(entitiesToRemove);
        _context.SaveChanges();
        return true;
    }

    public CalendarEvent? Get(Guid id)
    {
        return _context.CalendarEvents.FirstOrDefault(g => g.Id == id);
    }

    public CalendarEvent[] Get(IEnumerable<Guid> ids)
    {
        return _context.CalendarEvents.Where(g => ids.Contains(g.Id)).ToArray();
    }

    public bool Update(CalendarEvent entity)
    {
        var existingRecord = _context.CalendarEvents.FirstOrDefault(g => g.Id == entity.Id);
        if (existingRecord is null)
        {
            return false;
        }

        _context.CalendarEvents.Update(entity);
        _context.SaveChanges();
        return true;
    }

    public bool Update(IEnumerable<CalendarEvent> entities)
    {
        var ids = entities.Select(e => e.Id);
        var entitiesToUpdate = _context.CalendarEvents.Where(g => ids.Contains(g.Id));
        if (entitiesToUpdate is null || entitiesToUpdate.Count() == 0)
        {
            return false;
        }

        _context.CalendarEvents.UpdateRange(entitiesToUpdate);
        _context.SaveChanges();
        return true;
    }
}
