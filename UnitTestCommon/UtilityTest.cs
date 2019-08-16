using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace UnitTestCommon
{
    [TestClass]
    public class UtilityTest
    {
        [TestMethod]
        public void FirstWorkDays()
        {
            var d = DateTimeExtensions.FirstWorkDays(2019, 8, 6);

        }
    }
}
