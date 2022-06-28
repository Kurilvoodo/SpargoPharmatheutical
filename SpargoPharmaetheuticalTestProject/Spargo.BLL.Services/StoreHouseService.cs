using Spargo.BLL.Interfaces;
using Spargo.DAO.Interfaces;
using Spargo.Entities;

namespace Spargo.BLL.Services
{
    public class StoreHouseService : IStoreHouseService
    {
        private readonly IStoreHouseDAO _storeHouseDAO;

        public StoreHouseService(IStoreHouseDAO storeHouseDAO)
        {
            _storeHouseDAO = storeHouseDAO;
        }

        public int AddStoreHouse(StoreHouse storeHouse)
        {
            return _storeHouseDAO.AddStoreHouse(storeHouse);
        }

        public void HardDeleteStoreHouse(int storeHouseId)
        {
            _storeHouseDAO.HardDeleteStoreHouse(storeHouseId);
        }

        public void SoftDeleteStoreHouse(int storeHouseId)
        {
            _storeHouseDAO.SoftDeleteStoreHouse(storeHouseId);
        }
    }
}