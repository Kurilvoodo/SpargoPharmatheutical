using Spargo.Entities;

namespace Spargo.BLL.Interfaces
{
    public interface IStoreHouseService
    {
        int AddStoreHouse(StoreHouse storeHouse);

        void SoftDeleteStoreHouse(int storeHouseId);

        void HardDeleteStoreHouse(int storeHouseId);
    }
}