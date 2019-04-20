using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Module : Item
    {
        public ModuleType Type { get; set; }
        public List<Part> Parts { get; private set; }
        public Module()
        {
            Parts = new List<Part>();
        }
        public Module(int id, double price, double discount, ModuleType type, List<Part> parts) 
            : base(id, price, discount)
        {
            Type = type;
            Parts = parts;
            GenericType = Classes.GenericType.Module;
           
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"{Id}) {Type} - {Price}eur - Discoount: {Discount}\n ");
            foreach (var part in Parts)
            {
                Console.WriteLine($"- {part.Type} : {part.Name} / Mnyfacturer - {part.Company} ");
               
            }
            Console.WriteLine("**********************************************");
        }
    }
}
