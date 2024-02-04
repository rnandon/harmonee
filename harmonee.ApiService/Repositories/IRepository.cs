namespace harmonee.ApiService.Repositories;

using harmonee.Shared.Models;
using Microsoft.EntityFrameworkCore;

public interface IRepository<T> where T : class
{
	public bool Add(T entity);
	public bool Remove(T entity);
	public bool Update(T entity);
	public bool AddMany(IEnumerable<T> entities);
	public bool RemoveMany(IEnumerable<T> entities);
	public bool UpdateMany(IEnumerable<T> entities);
}
