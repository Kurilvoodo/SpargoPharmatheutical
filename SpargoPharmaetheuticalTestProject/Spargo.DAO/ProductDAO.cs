﻿using Microsoft.Extensions.Options;
using Spargo.DAO.Interfaces;
using Spargo.Entities;
using Spargo.Entities.Options;
using System.Data;
using System.Data.SqlClient;

namespace Spargo.DAO
{
    public class ProductDAO : SQLShell, IProductDAO
    {
        private readonly IOptions<ConnectionStringOptions> _connectionStringOptions;

        public ProductDAO(IOptions<ConnectionStringOptions> connecntionStringOptions)
        {
            _connectionStringOptions = connecntionStringOptions;
        }

        public int AddProduct(Product product)
        {
            using (var connection = new SqlConnection(_connectionStringOptions.Value.DB))
            {
                SqlCommand cmd = GetCommand(connection, "dbo.AddPharmacy");
                AddParameter(GetParameter("@ProductName", product.Name, DbType.String), cmd);
                connection.Open();
                var productId = cmd.ExecuteScalar();
                return (int)productId;
            }
        }

        public void HardDeleteProduct(int productId)
        {
            using (var connection = new SqlConnection(_connectionStringOptions.Value.DB))
            {
                SqlCommand cmd = GetCommand(connection, "dbo.HardDeleteProduct");
                AddParameter(GetParameter("@id", productId, DbType.Int32), cmd);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void SoftDeleteProduct(int productId)
        {
            using (var connection = new SqlConnection(_connectionStringOptions.Value.DB))
            {
                SqlCommand cmd = GetCommand(connection, "dbo.SoftDeleteProduct");
                AddParameter(GetParameter("@id", productId, DbType.Int32), cmd);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}