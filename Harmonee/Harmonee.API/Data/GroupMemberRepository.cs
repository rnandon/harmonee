using Harmonee.Shared.Interfaces;
using Harmonee.Shared.Models;

namespace Harmonee.API.Data;

public class GroupMemberRepository : IRepository<GroupMember>
{
    private readonly HarmoneeDbContext _context;

    public GroupMemberRepository(HarmoneeDbContext context)
    {
        _context = context;
    }

    public bool Create(GroupMember entity)
    {
        if (_context.GroupMembers.Any(g => g.Id == entity.Id))
        {
            return false;
        }

        _context.GroupMembers.Add(entity);
        _context.SaveChanges();
        return true;
    }

    public bool Delete(Guid id)
    {
        var entityToRemove = _context.GroupMembers.FirstOrDefault(g => g.Id == id);
        if (entityToRemove is null)
        {
            return false;
        }

        _context.GroupMembers.Remove(entityToRemove);
        _context.SaveChanges();
        return true;
    }

    public bool Delete(IEnumerable<Guid> ids)
    {
        var entitiesToRemove = _context.GroupMembers.Where(g => ids.Contains(g.Id));
        if (entitiesToRemove is null || entitiesToRemove.Count() == 0)
        {
            return false;
        }

        _context.GroupMembers.RemoveRange(entitiesToRemove);
        _context.SaveChanges();
        return true;
    }

    public GroupMember? Get(Guid id)
    {
        return _context.GroupMembers.FirstOrDefault(g => g.Id == id);
    }

    public GroupMember[] Get(IEnumerable<Guid> ids)
    {
        return _context.GroupMembers.Where(g => ids.Contains(g.Id)).ToArray();
    }

    public bool Update(GroupMember entity)
    {
        var existingRecord = _context.GroupMembers.FirstOrDefault(g => g.Id == entity.Id);
        if (existingRecord is null)
        {
            return false;
        }

        _context.GroupMembers.Update(entity);
        _context.SaveChanges();
        return true;
    }

    public bool Update(IEnumerable<GroupMember> entities)
    {
        var ids = entities.Select(e => e.Id);
        var entitiesToUpdate = _context.GroupMembers.Where(g => ids.Contains(g.Id));
        if (entitiesToUpdate is null || entitiesToUpdate.Count() == 0)
        {
            return false;
        }

        _context.GroupMembers.UpdateRange(entitiesToUpdate);
        _context.SaveChanges();
        return true;
    }
}
