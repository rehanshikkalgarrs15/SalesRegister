using SalesRegister.Common;
using SalesRegister.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SalesRegister
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CommonActions commonActions;
        public MainWindow()
        {
            InitializeComponent();
            commonActions = new CommonActions(this, new StartWindow(),5);
            commonActions.waitAndNavigateToAnotherWindow();
        }

    }
}
