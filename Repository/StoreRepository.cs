
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace StoreApi;

public class StoreRepository : IStore
{
    private readonly AppDbContext dbContext;
    public StoreRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<Store> AddStore(Store store)
    {
        await dbContext.Stores.AddAsync(store);
        await dbContext.SaveChangesAsync();
        return store;
    }

    public async Task<Store?> DeleteStore(Guid Id)
    {
        var existing = await dbContext.Stores.FirstOrDefaultAsync(x => x.Id == Id);
        if (existing == null)
        {
            return null;
        }
        dbContext.Stores.Remove(existing);
        await dbContext.SaveChangesAsync();
        return existing;

    }

    public async Task<Store?> GetStoreById(Guid Id)
    {
        return await dbContext.Stores.FirstOrDefaultAsync(x => x.Id == Id);
    }

    public async Task<List<Store>> GetStores(QueryObject queryObject)
    {
        var stores = dbContext.Stores.AsQueryable();
        //filter
        if (!string.IsNullOrWhiteSpace(queryObject.Item))
        {
            stores = stores.Where(x => x.Item.Contains(queryObject.Item));
        }

        if (!string.IsNullOrWhiteSpace(queryObject.Owner))
        {
            stores = stores.Where(x => x.Owner.Contains(queryObject.Owner));
        }

        //sorting
        if (!string.IsNullOrWhiteSpace(queryObject.SortBy))
        {
            if (queryObject.SortBy.Equals("Item", StringComparison.OrdinalIgnoreCase))
            {
                stores = queryObject.IsDescending ? stores.OrderByDescending(x => x.Item) : stores.OrderBy(x => x.Item);
            }
            if (queryObject.SortBy.Equals("Owner", StringComparison.OrdinalIgnoreCase))
            {
                stores = queryObject.IsDescending ? stores.OrderByDescending(x => x.Owner) : stores.OrderBy(x => x.Owner);
            }

        }
        //pagination
        var SkipNumber = (queryObject.PageNumber - 1) * queryObject.PageSize;
        return await stores.Skip(SkipNumber).Take(queryObject.PageSize).ToListAsync();
    }


    public async Task<Store?> UpdateStore(Guid Id, Store store)
    {
        var existing = await dbContext.Stores.FirstOrDefaultAsync(x => x.Id == Id);

        if (existing == null)
        {
            return null;
        }
        existing.Item = store.Item;
        existing.Desciption = store.Desciption;
        existing.Quantity = store.Quantity;
        existing.Owner = store.Owner;
        await dbContext.SaveChangesAsync();
        return existing;
    }
}
