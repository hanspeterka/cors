using System.IO;
using System;

namespace Cors_Csharp
{
    class Input
    {

        // static void Main()
        // {
        //     InputMain();
        // }

        static void InputMain()
        {
            string[] line_array = new string[] {""};
            string sql_insert="";

        	// Read weater data
        	var reader = new StreamReader(File.OpenRead("input_data/weather_data.csv"));
            while(!reader.EndOfStream)
            {
                line_array = reader.ReadLine().Split(';');

                int year = 0;
                if (!Int32.TryParse(line_array[0], out year)) { continue; }

                int month = 0;
                if (!Int32.TryParse(line_array[1], out month)) { continue; }

                int day = 0;
                if (!Int32.TryParse(line_array[2], out day)) { continue; }

                int hour = 0;
                if (!Int32.TryParse(line_array[3], out hour)) { continue; }

                DateTime datetime_1 = new DateTime(year, month, day, hour, 0, 0, 0);

                float temperature = 0;
                if (!float.TryParse(line_array[5], out temperature)) { continue; }

                float precipitation = 0;
                if (!float.TryParse(line_array[6], out precipitation)) { continue; }


                sql_insert = "INSERT INTO weather (datetime, temperature, precipitation) VALUES ('" + datetime_1 + "','" + temperature + "', '" + precipitation + "');";

                Console.WriteLine(sql_insert);
                // Insert to database
            }

            reader = new StreamReader(File.OpenRead("input_data/steps_data.csv"));

            while(!reader.EndOfStream)
            {
                line_array = reader.ReadLine().Split(',');

                int steps_amount = 0;
                if (!Int32.TryParse(line_array[13], out steps_amount)) { continue; }

                DateTime datetime_2 = Convert.ToDateTime(line_array[0]).Date;

                sql_insert = "INSERT INTO steps (date, steps_amount) VALUES ('" + datetime_2 + "', '" + steps_amount + "');";

                Console.WriteLine(sql_insert);
                // Insert into database


            }
        }
    }
}



