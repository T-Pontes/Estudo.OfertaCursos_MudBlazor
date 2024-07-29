using Core.Entities;

namespace Core.Abstractions.Repositories;
public interface IRepository<TEntity> where TEntity : Entity
{
    Task<TEntity> CreateAsync(TEntity entity);

    Task<TEntity> UpdateAsync(TEntity entity);

    Task DeleteAsync(TEntity entity);

    Task<ICollection<TEntity>> GetAllAsync();

    Task<TEntity?> GetByIdAsync(int id);
}
