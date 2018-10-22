using System;
using HW_08;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDataGridCalculation()
        {
            var vm = new DataGridViewModel();
            Assert.Equals(477, Math.Round(vm.MortgagePayment));

        }
    }
}
