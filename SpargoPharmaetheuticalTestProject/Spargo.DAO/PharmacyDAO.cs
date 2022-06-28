using Microsoft.Extensions.Options;
using Spargo.DAO.Interfaces;
using Spargo.Entities;
using Spargo.Entities.Options;
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
                return (int)pharmacyId;
            }
        }

        public void HardDeletePharmacy(int pharmacyId)
        {
            using (var connection = new SqlConnection(_connectionStringOptions.Value.DB))
            {
                SqlCommand cmd = GetCommand(connection, "dbo.HardDeletePharmacy");
                AddParameter(GetParameter("@id", pharmacyId, DbType.Int32), cmd);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void SoftDeletePharmacy(int pharmacyId)
        {
            using (var connection = new SqlConnection(_connectionStringOptions.Value.DB))
            {
                SqlCommand cmd = GetCommand(connection, "dbo.SoftDeletePharmacy");
                AddParameter(GetParameter("@id", pharmacyId, DbType.Int32), cmd);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}