using harmonee.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace harmonee.Server.Data
{
    public class FamilyEventRepository //: IFamilyEventRepository
    {
        private readonly FamilyEventContext _context;

        public FamilyEventRepository(FamilyEventContext context)
        {
            _context = context;
        }

        public bool Add(FamilyEvent entity)
        {
            var existingRecord = _context.FamilyEvents.FirstOrDefault(fe =>  fe.Id == entity.Id);
            if (existingRecord is not null)
            {
                return false;
            }

            _context.FamilyEvents.Add(entity);
            _context.SaveChanges();
            return true;
        }

        public bool AddMany(IEnumerable<FamilyEvent> entities)
        {
            var contextChanged = false;
            foreach (var incomingEvent in entities)
            {
                var existingRecord = _context.FamilyEvents.FirstOrDefault(fe => fe.Id == incomingEvent.Id);
                if (existingRecord is null)
                {
                    _context.FamilyEvents.Add(incomingEvent);
                }
            }

            if (contextChanged)
            {
                _context.SaveChanges(); 
            }

            return contextChanged;
        }

        public bool Delete(Guid id)
        {
            var existingRecord = _context.FamilyEvents.FirstOrDefault(fe => fe.Id == id);
            if (existingRecord is not null)
            {
                _context.FamilyEvents.Remove(existingRecord);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteMany(IEnumerable<Guid> ids)
        {
            var existingEvents = _context.FamilyEvents.Where(f => ids.Contains(f.Id));
            if (existingEvents.Count() == 0)
            {
                return false;
            }

            _context.FamilyEvents.RemoveRange(existingEvents);
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
            var existingEvent = _context.FamilyEvents.FirstOrDefault(fe => fe.Id == entity.Id);
            if (existingEvent is null)
            {
                return false;
            }

            if (existingEvent.Equals(entity))
            {
                return false;
            }

            _context.FamilyEvents.Update(entity);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateMany(IEnumerable<FamilyEvent> entities)
        {
            var contextChanged = false;
            foreach (var incomingEvent in entities)
            {
                var existingEvent = _context.FamilyEvents.FirstOrDefault(fe => fe.Id == incomingEvent.Id);
                if (existingEvent is null)
                {
                    continue;
                }

                if (existingEvent.Equals(incomingEvent))
                {
                    continue;
                }

                _context.FamilyEvents.Update(incomingEvent);
                contextChanged = true;
            }

            if (contextChanged)
            {
                _context.SaveChanges();
                return true;
            }
            return false;
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
