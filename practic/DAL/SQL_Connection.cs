using Microsoft.AspNetCore.Connections;
using Microsoft.Data.SqlClient;
using System.Data;

namespace practic.DAL
{
    public interface ISQL_Connection
    {
        DataSet DataSet(string cmdText, CommandType commandType, string conStr);
    }
    public class SQL_Connection : ISQL_Connection
    {
        public DataSet DataSet(string cmdText, CommandType commandType, string conStr)
        {
            var dataSet = new DataSet();

            using(SqlConnection sqlCon = new SqlConnection(conStr))
            {
                using(SqlCommand sqlCmd = new SqlCommand(cmdText, sqlCon))
                {
                    sqlCmd.CommandType = commandType;
                    using(SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                    {
                        sqlDataAdapter.SelectCommand = sqlCmd;
                        sqlDataAdapter.Fill(dataSet);
                    }
                }
            }
            return dataSet;
        }
    }
}
