using harmonee.Shared.Family;
using harmonee.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace harmonee.Server.Data
{
    public class FamilyMemberRepository : IFamilyMemberRepository
    {
        private readonly FamilyMemberContext _context;

        public FamilyMemberRepository(FamilyMemberContext context)
        {
            _context = context;
        }

        public bool Add(FamilyMember entity)
        {
            if (!_context.FamilyMembers.Any(fm => fm.FamilyId ==  entity.FamilyId && fm.UserId == entity.UserId))
            {
                _context.FamilyMembers.Add(entity);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<FamilyMember> AddMany(IEnumerable<FamilyMember> entities)
        {
            var contextChanged = false;
            foreach (var familyMember in entities)
            {
                var existingMember = _context.FamilyMembers.FirstOrDefault(fm => fm.FamilyId == familyMember.FamilyId && fm.UserId == familyMember.UserId);
                if (existingMember is null)
                {
                    _context.FamilyMembers.Add(familyMember);
                    contextChanged = true;
                }
            }

            if (contextChanged)
            {
                _context.SaveChanges();
            }

            return entities;
        }

        public bool Delete(FamilyMember familyMember)
        {
            var existingMember = _context.FamilyMembers.FirstOrDefault(fm => fm.FamilyId == familyMember.FamilyId && fm.UserId == familyMember.UserId);
            if (existingMember is null)
            {
                return false;
            }
            _context.FamilyMembers.Remove(existingMember);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteMany(IEnumerable<FamilyMember> familyMembers)
        {
            var contextChanged = false;
            foreach (var member in familyMembers)
            {
                var existingMember = _context.FamilyMembers.FirstOrDefault(fm => fm.FamilyId == member.FamilyId && fm.UserId == member.UserId);
                if (existingMember is not null)
                {
                    _context.FamilyMembers.Remove(existingMember);
                    contextChanged = true;
                }
            }

            if (contextChanged)
            {
                _context.SaveChanges();
            }

            return contextChanged;
        }

        public IEnumerable<FamilyMember> GetAll()
        {
            return _context.FamilyMembers.ToList();
        }

        public FamilyMember? GetById(Guid userId, Guid familyId)
        {
            return _context.FamilyMembers.FirstOrDefault(f => f.UserId == userId && f.FamilyId == familyId);
        }

        public IEnumerable<FamilyMember> GetByFamilyId(Guid familyId)
        {
            return _context.FamilyMembers.Where(f => f.FamilyId == familyId);
        }

        public IEnumerable<FamilyMember> GetByUserId(Guid userId)
        {
            return _context.FamilyMembers.Where(f => f.UserId == userId);
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
