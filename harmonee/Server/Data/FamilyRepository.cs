using harmonee.Shared.Family;
using Microsoft.EntityFrameworkCore;

namespace harmonee.Server.Data
{
    public class FamilyRepository : IRepository<Family>
    {
        private readonly FamilyContext _context;

        public FamilyRepository(FamilyContext context)
        {
            _context = context;
        }

        public Family Add(Family entity)
        {
            _context.Families.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public IEnumerable<Family> AddMany(IEnumerable<Family> entities)
        {
            foreach (var family in entities)
            {
                _context.Families.Add(family);
            }
            _context.SaveChanges();
            return entities;
        }

        public bool Delete(Guid id)
        {
            _context.Families.Remove(GetById(id));
            _context.SaveChanges();
            return true;
        }

        public bool DeleteMany(IEnumerable<Guid> ids)
        {
            var familiesToRemove = _context.Families.Where(f => ids.Contains(f.Id));
            _context.Families.RemoveRange(familiesToRemove);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Family> GetAll()
        {
            return _context.Families.ToList();
        }

        public Family? GetById(Guid id)
        {
            return _context.Families.FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<Family> GetMany(IEnumerable<Guid> ids)
        {
            return _context.Families.Where(f => ids.Contains(f.Id));
        }

        public bool Update(Family entity)
        {
            _context.Families.Update(entity);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateMany(IEnumerable<Family> entities)
        {
            _context.Families.UpdateRange(entities);
            _context.SaveChanges();
            return true;
        }
    }

    public class FamilyContext : DbContext
    {
        public DbSet<Family> Families { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use appropriate server and connection string
        }
    }
}
