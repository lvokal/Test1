using FC.eFox.desktop.cz.Tests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC.eFox.desktop.cz
{
	[TestFixture, Category("Regression")]
    public class StockInWeightTest : BaseTest
    {
		[Test]		
		public void StockInWeight()
		{
			//Step1. Connect to DB and get serial number, store in some variable
			//Step 2:Login to efox system, I made it for you
			LogInToShopFloor();
			//Step 3 : Goto Tools > hfkjdj > kjdk> enter sserial number in text box, click enter
			//Step 4 : Read the log information
			//Step 5: Assert/verify the log info(Green or red)
		}

		[Test]
		[TestCase(1, TestName = "StockInWeight2")]
		public void StockInWeight2()
		{
		}
	}
}
