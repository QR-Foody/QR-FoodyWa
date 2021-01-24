namespace DataAccess.StorageTableRepository
{
    public interface IChildEntityDataStore<TParentKey, TKey, TEntity> where TEntity : ChildEntity<TKey>, new()
    {
    }
}