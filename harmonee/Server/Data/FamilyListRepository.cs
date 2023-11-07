using harmonee.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace harmonee.Server.Data
{
    public class FamilyListRepository : IRepository<FamilyList>
    {
        private readonly FamilyListContext _context;

        public FamilyListRepository(FamilyListContext context)
        {
            _context = context;
        }

        public FamilyList Add(FamilyList entity)
        {
            _context.FamilyLists.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public IEnumerable<FamilyList> AddMany(IEnumerable<FamilyList> entities)
        {
            foreach (var family in entities)
            {
                _context.FamilyLists.Add(family);
            }
            _context.SaveChanges();
            return entities;
        }

        public bool Delete(Guid id)
        {
            _context.FamilyLists.Remove(GetById(id));
            _context.SaveChanges();
            return true;
        }

        public bool DeleteMany(IEnumerable<Guid> ids)
        {
            var familiesToRemove = _context.FamilyLists.Where(f => ids.Contains(f.Id));
            _context.FamilyLists.RemoveRange(familiesToRemove);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<FamilyList> GetAll()
        {
            return _context.FamilyLists.ToList();
        }

        public FamilyList? GetById(Guid id)
        {
            return _context.FamilyLists.FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<FamilyList> GetMany(IEnumerable<Guid> ids)
        {
            return _context.FamilyLists.Where(f => ids.Contains(f.Id));
        }

        public bool Update(FamilyList entity)
        {
            _context.FamilyLists.Update(entity);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateMany(IEnumerable<FamilyList> entities)
        {
            _context.FamilyLists.UpdateRange(entities);
            _context.SaveChanges();
            return true;
        }
    }

    public class FamilyListContext : DbContext
    {
        public DbSet<FamilyList> FamilyLists { get; set; }
        private readonly string _connectionString;

        public FamilyListContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            // Use appropriate server and connection string
        }
    }
}
