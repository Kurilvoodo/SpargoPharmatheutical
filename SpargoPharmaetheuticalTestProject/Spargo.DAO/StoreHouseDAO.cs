using Microsoft.Extensions.Options;
using Spargo.DAO.Interfaces;
using Spargo.Entities;
using Spargo.Entities.Options;
using System.Data;
using System.Data.SqlClient;

namespace Spargo.DAO
{
    public class StoreHouseDAO : SQLShell, IStoreHouseDAO
    {
        private readonly IOptions<ConnectionStringOptions> _connectionStringOptions;

        public StoreHouseDAO(IOptions<ConnectionStringOptions> connecntionStringOptions)
        {
            _connectionStringOptions = connecntionStringOptions;
        }

        public int AddStoreHouse(StoreHouse storeHouse)
        {
            using (var connection = new SqlConnection(_connectionStringOptions.Value.DB))
            {
                SqlCommand cmd = GetCommand(connection, "dbo.AddStoreHouse");
                AddParameter(GetParameter("@PharmacyId", storeHouse.PharmacyId, DbType.Int32), cmd);
                AddParameter(GetParameter("@StoreName", storeHouse.StoreName, DbType.String), cmd);
                connection.Open();
                var storeHouseId = cmd.ExecuteScalar();
                return (int)storeHouseId;
            }
        }

        public void HardDeleteStoreHouse(int storeHouseId)
        {
            using (var connection = new SqlConnection(_connectionStringOptions.Value.DB))
            {
                SqlCommand cmd = GetCommand(connection, "dbo.HardDeleteStoreHouse");
                AddParameter(GetParameter("@id", storeHouseId, DbType.Int32), cmd);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void SoftDeleteStoreHouse(int storeHouseId)
        {
            using (var connection = new SqlConnection(_connectionStringOptions.Value.DB))
            {
                SqlCommand cmd = GetCommand(connection, "dbo.SoftDeleteStoreHouse");
                AddParameter(GetParameter("@id", storeHouseId, DbType.Int32), cmd);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}