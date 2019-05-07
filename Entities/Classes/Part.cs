using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Part : Item
    {
        public string Name { get; set; }
        public PartType Type { get; set; }
        public string Company { get; set; }
        public int Quantity { get; set; }
        public bool Warranty { get; set; }
        public Part()
        {

        }
        public Part(int id, double price, int quantity, double discount, string name, PartType type, string company, bool warranty)
            : base(id, price, discount)
        {
            Name = name;
            Type = type;
            Company = company;
            Quantity = quantity;
            Warranty = warranty;
            GenericType = Classes.GenericType.Part;
           
        }

        public override void PrintInfo()
        {
            var quan = Quantity > 0 ? "Yes" : "No";
            var War = Warranty ? "Yes" : "No";
            Console.WriteLine($" {Id}) {Type} : {Name} / Price : {Price}eur - Discount: {Discount} / Mnyfacturer - {Company} / Warrenty : {War} / Stack : {quan}");
            Console.WriteLine("-------------------------------------------------------------------------------");
        }

        public override string PrintInfoShort()
        {
            return $"{Type} : {Name}";
        }
    }
}
