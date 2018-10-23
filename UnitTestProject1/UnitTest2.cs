using System;
using HW_08.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestRadioButtonAssociation()
        {
            var vm = new PizzaViewModel();
            var pizzaType = "Combo";
            vm.MyCommand.Execute(pizzaType);
            Assert.AreEqual(vm.Name, pizzaType);
        }

        [TestMethod]
        public void TestCommandVariable()
        {
            var vm = new PizzaViewModel();
            var drinkType = "Diet Mountain Dew";
            vm.DrinkCommand.Execute(drinkType);
            Assert.AreEqual(vm.Drink, drinkType);
        }
    }
}
