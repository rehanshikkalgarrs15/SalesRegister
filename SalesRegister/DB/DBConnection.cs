using MySql.Data.MySqlClient;
using SalesRegister.Common;
using SalesRegister.Models;
using SalesRegister.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalesRegister.DB
{
    class DBConnection
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;


        public DBConnection() {
            server = "localhost";
            database = "Sales";
            uid = "root";
            password = "REHAN123@rehan123@";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }


        //open connection to database
        public bool openConnection() {
            try{
                connection.Open();
                return true;
            }
            catch (MySqlException ex){
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number){
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        public bool closeConnection(){
            try{
                connection.Close();
                return true;
            }
            catch (MySqlException ex){
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public string getConnectionString() {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString.ToString();
            return connectionString;
        }


        public List<Item> getAddedItems(string SPName)
        {
            List<Item> items = new List<Item>();
            string connectionString = getConnectionString();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(SPName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Item item = new Item(reader.GetValue(0).ToString());
                            items.Add(item);
                        }
                    }
                    command.Connection.Close();
                }
            }
            return items;
        }

        public int addItem(string itemName, string SPName)
        {
            int success = 1, failed = 0;
            try
            {
                string connectionString = getConnectionString();
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(SPName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new MySqlParameter("itemname", itemName));
                        connection.Open();
                        command.ExecuteNonQuery();

                        command.Connection.Close();
                    }
                }
                return success;
            }
            catch(Exception exe)
            {
                CommonActions.printOnConsole(exe.ToString());
                return failed;
            }
        }

        public int addItemToSalesRegister(string date, string billno, string partyname, string itemname,
                                            string bags, string rate, string amount, string gst,
                                            string sgst, string cgst, string total, string SPName)
        {
            int rowsEffected = 0;
            try
            {
                string connectionString = getConnectionString();
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(SPName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new MySqlParameter("todaydate", date));
                        command.Parameters.Add(new MySqlParameter("billno", billno));
                        command.Parameters.Add(new MySqlParameter("partyname", partyname));
                        command.Parameters.Add(new MySqlParameter("item", itemname));
                        command.Parameters.Add(new MySqlParameter("bags", bags));
                        command.Parameters.Add(new MySqlParameter("rate", rate));
                        command.Parameters.Add(new MySqlParameter("amount", amount));
                        command.Parameters.Add(new MySqlParameter("gst", gst));
                        command.Parameters.Add(new MySqlParameter("sgst", sgst));
                        command.Parameters.Add(new MySqlParameter("cgst", cgst));
                        command.Parameters.Add(new MySqlParameter("total", total));
                        connection.Open();
                        rowsEffected = command.ExecuteNonQuery();
                        command.Connection.Close();
                    }
                }
                return rowsEffected;
            }
            catch (Exception exe)
            {
                CommonActions.printOnConsole(exe.ToString());
                return rowsEffected;
            }
        }

    }
}
