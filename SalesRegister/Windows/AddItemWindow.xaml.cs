using SalesRegister.Common;
using SalesRegister.DB;
using SalesRegister.Models;
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
        ListView listview;
        CommonActions commonActions;
        public AddItemWindow()
        {
            InitializeComponent();
            listview = new ListView();
            dialogUtils = new DialogUtils(this);
            dbconnection = new DBConnection();
            commonActions = new CommonActions();
            init();//show previously added items
        }

        public void addItemToDatabase(object sender, RoutedEventArgs e)
        {
            string itemNameTB = item_name.Text;
            if (commonActions.isEmptyString(itemNameTB)){
                dialogUtils.showConfirmationDialog("Alert!!", "Enter valid value in TextBox!");
            }
            else{
                int result = dbconnection.addItem(itemNameTB, "add_item");
                if(result == 0) {
                    dialogUtils.showConfirmationDialog("Alert", "Item Already exists");
                }
                else {
                    dialogUtils.showConfirmationDialog("Success", "Item added successfully");
                    item_name.Clear();
                    init();
                }
            }
            
        }


        public void init() {
            List<Item> listItems = dbconnection.getAddedItems("get_items");
            foreach(Item item in listItems)
            {
                added_item.Items.Add(item.ItemName);
            }
        }
    }
}
