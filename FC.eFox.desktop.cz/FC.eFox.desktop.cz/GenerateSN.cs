using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC.eFox.desktop.cz
{
    public class GenerateSN
    {

        public string GenerateCompressor()
        {
            CheckAgainstDB checkSn = new CheckAgainstDB("CZ03VWDBDEV01", "LS53QACZ");
            Random random = new Random();
            string finalSn = "K";
            Int32 numberSn = random.Next(10000000, 99999999);
            finalSn += numberSn.ToString();
           
            string checkedSn = checkSn.CheckSNAgainstDB(finalSn);
            Console.WriteLine("'" + checkedSn + "'");
            if (checkedSn == "failed")
            {
                Console.WriteLine("Connection failed");
            }
            else if (Convert.ToInt32(checkedSn) <= 1)
            {
                Console.WriteLine("SN is free");
                return finalSn;

            }
            else Console.WriteLine("SN is used");
            return null;
        }
        public string GenerateMotherBoard()
        {
            CheckAgainstDB checkSn = new CheckAgainstDB("CZ03VWDBDEV01", "LS53QACZ");
            Random random = new Random();
            string finalSn = "ABT ";
            Int32 numberSn = random.Next(10000, 99999);
            finalSn += numberSn.ToString();
            
            string checkedSn = checkSn.CheckSNAgainstDB(finalSn);
            Console.WriteLine("'" + checkedSn + "'");
            if (checkedSn == "failed")
            {
                Console.WriteLine("Connection failed");
            }
            else if (Convert.ToInt32(checkedSn) <= 1)
            {
                Console.WriteLine("SN is free");
                return finalSn;

            }
            else Console.WriteLine("SN is used");
            return null;
        }
        public string GeneratePowerSupply()
        {
            CheckAgainstDB checkSn = new CheckAgainstDB("CZ03VWDBDEV01", "LS53QACZ");
            Random random = new Random();
            string finalSn = "1";
            Int32 numberSn = random.Next(10000000, 99999999);
            finalSn += numberSn.ToString();

            string checkedSn = checkSn.CheckSNAgainstDB(finalSn);
            Console.WriteLine("'" + checkedSn + "'");
            if (checkedSn == "failed")
            {
                Console.WriteLine("Connection failed");
            }
            else if (Convert.ToInt32(checkedSn) <= 1)
            {
                Console.WriteLine("SN is free");
                return finalSn;

            }
            else Console.WriteLine("SN is used");
            return null;
           
        }
    }
}
