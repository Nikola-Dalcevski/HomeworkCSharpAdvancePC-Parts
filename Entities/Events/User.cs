using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Events
{
    public class User
    {
        public string Username { get; set; }

        public User(string username)
        {
            Username = username;
        }
        public void GetSms (string message)
        {
            Console.WriteLine("The user get Sms message");
            Console.WriteLine("------------------");
            Console.WriteLine(message);
            Console.WriteLine("*************************************");
        }
        public void GetEmail (string message)
        {
            Console.WriteLine("The user get Email");
            Console.WriteLine("------------------");
            Console.WriteLine(message);
            Console.WriteLine("*************************************");
        }
        public void GetMail (string message)
        {
            Console.WriteLine("The user get Post Mail");
            Console.WriteLine("------------------");
            Console.WriteLine(message);
            Console.WriteLine("*************************************");
        }
    }
}
