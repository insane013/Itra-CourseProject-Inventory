using Course.Database.Entity;

namespace Course.Database.Repository.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    public Task<T?> GetById(string id);
    public Task<T?> Add(T entity);
    public Task<bool> Delete(string id);
    public Task<T?> Update(T entity);
}
