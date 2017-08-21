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
using SalesRegister.Models;

namespace SalesRegister.Windows {
    /// <summary>
    /// Interaction logic for SalesRegisterWindow.xaml
    /// </summary>
    public partial class SalesRegisterWindow : Window {

        CommonActions commonActions;
        DialogUtils dialogUtils;
        DBConnection dbConnection;
        int billno;
        string partyname = string.Empty;
        string itemname = string.Empty;
        int bags = 0;
        double rate = 0;
        double amount = 0;
        double gst = 0;
        double sgst = 0;
        double cgst = 0;
        double total = 0;

        public SalesRegisterWindow()
        {
            InitializeComponent();
            commonActions = new CommonActions();
            dialogUtils = new DialogUtils(this);
            dbConnection = new DBConnection();
            gst_TB.PreviewKeyDown += EnterClicked_GST;
            rate_TB.PreviewKeyDown += EnterClicked_Rate;
            init();//function to generate bill no
        }

        public object CommandActions { get; private set; }

        public void Add_ITEM_Click(object sender, RoutedEventArgs e)
        { 
            if (commonActions.isEmptyString(partyname_TB.Text) ||
                commonActions.isEmptyString(itemname_TB.Text) || commonActions.isEmptyString(bags_TB.Text) ||
                commonActions.isEmptyString(rate_TB.Text) || commonActions.isEmptyString(amount_TB.Text) || commonActions.isEmptyString(gst_TB.Text)){
                dialogUtils.showConfirmationDialog("Alert!", "Enter Mandatory Values");
            }
            else {
                calculateTotalValue();
                int rowsEffeted = dbConnection.addItemToSalesRegister(new DateUtils().getTodaysDate(),
                                                    billno.ToString(), partyname, itemname, bags.ToString(), rate.ToString(),
                                                    amount.ToString(), gst_TB.Text, sgst_TB.Text, cgst_TB.Text, total.ToString(), "sales_register");
                if(rowsEffeted == 1)
                {
                    new DialogUtils(this).showConfirmationDialog("Success", "Added!!");
                    string previousBillValue = billno_TB.Text;
                    CommonActions.clearTextBox(this);
                    billno_TB.Text = previousBillValue;
                    total_value_lb.Content = string.Empty;
                    addItemToListBox();
                }
                else
                {
                    new DialogUtils(this).showConfirmationDialog("Failed", "Not Added!!");
                }
            }
        }
         

        public void addItemToListBox()
        {
            //make ListBox Horizontal 
            SalesRegisterModel salesRegister = new SalesRegisterModel(Convert.ToString(billno), Convert.ToString(partyname), Convert.ToString(itemname), Convert.ToString(bags), Convert.ToString(rate), Convert.ToString(amount), Convert.ToString(gst), Convert.ToString(sgst), Convert.ToString(cgst), Convert.ToString(total));
            List<string> salesRegisterList = new List<string>();
            salesRegisterList = salesRegister.getSalesRegisterItem();
            foreach(string values in salesRegisterList)
            {
                ListBoxItem listBoxItem = new ListBoxItem();
                listBoxItem.Content = values;
                added_items.Items.Add(listBoxItem);
            }
        }

        public void EnterClicked_GST(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (!commonActions.isEmptyString(gst_TB.Text))
                {
                    sgst_TB.Text = (Convert.ToDouble(gst_TB.Text) / 2).ToString();
                    cgst_TB.Text = (Convert.ToDouble(gst_TB.Text) / 2).ToString();
                    calculateTotalValue();
                    total_value_lb.Content = total.ToString();

                }
                e.Handled = true;
            }
        }

        public void EnterClicked_Rate(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (!commonActions.isEmptyString(rate_TB.Text))
                {
                    double amount = Convert.ToDouble(rate_TB.Text) * Convert.ToInt16(bags_TB.Text);
                    amount_TB.Text = amount.ToString();
                }
                e.Handled = true;
            }
        }

        public void init()
        {
            int genBillNo = dbConnection.generateBillNo("generate_billno");
            if (genBillNo == 0)
            {
                billno = 1;
                billno_TB.Text = billno.ToString();
            }
            else
            {
                billno = genBillNo + 1;
                billno_TB.Text = billno.ToString();
            }
        }

        public void calculateTotalValue()
        {
            partyname = partyname_TB.Text.ToString();
            itemname = itemname_TB.Text.ToString();
            bags = Convert.ToInt16(bags_TB.Text);
            rate = Convert.ToDouble(rate_TB.Text);
            amount = bags * rate;
            gst = Convert.ToDouble(gst_TB.Text);
            sgst = gst / 2;
            cgst = gst - sgst;
            double gst_value = amount * (gst / 100);
            double sgst_value = gst_value / 2;
            double cgst_value = gst_value / 2;
            total = sgst_value + cgst_value + amount;
        }
    }
}
