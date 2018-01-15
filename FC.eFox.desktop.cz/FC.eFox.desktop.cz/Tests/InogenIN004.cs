using FC.eFox.desktop.cz.Tests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC.eFox.desktop.cz.Tests
{
    class InogenIN004 : IN004BaseTest
    {
        [Test]
        public void B_1VisualInspection()
        {
            LogInToShopFloor();
            Visualinspection();
        }
        [Test]
        public void B_2CountryKit()
        {
            LogInToShopFloor();
            Countrykit();
        }
        [Test]
        public void B_3PackingTest()
        {
            LogInToShopFloor();
            Packing();
        }
        [Test]
        public void B_4WeightCheck()
        {
            LogInToShopFloor();
            Weightcheck();
        }
        [Test]
        public void B_5PalletizationAndStockInTest()
        {
            LogInToShopFloor();
            PalletizationAndStockIn();
        }
        
}
}

