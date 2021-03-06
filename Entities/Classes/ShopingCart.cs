﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Classes
{
    public static class ShoppingCart
    {
        public static List<Item> UserShopingCart = new List<Item>();
        private static Double FullDiscount { get; set; }
        private static Double FullPrice { get; set; }


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
            Console.WriteLine("Press enter to continue");
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

        public static string ShowChartWhitPrice(Item item)
        {
            return $@"Price = {item.Price} \ Discount = {item.Discount} \ Price With Discount = {ShoppingCart.CalculatePrice(item)}";
        }

        public static double CalculatePrice(Item item)
        {
            double disc = item.Price * item.Discount;
            FullDiscount += disc;
            FullPrice += item.Price;
            if (item.Discount == 0)
            {
                return item.Price;
            }
            else
            {
                return item.Price - disc;
            }
        }

        public static string ShowProductPrices()
        {

            string message = "";
            Console.Clear();
            int i = 1;
            foreach (var item in UserShopingCart)
            {
                Console.WriteLine(item.PrintInfoShort());
                message += $"{item.PrintInfoShort()} \n";
                message += $"{ShowChartWhitPrice(item)} \n";
                Console.WriteLine(ShowChartWhitPrice(item));
                i++;
                Console.WriteLine("------------------------------");
            }
            Console.WriteLine($"The total price is {FullPrice} ");
            message += $"The total price is {FullPrice} \n";
            Console.WriteLine($"The total Discount you get is {FullDiscount} ");
            message += $"The total Discount you get is {FullDiscount} \n";
            return message;
        }

    }
}
