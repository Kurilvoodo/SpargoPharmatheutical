using Spargo.BLL.Interfaces;
using Spargo.DAO.Interfaces;
using Spargo.Entities;

namespace Spargo.BLL.Services
{
    public class StockService : IStockService
    {
        private readonly IStockDAO _stockDAO;

        public StockService(IStockDAO stockDAO)
        {
            _stockDAO = stockDAO;
        }

        public int AddStock(Stock stock)
        {
            return _stockDAO.AddStock(stock);
        }

        public void HardDeleteStock(int stockId)
        {
            _stockDAO.HardDeleteStock(stockId);
        }

        public void SoftDeleteStock(int stockId)
        {
            _stockDAO.SoftDeleteStock(stockId);
        }
    }
}