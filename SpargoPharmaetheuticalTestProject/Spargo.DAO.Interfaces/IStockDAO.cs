using Spargo.Entities;

namespace Spargo.DAO.Interfaces
{
    public interface IStockDAO
    {
        int AddStock(Stock stock);

        void SoftDeleteStock(int stockId);

        void HardDeleteStock(int stockId);
    }
}