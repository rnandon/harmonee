using Harmonee.Shared.Interfaces;
using Harmonee.Shared.Models;

namespace Harmonee.API.Data;

public class GroupListRepository : IRepository<GroupList>
{
    private readonly HarmoneeDbContext _context;

    public GroupListRepository(HarmoneeDbContext context)
    {
        _context = context;
    }

    public bool Create(GroupList entity)
    {
        if (_context.GroupLists.Any(g => g.Id == entity.Id))
        {
            return false;
        }

        _context.GroupLists.Add(entity);
        _context.SaveChanges();
        return true;
    }

    public bool Delete(Guid id)
    {
        var entityToRemove = _context.GroupLists.FirstOrDefault(g => g.Id == id);
        if (entityToRemove is null)
        {
            return false;
        }

        _context.GroupLists.Remove(entityToRemove);
        _context.SaveChanges();
        return true;
    }

    public bool Delete(IEnumerable<Guid> ids)
    {
        var entitiesToRemove = _context.GroupLists.Where(g => ids.Contains(g.Id));
        if (entitiesToRemove is null || entitiesToRemove.Count() == 0)
        {
            return false;
        }

        _context.GroupLists.RemoveRange(entitiesToRemove);
        _context.SaveChanges();
        return true;
    }

    public GroupList? Get(Guid id)
    {
        return _context.GroupLists.FirstOrDefault(g => g.Id == id);
    }

    public GroupList[] Get(IEnumerable<Guid> ids)
    {
        return _context.GroupLists.Where(g => ids.Contains(g.Id)).ToArray();
    }

    public bool Update(GroupList entity)
    {
        var existingRecord = _context.GroupLists.FirstOrDefault(g => g.Id == entity.Id);
        if (existingRecord is null)
        {
            return false;
        }

        _context.GroupLists.Update(entity);
        _context.SaveChanges();
        return true;
    }

    public bool Update(IEnumerable<GroupList> entities)
    {
        var ids = entities.Select(e => e.Id);
        var entitiesToUpdate = _context.GroupLists.Where(g => ids.Contains(g.Id));
        if (entitiesToUpdate is null || entitiesToUpdate.Count() == 0)
        {
            return false;
        }

        _context.GroupLists.UpdateRange(entitiesToUpdate);
        _context.SaveChanges();
        return true;
    }
}
