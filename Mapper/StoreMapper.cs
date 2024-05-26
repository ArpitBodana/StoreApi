namespace StoreApi;

public static class StoreMapper
{
   public static StoreDto ToStoreDto(this Store storeModel){
    return new StoreDto {
        Item= storeModel.Item,
        Desciption =storeModel.Desciption,
        Quantity=storeModel.Quantity,
        Owner =storeModel.Owner,
        Id =storeModel.Id
    };

   }

   public static Store ToStoreFromStoreDto(this StoreDto storeDto){
    return new Store{
        Item = storeDto.Item,
        Desciption = storeDto.Desciption,
        Quantity =storeDto.Quantity,
        Owner = storeDto.Owner
    };
   }

   public static Store ToStoreFromAddUpdateStoreDto(this AddUpdateStoreDto addUpdateStoreDto){
    return new Store {
        Item= addUpdateStoreDto.Item,
        Desciption =addUpdateStoreDto.Desciption,
        Quantity=addUpdateStoreDto.Quantity,
        Owner =addUpdateStoreDto.Owner
    };

   }

   public static AddUpdateStoreDto ToAddUpdateStoreDto(this Store store){
    return new AddUpdateStoreDto{
        Item =store.Item,
        Desciption=store.Desciption,
        Quantity=store.Quantity,
        Owner=store.Owner
    };
   }
}
