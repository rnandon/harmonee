using harmonee.Shared.Family;
using Microsoft.EntityFrameworkCore;

namespace harmonee.Server.Data
{
    public class FamilyEventRepository : IRepository<FamilyEvent>
    {
        private readonly FamilyEventContext _context;

        public FamilyEventRepository(FamilyEventContext context)
        {
            _context = context;
        }

        public FamilyEvent Add(FamilyEvent entity)
        {
            _context.FamilyEvents.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public IEnumerable<FamilyEvent> AddMany(IEnumerable<FamilyEvent> entities)
        {
            foreach (var family in entities)
            {
                _context.FamilyEvents.Add(family);
            }
            _context.SaveChanges();
            return entities;
        }

        public bool Delete(Guid id)
        {
            _context.FamilyEvents.Remove(GetById(id));
            _context.SaveChanges();
            return true;
        }

        public bool DeleteMany(IEnumerable<Guid> ids)
        {
            var familiesToRemove = _context.FamilyEvents.Where(f => ids.Contains(f.Id));
            _context.FamilyEvents.RemoveRange(familiesToRemove);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<FamilyEvent> GetAll()
        {
            return _context.FamilyEvents.ToList();
        }

        public FamilyEvent? GetById(Guid id)
        {
            return _context.FamilyEvents.FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<FamilyEvent> GetMany(IEnumerable<Guid> ids)
        {
            return _context.FamilyEvents.Where(f => ids.Contains(f.Id));
        }

        public bool Update(FamilyEvent entity)
        {
            _context.FamilyEvents.Update(entity);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateMany(IEnumerable<FamilyEvent> entities)
        {
            _context.FamilyEvents.UpdateRange(entities);
            _context.SaveChanges();
            return true;
        }
    }

    public class FamilyEventContext : DbContext
    {
        private readonly string _connectionString = string.Empty;
        public DbSet<FamilyEvent> FamilyEvents { get; set; }

        public FamilyEventContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use appropriate server and connection string
            optionsBuilder.UseSqlServer(_connectionString);

        }
    }
}
