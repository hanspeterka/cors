using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cors_Csharp
{
    public class SQL_Connector
    {
         
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public SQL_Connector()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "b8rg15mwxwynuk9q.chr7pe7iynqr.eu-west-1.rds.amazonaws.com";
            database = "eqxcz2kk2ha68vfu";
            uid = "t2z7d0zkf4b9m6wu";
            password = "rdk1h2wz1d5eishy";

            string connectionString;
            connectionString = "server=" + server + ";" + "database=" +
            database + ";" + "uid=" + uid + ";" + "password=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connection open");
                Console.ReadKey();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        Console.ReadKey();
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        Console.ReadKey();
                        break;

                    case 1042:
                        Console.WriteLine("Unable to connect");
                        Console.ReadKey();
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

          

        //Read statement
        public void Read(string columnName, string tableName)
        {
            string query = "SELECT (" + columnName +") FROM " + tableName;
            List<float> list = new List<float>();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    list.Add(dataReader.GetFloat(0));
                   

                }
                          
                
                dataReader.Close();
                this.CloseConnection();
            }
        }

        //Insert statement
        public void InsertTestingDataAll()
        {
            string[] line_array = new string[] {""};
            string query="";

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


                query = "INSERT INTO weather (datetime, temperature, precipitation) VALUES ('" + datetime_1 + "','" + temperature + "', '" + precipitation + "');";
                // Insert to database
                if (this.OpenConnection() == true)
                {
                    try
                    {
                        MySqlCommand cmd_weather = new MySqlCommand(query, connection);
                        cmd_weather.ExecuteNonQuery();
                        Console.WriteLine("Weather data inserted.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                    this.CloseConnection();
                }
            }

            reader = new StreamReader(File.OpenRead("input_data/steps_data.csv"));

            while(!reader.EndOfStream)
            {
                line_array = reader.ReadLine().Split(',');

                int steps_amount = 0;
                if (!Int32.TryParse(line_array[13], out steps_amount)) { continue; }

                DateTime datetime_2 = Convert.ToDateTime(line_array[0]).Date;

                query = "INSERT INTO steps (date, steps_amount) VALUES ('" + datetime_2 + "', '" + steps_amount + "');";

                // Insert into database
                if (this.OpenConnection() == true)
                {
                    try
                    {
                        MySqlCommand cmd_steps = new MySqlCommand(query, connection);
                        cmd_steps.ExecuteNonQuery();
                        Console.WriteLine("Steps data inserted.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                    this.CloseConnection();
                }

            }


        }
        //Update statement
        public void Update()
        {
        }

        //Delete statement
        public void Delete()
        {
        }

        //Select statement
        //public List<string>[] Select()
        //{
        //}

        //Count statement
        //public int Count()
        //{
        //}

        //Backup
        //public void Backup()
        //{
        //}

        //Restore
        public void Restore()
        {
        }
        
    }
}
