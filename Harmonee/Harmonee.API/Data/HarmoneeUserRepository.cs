using Harmonee.Shared.Interfaces;
using Harmonee.Shared.Models;

namespace Harmonee.API.Data;

public class HarmoneeUserRepository : IRepository<HarmoneeUser>
{
    private readonly HarmoneeDbContext _context;

    public HarmoneeUserRepository(HarmoneeDbContext context)
    {
        _context = context;
    }

    public bool Create(HarmoneeUser entity)
    {
        if (_context.Users.Any(g => g.Id == entity.Id))
        {
            return false;
        }

        _context.Users.Add(entity);
        _context.SaveChanges();
        return true;
    }

    public bool Delete(Guid id)
    {
        var entityToRemove = _context.Users.FirstOrDefault(g => g.Id == id);
        if (entityToRemove is null)
        {
            return false;
        }

        _context.Users.Remove(entityToRemove);
        _context.SaveChanges();
        return true;
    }

    public bool Delete(IEnumerable<Guid> ids)
    {
        var entitiesToRemove = _context.Users.Where(g => ids.Contains(g.Id));
        if (entitiesToRemove is null || entitiesToRemove.Count() == 0)
        {
            return false;
        }

        _context.Users.RemoveRange(entitiesToRemove);
        _context.SaveChanges();
        return true;
    }

    public HarmoneeUser? Get(Guid id)
    {
        return _context.Users.FirstOrDefault(g => g.Id == id);
    }

    public HarmoneeUser[] Get(IEnumerable<Guid> ids)
    {
        return _context.Users.Where(g => ids.Contains(g.Id)).ToArray();
    }

    public bool Update(HarmoneeUser entity)
    {
        var existingRecord = _context.Users.FirstOrDefault(g => g.Id == entity.Id);
        if (existingRecord is null)
        {
            return false;
        }

        _context.Users.Update(entity);
        _context.SaveChanges();
        return true;
    }

    public bool Update(IEnumerable<HarmoneeUser> entities)
    {
        var ids = entities.Select(e => e.Id);
        var entitiesToUpdate = _context.Users.Where(g => ids.Contains(g.Id));
        if (entitiesToUpdate is null || entitiesToUpdate.Count() == 0)
        {
            return false;
        }

        _context.Users.UpdateRange(entitiesToUpdate);
        _context.SaveChanges();
        return true;
    }
}
