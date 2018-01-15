using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using NUnit.Framework;

namespace FC.eFox.desktop.cz.Tests
{
    public static class DBSelector
    {
        private static string DataSource = "CZ03VWDBDEV01";
        private static string DataBase = "LS53QACZ";
        private static string Security = "SSPI";
        //This method will select first SN from given treenodeid
        public static string SelectSnByTreenodeId(string treenodeid)
        {
            var connection = new SqlConnection("Data source ="+DataSource+";"+"Initial Catalog="+DataBase+";"+"Integrated Security="+Security+";");
            connection.Open();
            SqlDataReader reader = null;
            SqlCommand command = new SqlCommand("SELECT TOP 1 serialno FROM Product WHERE treenodeid='"+treenodeid+"'",connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                return reader["serialno"].ToString();
            }
            return null;
        }
        //This method will select WO from given SN
        public static string SelectWoBySn(string sn)
        {
            var connection = new SqlConnection("Data source =" + DataSource + ";" + "Initial Catalog=" + DataBase + ";" + "Integrated Security=" + Security + ";");
            connection.Open();
            SqlDataReader reader = null;
            SqlCommand command = new SqlCommand("SELECT f.workorderno FROM Flow f INNER JOIN Product p ON p.id = f.productid WHERE p.serialno ='"+sn+"'",connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                return reader["workorderno"].ToString();
            }
            return null;  
        }
        //This method will select Component from given SN and materialid
        public static string SelectComponentBySnAndMatrerial(string sn,string materialid)
        {
            var connection = new SqlConnection("Data source =" + DataSource + ";" + "Initial Catalog=" + DataBase + ";" + "Integrated Security=" + Security + ";");
            connection.Open();
            SqlDataReader reader = null;
            SqlCommand command = new SqlCommand("SELECT c.serialno FROM Product p INNER JOIN Component c ON c.productid = p.id WHERE p.serialno='"+sn+"' AND c.materialid ='"+materialid+"'",connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                return reader["serialno"].ToString();
            }
            return null;
        }
        //This method will return Product which is ready to use as a Component
        public static string SelectUnusedProduct(string inn)
        {
            var connection = new SqlConnection("Data source =" + DataSource + ";" + "Initial Catalog=" + DataBase + ";" + "Integrated Security=" + Security + ";");
            connection.Open();
            SqlDataReader reader = null;
            SqlCommand command = new SqlCommand("SELECT TOP 1 P.serialno FROM Product P (NOLOCK) JOIN FLow F (NOLOCK) ON P.id = F.productid JOIN TreeNode N (NOLOCK) ON F.treenodeid = N.id WHERE n.[name]='"+inn+"' AND F.completedate IS NOT NULL AND F.parentflowid IS NULL AND P.serialno NOT IN (SELECT serialno FROM Component c (NOLOCK) WHERE c.serialno = P.serialno)",connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                return reader["serialno"].ToString();
            }
            return null;       
        }
        //This method will return FG SN which is ready to use
        public static string SelectFGSn()
        {
            var connection = new SqlConnection("Data source =" + DataSource + ";" + "Initial Catalog=" + DataBase + ";" + "Integrated Security=" + Security + ";");
            connection.Open();
            SqlDataReader reader = null;
            SqlCommand command = new SqlCommand("SELECT TOP 1 P.serialno FROM Product P (NOLOCK) JOIN Flow F (NOLOCK) ON P.id = F.productid JOIN TreeNode N (NOLOCK) ON F.treenodeid = N.id WHERE N.[name]='IN004' AND P.treenodeid ='956'",connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                return reader["serialno"].ToString();
            }
            return null;         
        }
        //This method return treenodeid of Componet from given SN
        public static string CheckComponentAgainstDB(string sn)
        {
            var connection = new SqlConnection("Data source =" + DataSource + ";" + "Initial Catalog=" + DataBase + ";" + "Integrated Security=" + Security + ";");
            connection.Open();
            SqlDataReader reader = null;
            SqlCommand command = new SqlCommand("SELECT treenodeid FROM Component WHERE serialno ='"+sn+"'",connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                return reader["treenodeid"].ToString();
            }
            return null;          
        }
        //This method return True/False values from SaveEventLog action from given SN
        public static string SaveEventLog(string sn)
        {
            var connection = new SqlConnection("Data source =" + DataSource + ";" + "Initial Catalog=" + DataBase + ";" + "Integrated Security=" + Security + ";");
            connection.Open();
            SqlDataReader reader = null;
            SqlCommand command = new SqlCommand("SELECT e.pass,e.fail FROM Flow f INNER JOIN Product p ON p.id = f.productid INNER JOIN Event e ON e.flowid = f.id WHERE serialno='"+sn+"'",connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                return (reader["pass"].ToString()+" "+reader["fail"].ToString());
            }
            return null;
        }
        public static string SelectPalletId(string sn)
        {
            var connection = new SqlConnection("Data source =" + DataSource + ";" + "Initial Catalog=" + DataBase + ";" + "Integrated Security=" + Security + ";");
            connection.Open();
            SqlDataReader reader = null;
            SqlCommand command = new SqlCommand("select l.serialno from Product p inner join Flow f ON p.id = f.productid inner join Flow f2 ON f.parentflowid = f2.id inner join Location l  ON l.id = f2.locationid where p.serialno = '"+sn+"'", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                return (reader["serialno"].ToString());
            }
            return null;
        }
    }
}
