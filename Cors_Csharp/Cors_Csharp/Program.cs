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
            
            SQL_Connector Connector = new SQL_Connector();
            Connector.Read("steps_amount", "steps");
            Connector.InsertTestingDataAll();
            
            

        }

        
    }
}
