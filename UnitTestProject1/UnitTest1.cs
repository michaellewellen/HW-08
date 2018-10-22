using System;
using HW_08.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            Assert.AreEqual(477, Math.Round(vm.MortgagePayment, 0));
        }

        [TestMethod]
        public void TestPurchasePriceError()
        {
            var vm = new DataGridViewModel();
            vm.PurchasePrice = 0;
            Assert.AreEqual(vm[nameof(vm.PurchasePrice)], null);
        }

        [TestMethod]
        public void TestInterestRateError()
        {
            var vm = new DataGridViewModel();
            vm.IntSlider = 0;
            Assert.AreEqual(vm[nameof(vm.PurchasePrice)], null);
        }

        [TestMethod]
        public void TestLoanPeriorError()
        {
            var vm = new DataGridViewModel();
            vm.YrsSlider = 0;
            Assert.AreEqual(vm[nameof(vm.PurchasePrice)], null);
        }

        [TestMethod]
        public void TestCorrectNumberofPayments()
        {
            var vm = new DataGridViewModel();
            
            int modelTest = vm.AmortizationSchedule.Count;
            Assert.AreEqual(vm.YrsSlider*12, modelTest);
        }

        [TestMethod]
        public void TestPurchasePriceErrorCondition()
        {
            var vm = new DataGridViewModel();
            vm.PurchasePrice = -4;
            Assert.AreEqual(vm[nameof(vm.PurchasePrice)], "Purchase Price must be a positive value");
        }

        [TestMethod]
        public void TestIntSliderErrorCondition()
        {
            var vm = new DataGridViewModel();
            vm.IntSlider = -4;
            Assert.AreEqual(vm[nameof(vm.IntSlider)], "Interest must be a positive value");
        }

        [TestMethod]
        public void TestYrsSliderErrorCondition()
        {
            var vm = new DataGridViewModel();
            vm.YrsSlider = -4;
            Assert.AreEqual(vm[nameof(vm.YrsSlider)], "Mortgage Period must be a positive value");
        }

        [TestMethod]
        public void TestPurchasePriceErrorGoodCondition()
        {
            var vm = new DataGridViewModel();
            vm.PurchasePrice = 100000;
            Assert.AreEqual(vm[nameof(vm.PurchasePrice)], null);
        }

        [TestMethod]
        public void TestIntSliderErrorGoodCondition()
        {
            var vm = new DataGridViewModel();
            vm.IntSlider = 4;
            Assert.AreEqual(vm[nameof(vm.IntSlider)],null);
        }

        [TestMethod]
        public void TestYrsSliderErrorGoodCondition()
        {
            var vm = new DataGridViewModel();
            vm.YrsSlider = 30;
            Assert.AreEqual(vm[nameof(vm.YrsSlider)], null);
        }

    }
}
