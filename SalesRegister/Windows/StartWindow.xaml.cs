using SalesRegister.Common;
using SalesRegister.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        DateUtils dateutils;
        CommonActions commonActions;
        public StartWindow()
        {
            InitializeComponent();
            dateutils = new DateUtils(this);
            commonActions = new CommonActions(this);
            CommonActions.printOnConsole(dateutils.getCurrentTime().ToString());
            CommonActions.printOnConsole(dateutils.getTodaysDate().ToString());
        }

        private void add_item_window(object sender, RoutedEventArgs e)
        {
            commonActions.openNewWindow(new AddItemWindow());
        }

        private void sales_register_window(object sender, RoutedEventArgs e)
        {

        }
    }
}
