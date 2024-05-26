namespace StoreApi;

public interface IStore
{
    Task<List<Store>> GetStores(QueryObject queryObject);
    Task<Store?> GetStoreById(Guid Id);
    Task<Store> AddStore(Store store);
    Task<Store?> UpdateStore(Guid Id,Store store);
    Task<Store?> DeleteStore(Guid Id);

}
