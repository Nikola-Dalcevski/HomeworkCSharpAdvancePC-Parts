using Entities;
using Entities.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public class UIServices
    {

        public int UserChoiceCategory()
        {
            int choice = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose Category you want to see");
                Console.WriteLine("1) Computer Parts");
                Console.WriteLine("2) Computer Modules");
                Console.WriteLine("3) Computer Configurations");
                var IsNumber = int.TryParse(Console.ReadLine(), out choice);
                if(IsNumber && choice >= 1 && choice <= 3)
                {           
                    break;
                }
                Console.WriteLine("The choice you made is invalid. Plese enter some from the given options. Press enter to try again");
                Console.ReadLine();
            }
            return choice;                     
        }


        public int UserChoiceFilter()
        {
            int choice = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Filter Products");
                Console.WriteLine("1) Show All Products");
                Console.WriteLine("2) Show Products by Price");
                Console.WriteLine("3) Show By Type of Products");

                var UserInput = int.TryParse(Console.ReadLine(), out choice);
                if (UserInput && choice >=1 && choice <= 3)
                {
                    break;
                }
                Console.WriteLine("The choice you made is invalid. Plese enter some from the given options. Press enter to try again");
                Console.ReadLine();
                continue;
            }
            return choice;
        }


        // FILTER BY PRICE
        public void FilterByPrice<T>(List<T> list) where T : Item
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter min and max price range");
                Console.WriteLine("Enter min price ");
                var isNumber = int.TryParse(Console.ReadLine(), out int min);
                if (!isNumber || min < 1) { Console.WriteLine("You must enter proper price (greater than 0), press enter to continue"); Console.ReadLine(); continue; }
                Console.WriteLine("Enter max price");
                var isNumber2 = int.TryParse(Console.ReadLine(), out int max);
                if (!isNumber2 || max < min) { Console.WriteLine("You must enter proper price (greater than minimum price), press enter to continue");Console.ReadLine();  continue; }
                var shortByPrice = list.Where(x => x.Price > min && x.Price < max).ToList();
                ShowProducts(shortByPrice);           
                break;
            }            
        }

        //FILTER BY TYPE

       
        public void FilterByType(List<Part> list)
        {
            while (true)
            {     
                Console.WriteLine("Enter product type end press enter");
                Console.WriteLine("********************************");
                for (var i = PartType.Cpu; i <= PartType.Keyboard; i++)
                {
                    Console.WriteLine(i);
                }              
                var choice = Console.ReadLine();
                var findProductsByType = list.Where(x => x.Type.ToString().ToLower() == choice.ToLower()).ToList();
                if(findProductsByType.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("You enter invalid type please try again - press enter");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                Console.Clear();
                ShowProducts(findProductsByType);
                break;
            }             
        }

        public void filterByTypeModules(List<Module> modules)
        {
            while (true)
            {
                Console.WriteLine("Enter product type than press enter");
                Console.WriteLine("********************************");
                for (var i = ModuleType.Processing; i < ModuleType.Other; i++)
                {
                    Console.WriteLine(i);
                }
                var choice = Console.ReadLine();
                var findProductsByType = modules.Where(x => x.Type.ToString().ToLower() == choice.ToLower()).ToList();
                if (findProductsByType.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("You enter invalid type please try again - press enter");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                Console.Clear();
                ShowProducts(findProductsByType);
                break;
            }
        }

        public void filterByTypeConfigurations(List<Configuration> configurations)
        {
            while (true)
            {
                Console.WriteLine("Enter product type end press enter");
                Console.WriteLine("********************************");
                Console.WriteLine(" Standard\n Office\n Gaming");
                var choice = Console.ReadLine();
                var findProductsByType = configurations.Where(x => x.Type.ToString().ToLower() == choice.ToLower()).ToList();
                if (findProductsByType.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("You enter invalid type please try again - press enter");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                Console.Clear();
                ShowProducts(findProductsByType);
                break;
            }
        }

        // SHOW PRODUCTS

        public  void ShowProducts<T>(List<T> list) where T : Item
        {
            Console.Clear();
            Console.WriteLine("Choose the number of the produt you want to buy");
            Console.WriteLine("********************************");
            if(list.Count == 0)
            {
                Console.WriteLine("There is no products in this category (price range)");              
            }
            else
            {
                foreach (var product in list)
                {
                    product.PrintInfo();
                }
                UserBuyNumber(list);
            }   
        }
      

        public void UserBuyNumber<T>( List<T> items) where T : Item
        {
            while (true)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("Enter the number of product you whant to buy");
                var IsNumber = int.TryParse(Console.ReadLine(), out int choice);
                var isFind = items.Any(x => x.Id == choice);
                if (IsNumber && isFind)
                {
                    Console.Clear();
                    bool addmax = ShoppingCart.AddToChart(items.Find(x => x.Id == choice));
                    if (addmax)
                    {
                        Console.WriteLine("This item is added in your shopping cart");
                        Console.WriteLine("*******************************************");
                        items.Find(x => x.Id == choice).PrintInfo();
                    }                  
                    Console.WriteLine("Press enter to continue");

                    Console.ReadLine();
                    break;
                }
                Console.WriteLine("You enter invalid number. press enter to continue");
                Console.ReadLine();               
            }            
        }

        public int UserContinueShopingAction()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose action to continue");
                Console.WriteLine("----------------------------");
                Console.WriteLine("1) Continue shopping the same prodcts");
                Console.WriteLine("2) Search products again");
                Console.WriteLine("3) See cart");
                Console.WriteLine("4) Continue to check out");

                bool IsNumber = int.TryParse(Console.ReadLine(), out int choice);
                if (IsNumber && choice > 0 && choice < 5)
                {
                    return choice;
                }
                Console.WriteLine("You enter invalid choice, press enter to try again");
                Console.ReadLine();
            }
        }
      
    }
}
