using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Challenge1;

namespace Challenge1Repository_Tests
{
    [TestClass]
    public class UnitTest1
    {
        private MenuRepository _menuRepo = new MenuRepository();
        [TestMethod]
        public void TestMethod1()
        {
            Menu menu = new Menu();
            _menuRepo.AddMenuToList(menu);

            var actual = _menuRepo.GetMenuList().Count;
            var expected = 1;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
            public void RemoveFromList()
        {
            Menu menu = new Menu();
            Menu _menu = new Menu();
            menu.MealNumber = "1";
            _menuRepo.AddMenuToList(menu);
            _menuRepo.AddMenuToList(_menu);
            _menuRepo.RemoveProductBySpecifications("1");
                
        }
            
    }
}
