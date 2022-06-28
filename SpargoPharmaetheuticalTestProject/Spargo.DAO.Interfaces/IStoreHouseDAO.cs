using Spargo.Entities;

namespace Spargo.DAO.Interfaces
{
    public interface IStoreHouseDAO
    {
        int AddStoreHouse(StoreHouse storeHouse);

        void SoftDeleteStoreHouse(int storeHouseId);

        void HardDeleteStoreHouse(int storeHouseId);
    }
}