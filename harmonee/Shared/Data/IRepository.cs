namespace harmonee.Server.Data
{
    public interface IRepository<T> where T : Storable
    {
        public T GetById(Guid id);
        public IEnumerable<T> GetMany(IEnumerable<Guid> ids);
        public IEnumerable<T> GetAll();
        public T Add(T entity);
        public IEnumerable<T> AddMany(IEnumerable<T> entities);
        public bool Update(T entity);
        public bool UpdateMany(IEnumerable<T> entities);
        public bool Delete(Guid id);
        public bool DeleteMany(IEnumerable<Guid> ids);
    }
}
