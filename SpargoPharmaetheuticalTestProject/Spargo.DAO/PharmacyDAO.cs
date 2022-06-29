using Microsoft.Extensions.Options;
using Spargo.DAO.Interfaces;
using Spargo.Entities;
using Spargo.Entities.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Spargo.DAO
{
    public class PharmacyDAO : SQLShell, IPharmacyDAO
    {
        private readonly IOptions<ConnectionStringOptions> _connectionStringOptions;

        public PharmacyDAO(IOptions<ConnectionStringOptions> connecntionStringOptions)
        {
            _connectionStringOptions = connecntionStringOptions;
        }

        public int AddPharmacy(Pharmacy pharmacy)
        {
            using (var connection = new SqlConnection(_connectionStringOptions.Value.DB))
            {
                SqlCommand cmd = GetCommand(connection, "dbo.AddPharmacy");
                AddParameter(GetParameter("@PharmacyName", pharmacy.Name, DbType.String), cmd);
                AddParameter(GetParameter("@PharmacyAdress", pharmacy.Adress, DbType.String), cmd);
                AddParameter(GetParameter("@PharmacyPhoneNumber", pharmacy.PhoneNumber, DbType.String), cmd);
                connection.Open();
                var pharmacyId = cmd.ExecuteScalar();
                return Decimal.ToInt32((decimal)pharmacyId);
            }
        }

        public IEnumerable<ProductQuantityResult> GetProductsInPharmacy(int pharmacyId)
        {
            List<ProductQuantityResult> PharmacyInformation = new List<ProductQuantityResult>();

            using (var connection  =  new SqlConnection(_connectionStringOptions.Value.DB))
            {

                SqlCommand cmd = GetCommand(connection, "dbo.GetProductsInPharmacy");
                AddParameter(GetParameter("@Id", pharmacyId, DbType.Int32), cmd);
                connection.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PharmacyInformation.Add(new ProductQuantityResult()
                    {
                        ProductName = reader["ProductName"] as string,
                        ProductQuantity = (int)reader["ProductQuantity"]
                    });
                }
            }
            return PharmacyInformation;
        }

        public void HardDeletePharmacy(int pharmacyId)
        {
            using (var connection = new SqlConnection(_connectionStringOptions.Value.DB))
            {
                SqlCommand cmd = GetCommand(connection, "dbo.HardDeletePharmacy");
                AddParameter(GetParameter("@Id", pharmacyId, DbType.Int32), cmd);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void SoftDeletePharmacy(int pharmacyId)
        {
            using (var connection = new SqlConnection(_connectionStringOptions.Value.DB))
            {
                SqlCommand cmd = GetCommand(connection, "dbo.SoftDeletePharmacy");
                AddParameter(GetParameter("@Id", pharmacyId, DbType.Int32), cmd);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}