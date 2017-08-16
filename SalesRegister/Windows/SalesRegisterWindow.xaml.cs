using SalesRegister.Common;
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

namespace SalesRegister.Windows {
    /// <summary>
    /// Interaction logic for SalesRegisterWindow.xaml
    /// </summary>
    public partial class SalesRegisterWindow : Window {

        CommonActions commonActions;
        DialogUtils dialogUtils;
        DBConnection dbConnection;

        public SalesRegisterWindow()
        {
            InitializeComponent();
            commonActions = new CommonActions();
            dialogUtils = new DialogUtils(this);
            dbConnection = new DBConnection();
            gst_TB.PreviewKeyDown += EnterClicked;
        }

        public void Add_ITEM_Click(object sender, RoutedEventArgs e)
        {
            int billno = 0;
            string partyname = string.Empty;
            string itemname = string.Empty;
            int bags = 0;
            double rate = 0;
            double amount = 0;
            double gst = 0;
            double sgst = 0;
            double cgst = 0;
            double total = 0;

            //billno = Convert.ToInt16(billno_TB.Text);
            billno = 1456;
            partyname = partyname_TB.Text.ToString();
            itemname = itemname_TB.Text.ToString();
            bags = Convert.ToInt16(bags_TB.Text);
            rate = Convert.ToDouble(rate_TB.Text);
            amount = Convert.ToDouble(amount_TB.Text);
            gst = Convert.ToDouble(gst_TB.Text);
            sgst = gst / 2;
            cgst = gst - sgst;
            
            if(commonActions.isEmptyString(partyname) ||
                commonActions.isEmptyString(itemname) || commonActions.isEmptyString(bags_TB.Text) ||
                commonActions.isEmptyString(rate_TB.Text) || commonActions.isEmptyString(amount_TB.Text) || commonActions.isEmptyString(gst_TB.Text)){
                dialogUtils.showConfirmationDialog("Alert!", "Enter Mandatory Values");
            }
            else {
                int rowsEffeted = dbConnection.addItemToSalesRegister(new DateUtils().getTodaysDate(),
                                                    billno.ToString(), partyname, itemname, bags.ToString(), rate.ToString(),
                                                    amount.ToString(), gst.ToString(), sgst.ToString(), cgst.ToString(), total.ToString(), "sales_register");
                if(rowsEffeted == 1)
                {
                    new DialogUtils(this).showConfirmationDialog("Success", "Added!!");
                }
                else
                {
                    new DialogUtils(this).showConfirmationDialog("Failed", "Not Added!!");
                }
            }
        }

        public void EnterClicked(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (!commonActions.isEmptyString(gst_TB.Text))
                {
                    sgst_TB.Text = (Convert.ToDouble(gst_TB.Text) / 2).ToString();
                    cgst_TB.Text = (Convert.ToDouble(gst_TB.Text) / 2).ToString();
                }
                e.Handled = true;
            }
        }
    }
}
