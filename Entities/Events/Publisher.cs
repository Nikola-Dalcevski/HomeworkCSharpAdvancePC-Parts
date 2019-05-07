using Entities.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entities.Events
{
    public class Publisher
    {
        public delegate void DataProcessingDelegate(string message);
        public event DataProcessingDelegate DataProcessingHandler;
        public string message = "";
        public void ProcessingData(string messagee)
        {
           
            message += messagee;
            Console.WriteLine("Processing data...");
            Thread.Sleep(3000);
            Console.Clear();
            WhenDataIsProcessed(message);
        }

        protected void WhenDataIsProcessed(string message)
        {
            if(DataProcessingHandler != null)
            {
                DataProcessingHandler(message);
            }
        }
    }
}
