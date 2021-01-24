using System.Threading.Tasks;

namespace DataAccess.StorageTableRepository
{
    public interface IEntityDataStore<TKey, TEntity> where TEntity : IEntity<TKey>
    {
        Task AddAsync(
            TEntity entity);

        Task DeleteByIdAsync(
            TKey id);

        Task<TEntity> GetByIdAsync(
            TKey id);

        Task UpdateAsync(
            TEntity entity);
    }
}