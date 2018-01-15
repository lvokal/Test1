using FC.eFox.desktop.cz.Tests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC.eFox.desktop.cz.Tests
{
    class InogenIN003 : IN003BaseTest
    {
        [Test]
        public void A_1ssembly1Test()
        {
            System.Threading.Thread.Sleep(10000);
            LogInToShopFloor();
            Assembly1();

        }
        [Test]
        public void A_2Assembly2Test()
        {
            System.Threading.Thread.Sleep(10000);
            LogInToShopFloor();
            Assembly2();
        }
        [Test]
        public void A_3ssembly3Test()
        {
            System.Threading.Thread.Sleep(10000);
            LogInToShopFloor();
            Assembly3();
        }
        [Test]
        public void A_4ssembly4Test()
        {
            System.Threading.Thread.Sleep(10000);
            LogInToShopFloor();
            Assembly4();
        }
        [Test]
        public void A_5ssembly5Test()
        {
            System.Threading.Thread.Sleep(10000);
            LogInToShopFloor();
            Assembly5();
        }
        [Test]
        public void A_6Burnin()
        {
            System.Threading.Thread.Sleep(10000);
            LogInToShopFloor();
            BurnIn();
        }
        [Test]
        public void A_7Finaltest()
        {
            System.Threading.Thread.Sleep(10000);
            LogInToShopFloor();
            FinalTest();
        }
        [Test]
        public void TestAllProcess()
        {
            LogInToShopFloor();
            TestAllIN003(1);
        }
    }
}
