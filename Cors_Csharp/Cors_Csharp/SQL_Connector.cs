using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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
