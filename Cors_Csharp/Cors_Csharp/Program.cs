using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cors_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string Hello = "Hello world";
            Console.WriteLine(Hello);
            Console.WriteLine("Press Any Key");
            Console.ReadKey();
            SQL_Connector Connector = new SQL_Connector();
            Connector.listOfData();

        }

        
    }
}
