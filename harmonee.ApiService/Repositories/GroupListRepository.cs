using harmonee.Shared.Models;

namespace harmonee.ApiService.Repositories;

public class GroupListRepository : IRepository<GroupList>
{
    GroupListDbContext _context;

    public GroupListRepository(GroupListDbContext context)
    {
        _context = context;
    }

    public GroupList? Get(Guid id)
    {
        return _context.GroupLists.FirstOrDefault(g => g.Id == id);
    }

    public IEnumerable<GroupList> Get(IEnumerable<Guid> ids)
    {
        return _context.GroupLists.Where(g => ids.Contains(g.Id));
    }
    public bool Add(GroupList entity)
    {
        _context.GroupLists.Add(entity);
        _context.SaveChanges();
        return true;
    }

    public bool AddMany(IEnumerable<GroupList> entities)
    {
        _context.GroupLists.AddRange(entities);
        _context.SaveChanges();
        return true;
    }

    public bool Remove(GroupList entity)
    {
        _context.GroupLists.Remove(entity);
        _context.SaveChanges();
        return true;
    }

    public bool RemoveMany(IEnumerable<GroupList> entities)
    {
        _context.GroupLists.RemoveRange(entities);
        _context.SaveChanges();
        return true;
    }

    public bool Update(GroupList entity)
    {
        _context.GroupLists.Update(entity);
        _context.SaveChanges();
        return true;
    }

    public bool UpdateMany(IEnumerable<GroupList> entities)
    {
        _context.GroupLists.UpdateRange(entities);
        _context.SaveChanges();
        return true;
    }
}

public interface IGroupListRepository
{
    public GroupList? Get(Guid id);
    public IEnumerable<GroupList> Get(IEnumerable<Guid> ids);
    public bool Add(GroupList entity);
    public bool AddMany(IEnumerable<GroupList> entities);
    public bool Remove(GroupList entity);
    public bool RemoveMany(IEnumerable<GroupList> entities);
    public bool Update(GroupList entity);
    public bool UpdateMany(IEnumerable<GroupList> entities);
}

