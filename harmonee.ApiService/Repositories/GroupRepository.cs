using Microsoft.EntityFrameworkCore;
using harmonee.Shared.Models;

namespace harmonee.ApiService.Repositories;

public class GroupRepository : IRepository<Group>
{
	GroupDbContext _context;

    public GroupRepository(GroupDbContext groupContext)
    {
        _context = groupContext;
    }

	public bool Add(Group group)
	{
		_context.Groups.Add(group);
		_context.SaveChanges();
		return true;
	}

	public bool Remove(Group group)
	{
		_context.Groups.Remove(group);
		_context.SaveChanges();
		return true;
	}

	public bool AddMany(IEnumerable<Group> groups)
	{
		_context.Groups.AddRange(groups);
		_context.SaveChanges();
		return true;
	}

	public bool RemoveMany(IEnumerable<Group> groups)
	{
		_context.Groups.RemoveRange(groups);
		_context.SaveChanges();
		return true;
	}

    public bool Update(Group entity)
    {
		_context.Groups.Update(entity);
		_context.SaveChanges();
		return true;
    }

    public bool UpdateMany(IEnumerable<Group> entity)
    {
		_context.Groups.UpdateRange(entity);
		_context.SaveChanges();
		return true;
    }
}
