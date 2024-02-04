﻿using harmonee.Shared.Models;

namespace harmonee.ApiService.Repositories;

public class GroupListRepository : IRepository<GroupList>
{
    GroupListDbContext _context;

    public GroupListRepository(GroupListDbContext context)
    {
        _context = context;
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
