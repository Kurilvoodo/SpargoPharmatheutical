using Spargo.Entities;

namespace Spargo.BLL.Interfaces
{
    public interface IStockService
    {
        int AddStock(Stock stock);

        void SoftDeleteStock(int stockId);

        void HardDeleteStock(int stockId);
    }
}