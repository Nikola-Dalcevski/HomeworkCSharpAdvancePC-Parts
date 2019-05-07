using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Configuration : Item
    {
        public string Title { get; set; }
        public ConfigurationType Type { get; set; }
        public List<Module> Modules { get; set; }
        public Configuration()
        {
            Modules = new List<Module>();
        }
        public Configuration(int id, double price, double discount, string title, ConfigurationType type, List<Module> modules)
            : base(id, price, discount)
        {
            Title = title;
            Type = type;
            Modules = modules;
            GenericType  = Classes.GenericType.Configuration;
           
        }

        public override void PrintInfo()
        {            
            Console.WriteLine($"{Id}) {Title} {Type} - {Price}eur / Dicount: {Discount}\n".ToUpper());
            foreach (var modul in Modules)
            {
                Console.WriteLine($"* {modul.Type}");

                foreach (var part in modul.Parts)
                {
                    Console.WriteLine($"- {part.Type} : {part.Name} / Mnyfacturer - {part.Company}");
                    
                }
                Console.WriteLine("-----------------------");
            }
            Console.WriteLine("************************************************************************************************");          
        }

        public override string PrintInfoShort()
        {
            return $"{Title}";
        }
    }
}
