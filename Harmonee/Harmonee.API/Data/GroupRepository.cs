using Harmonee.Shared.Interfaces;
using Harmonee.Shared.Models;

namespace Harmonee.API.Data;

public class GroupRepository : IRepository<Group>
{
    private readonly HarmoneeDbContext _context;

    public GroupRepository(HarmoneeDbContext context)
    {
        _context = context;
    }

    public bool Create(Group entity)
    {
        if (_context.Groups.Any(g => g.Id == entity.Id))
        {
            return false;
        }

        _context.Groups.Add(entity);
        _context.SaveChanges();
        return true;
    }

    public bool Delete(Guid id)
    {
        var entityToRemove = _context.Groups.FirstOrDefault(g => g.Id == id);
        if (entityToRemove is null)
        {
            return false;
        }

        _context.Groups.Remove(entityToRemove);
        _context.SaveChanges();
        return true;
    }

    public bool Delete(IEnumerable<Guid> ids)
    {
        var entitiesToRemove = _context.Groups.Where(g =>  ids.Contains(g.Id));
        if (entitiesToRemove is null || entitiesToRemove.Count() == 0)
        {
            return false;
        }

        _context.Groups.RemoveRange(entitiesToRemove);
        _context.SaveChanges();
        return true;
    }

    public Group? Get(Guid id)
    {
        return _context.Groups.FirstOrDefault(g => g.Id == id);
    }

    public Group[] Get(IEnumerable<Guid> ids)
    {
        return _context.Groups.Where(g => ids.Contains(g.Id)).ToArray();
    }

    public bool Update(Group entity)
    {
        var existingRecord = _context.Groups.FirstOrDefault(g => g.Id == entity.Id);
        if (existingRecord is null)
        {
            return false;
        }

        _context.Groups.Update(entity);
        _context.SaveChanges();
        return true;
    }

    public bool Update(IEnumerable<Group> entities)
    {
        var ids = entities.Select(e => e.Id);
        var entitiesToUpdate = _context.Groups.Where(g => ids.Contains(g.Id));
        if (entitiesToUpdate is null || entitiesToUpdate.Count() == 0)
        {
            return false;
        }

        _context.Groups.UpdateRange(entitiesToUpdate);
        _context.SaveChanges();
        return true;
    }
}
