using FC.eFox.desktop.cz.Tests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC.eFox.desktop.cz.Tests
{
    class TestingEnvironment: TestingEnvironmentBaseTest
    {
        [Test]
        public void Test()
        {
            LogInToShopFloor();
            TestTest();
        }
        [Test]
        public void Test2()
        {
            Assert.AreEqual("0","0");
        }
        
        [Test]
        public void Test3()
        {
            Assert.AreEqual("0","1");
        }

    }
}
