using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FC.eFox.desktop.cz
{
    class CheckAgainstDB
    {
        public string DataSource;
        public string Database;
        public CheckAgainstDB(string dataSource, string dataBase)
        {
            this.Database = dataBase;
            this.DataSource = dataSource;
        }
        public string CheckSNAgainstDB(string SN)
        {
            SqlDataReader reader = null;         
            var connection = new SqlConnection("data source="+this.DataSource+";"+"Initial Catalog="+this.Database+";"+"Integrated Security =SSPI");
            SqlCommand command = new SqlCommand("select treenodeid from Component where serialno ='" + SN + "'",connection);
            try
            {
                connection.Open();
            }
            catch (Exception)
            {
                return "failed";
                throw;
            }
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                return reader["treenodeid"].ToString();   
            }
            connection.Close();
            return null;
        }

    }
}
