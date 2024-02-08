using harmonee.Shared.Models;

namespace harmonee.ApiService.Repositories;

public class GroupMemberRepository : IRepository<GroupMember>
{
    GroupMemberDbContext _context;

    public GroupMemberRepository(GroupMemberDbContext context)
    {
        _context = context;
    }

    public GroupMember? Get(Guid id)
    {
        return _context.GroupMembers.FirstOrDefault(g => g.Id == id);
    }

    public IEnumerable<GroupMember> Get(IEnumerable<Guid> ids)
    {
        return _context.GroupMembers.Where(g => ids.Contains(g.Id));
    }

    public bool Add(GroupMember entity)
    {
        _context.GroupMembers.Add(entity);
        _context.SaveChanges();
        return true;
    }

    public bool AddMany(IEnumerable<GroupMember> entities)
    {
        _context.GroupMembers.AddRange(entities);
        _context.SaveChanges();
        return true;
    }

    public bool Remove(GroupMember entity)
    {
        _context.GroupMembers.Remove(entity);
        _context.SaveChanges();
        return true;
    }

    public bool RemoveMany(IEnumerable<GroupMember> entities)
    {
        _context.GroupMembers.RemoveRange(entities);
        _context.SaveChanges();
        return true;
    }

    public bool Update(GroupMember entity)
    {
        _context.GroupMembers.Update(entity);
        _context.SaveChanges();
        return true;
    }

    public bool UpdateMany(IEnumerable<GroupMember> entities)
    {
        _context.GroupMembers.UpdateRange(entities);
        _context.SaveChanges();
        return true;
    }
}
