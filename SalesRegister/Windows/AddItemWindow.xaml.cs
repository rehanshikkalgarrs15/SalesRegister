using SalesRegister.DB;
using SalesRegister.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SalesRegister.Windows
{
    /// <summary>
    /// Interaction logic for AddItemWindow.xaml
    /// </summary>
    public partial class AddItemWindow : Window
    {
        DialogUtils dialogUtils;
        DBConnection dbconnection;

        public AddItemWindow()
        {
            InitializeComponent();
            dialogUtils = new DialogUtils(this);
            dbconnection = new DBConnection();
        }

        private void addItemToDatabase(object sender, RoutedEventArgs e)
        {
            if (dbconnection.openConnection()){
                dialogUtils.showConfirmationDialog("Items", "Items Added Successfuly");

            }
        }
    }
}
