using Microsoft.Extensions.Options;
using Spargo.DAO.Interfaces;
using Spargo.Entities;
using Spargo.Entities.Options;
using System.Data;
using System.Data.SqlClient;

namespace Spargo.DAO
{
    public class StockDAO : SQLShell, IStockDAO
    {
        private readonly IOptions<ConnectionStringOptions> _connectionStringOptions;

        public StockDAO(IOptions<ConnectionStringOptions> connecntionStringOptions)
        {
            _connectionStringOptions = connecntionStringOptions;
        }

        public int AddStock(Stock stock)
        {
            using (var connection = new SqlConnection(_connectionStringOptions.Value.DB))
            {
                SqlCommand cmd = GetCommand(connection, "dbo.AddStock");
                AddParameter(GetParameter("@StoreHouseId", stock.StoreHouseId, DbType.Int32), cmd);
                AddParameter(GetParameter("@ProductId", stock.ProductId, DbType.Int32), cmd);
                AddParameter(GetParameter("@StockNumber", stock.StockNumber, DbType.Int32), cmd);
                connection.Open();
                var stockId = cmd.ExecuteScalar();
                return (int)stockId;
            }
        }

        public void HardDeleteStock(int stockId)
        {
            using (var connection = new SqlConnection(_connectionStringOptions.Value.DB))
            {
                SqlCommand cmd = GetCommand(connection, "dbo.HardDeleteStock");
                AddParameter(GetParameter("@id", stockId, DbType.Int32), cmd);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void SoftDeleteStock(int stockId)
        {
            using (var connection = new SqlConnection(_connectionStringOptions.Value.DB))
            {
                SqlCommand cmd = GetCommand(connection, "dbo.SoftDeleteStock");
                AddParameter(GetParameter("@id", stockId, DbType.Int32), cmd);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}