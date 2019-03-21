using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1

{
    public class ProgramUI
    {
        private MenuRepository _menuRepo = new MenuRepository();
        private Menu menu = new Menu();
        public void Run()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Main Menu:\n" +
                    "1.Do you wish to add any item to the list\n" +
                    "2. Do you wish to remove any entree for list\n" +
                    "3. Veiw Information\n" +
                    "4. Exit");
                string inputAsString =
                    Console.ReadLine();
                int input = int.Parse(inputAsString);

                switch (input)
                {
                    case 1:
                        AddMenuItem
                            ();
                        break;
                    case 2:
                        RemoveFromList
                            ();
                        break;
                    case 3:
                        GetMenu();
                        break;
                    case 4:
                        running = false;
                        break;
                }
            }
        }

        private void AddMenuItem()
        {
            Menu menu = new Menu();
            Console.WriteLine($"hello,add some meal number? ");
            menu.MealNumber = Console.ReadLine();

            Console.WriteLine($"enter a meal name");
            menu.MealName = Console.ReadLine();

            Console.WriteLine("enter a breif description of the item");
            menu.Description = Console.ReadLine();

            Console.WriteLine("enter a list of ingredients");
            menu.ListOfIngredients = Console.ReadLine();

            Console.WriteLine("enter the price");
            menu.Price = decimal.Parse(Console.ReadLine());

            _menuRepo.AddMenuToList(menu);
        }

        private void GetMenu()
        {
            Console.WriteLine("Hello , here is your information:");

            List<Menu> menus = _menuRepo.GetMenuList();
            foreach (Menu menu in menus)
            {
                Console.WriteLine($"Meal Number: {menu.MealNumber} \n" +
                    $"Meal Name: {menu.MealName} \n" +
                    $"Meal Description: {menu.Description} \n" +
                    $"Meal Ingredients: {menu.ListOfIngredients}" +
                    $"Meal Price:{menu.Price}");
            }
            Console.WriteLine("Press Enter to Continue: ");
            Console.ReadLine();
        }

        private void RemoveFromList()

        {
            Menu newMenu = new Menu();
            Console.Clear();
            Console.WriteLine($"Item Number     Item Name     Description     Ingredients   Price");
            Console.WriteLine("-------------------------------------------------------------------");
            List<Menu> menus = _menuRepo.GetMenuList();
            foreach (Menu menu in menus)
            {
                Console.WriteLine($"{menu.MealNumber,-15}{menu.MealName,-15}{menu.Description,-15}{menu.ListOfIngredients,-15}{menu.Price,-15}");
            }
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Which item would you like to remove?");
            Console.WriteLine("1");
            string deletePrompt = Console.ReadLine();


            _menuRepo.RemoveProductBySpecifications(deletePrompt);
            Console.Clear();
            Console.WriteLine($"Item Number     Item Name     Description     Ingredients   Price");
            Console.WriteLine("-------------------------------------------------------------------");
            foreach (Menu menu in menus)
            {
                Console.WriteLine($"{menu.MealNumber,-15}{menu.MealName,-15}{menu.Description,-15}{menu.ListOfIngredients,-15}{menu.Price,-15}");
            }
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Press any key to continue:");
            Console.ReadKey();





        }
        }
    }