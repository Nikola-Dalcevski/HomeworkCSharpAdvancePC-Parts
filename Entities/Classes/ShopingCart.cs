using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Classes
{
    public static class ShoppingCart
    {
        public static List<Item> UserShopingCart = new List<Item>();
       

        public static void ShowUserProducts()
        {
            Console.Clear();
            Console.WriteLine("Products in your cart");
           
            int i = 1;
            foreach (var item in UserShopingCart)
            {
               
                Console.WriteLine($"PRODUDCT {i})");
              
                item.PrintInfo();           
                i++;
            }
        }

        public static bool AddToChart(Item item)
        {
            
            var maxParts = UserShopingCart.Where(x => x.GenericType.ToString() == "Part").ToList().Count();
            var maxModules = UserShopingCart.Where(x => x.GenericType.ToString() == "Module").ToList().Count();
            var maxConfigurations = UserShopingCart.Where(x => x.GenericType.ToString() == "Configuration").ToList().Count();
            if(item.GenericType.ToString() == "Part" && maxParts < 10)
            {
                UserShopingCart.Add(item);
                return true;
            }
            else if(item.GenericType.ToString() == "Module" && maxModules < 5)
            {
                UserShopingCart.Add(item);
                return true;
            }
            else if(item.GenericType.ToString() == "Configuration" && maxConfigurations < 1)
            {
                UserShopingCart.Add(item);
                return true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You reach the max count of products you can buy from this category. Press enter to continue");
                
                return false;
            }
            
        }
    }
}
