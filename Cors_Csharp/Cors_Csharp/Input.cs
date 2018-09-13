using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using Microsoft.VisualBasic;
// using Microsoft.VisualBasic.FileIO;	

namespace Cors_Csharp
{
    class Program
    {
        static void Main()
        {
        	// Read weater data
        	var reader = new StreamReader(File.OpenRead("input_data/weather_data.csv"));
            List<string> searchList = new List<string>();

            while(!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                searchList.Add(line);

                string[] line_array = new string[] {""};
                line_array = line.Split(';');


                int year = 0;
                if (!Int32.TryParse(line_array[0], out year)){

                	Console.WriteLine("y");
                	continue;
                }

                int month = 0;
                if (! Int32.TryParse(line_array[1], out month)){
                	Console.WriteLine("m");
                	continue;
                } 

                int day = 0;
                if (! Int32.TryParse(line_array[2], out day)){
                	Console.WriteLine("d");
                	continue;
                }                

                int hour = 0;
                if (! Int32.TryParse(line_array[3], out hour)){
                	Console.WriteLine("h");
                	continue;
                }   

                float temperature = 0;
                if (! Int32.TryParse(line_array[5], out temperature)){
                	Console.WriteLine("t");
                	continue;
                }      

                float precipitation = 0;
                if (! Int32.TryParse(line_array[6], out precipitation)){
                	Console.WriteLine("p");
                	continue;
                }                                
                // int hour = line_array[3];

                // int temperature = line_array[5]; 
                // int precipitation = line_array[6]; 

                // Console.WriteLine(System.Convert.ToString(year));
            }

        	Console.WriteLine("Hello world");
        	Console.ReadKey();

        }
    }
}

