using System.Data;
using System.Data.SqlClient;

namespace Spargo.DAO
{
    public class SQLShell
    {
        public SqlParameter GetParameter(string parameterName, object value, DbType mytype)
        {
            return new SqlParameter()
            {
                DbType = mytype,
                ParameterName = parameterName,
                Value = value,
                Direction = ParameterDirection.Input
            };
        }

        public SqlCommand GetCommand(SqlConnection connection, string commandText)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = commandText;
            return command;
        }

        public void AddParameter(SqlParameter myParam, SqlCommand myCommand)
        {
            myCommand.Parameters.Add(myParam);
        }
    }
}