1) Install VisualStudio

2) Install MySql Server.

3) Install MySql Workbench.

4) Install MySql Conenctor.

5) Goto->Solution Explorer -> Project -> References -> Right Click -> Add Reference -> Extension - Mysql.Data -> click OK

DataBase Connection Code:

        public DBConnection() {
            server = "localhost";
            database = "DataBaseName";
            uid = "username";
            password = "password";
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
        private bool closeConnection(){
            try{
                connection.Close();
                return true;
            }
            catch (MySqlException ex){
                MessageBox.Show(ex.Message);
                return false;
            }
        }
