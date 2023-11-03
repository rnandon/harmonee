using harmonee.Server.Data;
using harmonee.Shared.Family;

namespace harmonee.Server
{
    public class FamilyRepository : IRepository<Family>
    {
        public Family Add(Family entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Family> AddMany(IEnumerable<Family> entities)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMany(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Family> GetAll()
        {
            throw new NotImplementedException();
        }

        public Family GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Family> GetMany(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public bool Update(Family entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMany(IEnumerable<Family> entities)
        {
            throw new NotImplementedException();
        }
    }
}
