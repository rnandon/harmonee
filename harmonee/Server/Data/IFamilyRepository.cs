using harmonee.Shared.Models;

namespace harmonee.Shared.Data
{
    public interface IFamilyRepository : IRepository<Models.Family>
    {
        public Models.Family Add(Models.Family entity);
        public IEnumerable<Models.Family> AddMany(IEnumerable<Models.Family> entities);
        public bool Delete(Guid id);
        public bool DeleteMany(IEnumerable<Guid> ids);
        public IEnumerable<Models.Family> GetAll();
        public Models.Family? GetById(Guid id);
        public IEnumerable<Models.Family> GetMany(IEnumerable<Guid> ids);
        public bool Update(Models.Family entity);
        public bool UpdateMany(IEnumerable<Models.Family> entities);
    }
}
