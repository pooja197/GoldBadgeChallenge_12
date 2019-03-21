using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1
{
   public class MenuRepository
    {
        private List<Menu> _menuList;

        public MenuRepository()
        {
            _menuList = new List<Menu>();
        }
        public void AddMenuToList (Menu newMenu)
        {
            _menuList.Add(newMenu);
        }
        public List<Menu> GetMenuList()
        {
            return _menuList;
        }
        public bool RemoveProductBySpecifications(string mealNumber)
        {
            foreach (Menu menu in _menuList)
            {
                if (mealNumber == menu.MealNumber)
                {
                    _menuList.Remove(menu);
                    return true;
                }
            }
            return false;
        }
    }
}
