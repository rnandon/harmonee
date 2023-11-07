using harmonee.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace harmonee.Server.Data
{
    public class FamilyMemberRepository : IRepository<FamilyMember>
    {
        private readonly FamilyMemberContext _context;

        public FamilyMemberRepository(FamilyMemberContext context)
        {
            _context = context;
        }

        public FamilyMember Add(FamilyMember entity)
        {
            _context.FamilyMembers.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public IEnumerable<FamilyMember> AddMany(IEnumerable<FamilyMember> entities)
        {
            foreach (var family in entities)
            {
                _context.FamilyMembers.Add(family);
            }
            _context.SaveChanges();
            return entities;
        }

        public bool Delete(Guid id)
        {
            _context.FamilyMembers.Remove(GetById(id));
            _context.SaveChanges();
            return true;
        }

        public bool DeleteMany(IEnumerable<Guid> ids)
        {
            var familiesToRemove = _context.FamilyMembers.Where(f => ids.Contains(f.Id));
            _context.FamilyMembers.RemoveRange(familiesToRemove);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<FamilyMember> GetAll()
        {
            return _context.FamilyMembers.ToList();
        }

        public FamilyMember? GetById(Guid id)
        {
            return _context.FamilyMembers.FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<FamilyMember> GetMany(IEnumerable<Guid> ids)
        {
            return _context.FamilyMembers.Where(f => ids.Contains(f.Id));
        }

        public bool Update(FamilyMember entity)
        {
            _context.FamilyMembers.Update(entity);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateMany(IEnumerable<FamilyMember> entities)
        {
            _context.FamilyMembers.UpdateRange(entities);
            _context.SaveChanges();
            return true;
        }
    }

    public class FamilyMemberContext : DbContext
    {
        public DbSet<FamilyMember> FamilyMembers { get; set; }
        private readonly string _connectionString;

        public FamilyMemberContext(string connectionString)
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
