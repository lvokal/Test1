using NUnit.Framework;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace FC.eFox.desktop.cz
{
	/// <summary>
	/// Class represents about databse connection and getting data drom DB
	/// </summary>
	public static class DBSelector
	{
		private static string DataSource = null;
		private static string DataBase = null;

		/// <summary>
		/// Method to get the database connection details
		/// </summary>
		public static void GetConnectionDetails()
		{
			var environment = GetEnvironment();
			switch (environment)
			{
				case "TestDB":
					DataSource = ConfigurationManager.AppSettings["TestDataSource"];
					DataBase = ConfigurationManager.AppSettings["TestDataBase"];
					break;
				case "AccDB":
					DataSource = ConfigurationManager.AppSettings["AccDataSource"];
					DataBase = ConfigurationManager.AppSettings["AccDataBase"];
					break;
				case "ProdDB":
					DataSource = ConfigurationManager.AppSettings["ProdDataSource"];
					DataBase = ConfigurationManager.AppSettings["ProdDataBase"];
					break;
				default:
					Console.WriteLine("NO valid environment parameter was provided. Test env will be used.");
					DataSource = ConfigurationManager.AppSettings["TestDataSource"];
					DataBase = ConfigurationManager.AppSettings["TestDataBase"];
					break;
			}
		}

		/// <summary>
		/// Gets the proper environment
		/// </summary>
		/// <returns></returns>
		private static string GetEnvironment()
		{
			var environment = TestContext.Parameters.Get("environment", "TestDB");
			return environment;
		}

		/// <summary>
		/// 
		/// </summary>
		private static void ConnectToDB()
		{
			try
			{
				//var connection = new SqlConnection("data source=" + DataSource + ";" + "Initial Catalog=" + DataBase + ";Integrated Security=SSPI");
				//connection.Open();
    //            var reader = new SqlCommand("select top 1 serialno from Product where treenoid = 34");
    //            reader.CommandText = "select top 1 serialno from Product where treenoid = 34";
    //            reader.Connection = connection;
               // return reader.ExecuteReader().ToString();
                
                
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}
        public static string Query()
        {
            var connection = new SqlConnection("data source=CZ03VWDBDEV01" + ";" + "Initial Catalog=LS53DEVCZ" + ";Integrated Security=SSPI");
            connection.Open();
            GetConnectionDetails();
            SqlDataReader reader = null;           
            SqlCommand command = new SqlCommand("select top 1 serialno from Product where treenodeid = 34",connection);
            //command.CommandText = "select top 1 serialno from Product where treenodeid = 34";
            //command.Connection = connection;           
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                return reader["serialno"].ToString();
            }
            connection.Close();
            return null;
        }
        public static string Dbcheck(string SN)
        {
            var connection = new SqlConnection("data source=CZ03VWDBDEV01" + ";" + "Initial Catalog=LS53DEVCZ" + ";Integrated Security=SSPI");
            connection.Open();
            GetConnectionDetails();
            SqlDataReader reader = null;
            string commandstring = "select treenodeid from Product where serialno = " + SN;
            SqlCommand command = new SqlCommand(commandstring, connection);
            //command.CommandText = "select top 1 serialno from Product where treenodeid = 34";
            //command.Connection = connection;           
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                return reader["treenodeid"].ToString();
            }
            connection.Close();
            return null;
        }
        public static string QueryLeakTest()
        {
            var connection = new SqlConnection("data source=CZ03VWDBDEV01" + ";" + "Initial Catalog=LS53DEVCZ" + ";Integrated Security=SSPI");
            connection.Open();
            GetConnectionDetails();
            SqlDataReader reader = null;
            SqlCommand command = new SqlCommand("select top 1 serialno from Product where treenodeid = 49", connection);
            //command.CommandText = "select top 1 serialno from Product where treenodeid = 34";
            //command.Connection = connection;           
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                return reader["serialno"].ToString();
            }
            connection.Close();
            return null;
        }
    }
}
