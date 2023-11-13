using harmonee.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace harmonee.Server.Data
{
    public interface IFamilyEventRepository
    {
        public bool Add(FamilyEvent entity);
        public bool AddMany(IEnumerable<FamilyEvent> entities);
        public bool Delete(Guid id);
        public bool DeleteMany(IEnumerable<Guid> ids);
        public IEnumerable<FamilyEvent> GetAll();
        public FamilyEvent? GetById(Guid id);
        public IEnumerable<FamilyEvent> GetByFamily(Guid familyId);
        public IEnumerable<FamilyEvent> GetMany(IEnumerable<Guid> ids);
        public bool Update(FamilyEvent entity);
        public bool UpdateMany(IEnumerable<FamilyEvent> entities);
    }
}
