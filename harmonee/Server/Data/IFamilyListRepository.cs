using harmonee.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace harmonee.Server.Data
{
    public interface IFamilyListRepository
    {
        public bool Add(FamilyList entity);
        public bool AddMany(IEnumerable<FamilyList> entities);
        public bool Delete(Guid id);
        public bool DeleteMany(IEnumerable<Guid> ids);
        public IEnumerable<FamilyList> GetAll();
        public IEnumerable<FamilyList> GetByFamily(Guid familyId);
        public FamilyList? GetById(Guid id);
        public IEnumerable<FamilyList> GetMany(IEnumerable<Guid> ids);
        public bool Update(FamilyList entity);
        public bool UpdateMany(IEnumerable<FamilyList> entities);
    }
}
