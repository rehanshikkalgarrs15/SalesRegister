using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalesRegister.Utils
{
    class DialogUtils
    {
        Window window;
        public DialogUtils(Window window) {
            this.window = window;
        }

        public void showConfirmationDialog(string title, string message) {
           MessageBox.Show(message, title);
        }
    }
}
