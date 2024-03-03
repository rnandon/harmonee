namespace Harmonee.Shared.Interfaces;

public interface IRepository<T> where T : class
{
    public T? Get(Guid id);
    public T[] Get(IEnumerable<Guid> ids);
    public bool Update(T entity);
    public bool Update(IEnumerable<T> entities);
    public bool Create(T entity);
    public bool Delete(Guid id);
    public bool Delete(IEnumerable<Guid> ids);
}
