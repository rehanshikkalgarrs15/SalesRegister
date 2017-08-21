using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SalesRegister.Common
{
    class CommonActions
    {
        Window currentWindow, newWindow;
        int time;
        System.Windows.Threading.DispatcherTimer dispatcherTimer;

        public CommonActions(Window currentWindow, Window newWindow, int time){
            this.currentWindow = currentWindow;
            this.newWindow = newWindow;
            this.time = time;
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        }

        public CommonActions(Window window) {
            this.currentWindow = window;
        }
    
        public CommonActions()
        {

        }
        public void waitForNextOperation(int seconds) {
            System.Threading.Thread.Sleep(seconds * 1000);
        }

        public void waitAndNavigateToAnotherWindow()
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, time);
            dispatcherTimer.Start();
        }

        public void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                currentWindow.Close();
                newWindow.ShowDialog();
            }
            catch (Exception exe)
            {
                Console.WriteLine(exe);
            }
        }

        public void openNewWindow(Window newWindow) {
            try {
                bool isOpen = false;
                if (!isOpen) {
                    newWindow.ShowDialog();
                    isOpen = true;
                }
            }
            catch(Exception exe) {
                CommonActions.printOnConsole(exe.ToString());
            }
        }

        public static void printOnConsole(string message) {
            Debug.WriteLine(message);
        }

        public bool isEmptyString(string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static void clearTextBox(Visual myWindow)
        {
            int childrenCount = VisualTreeHelper.GetChildrenCount(myWindow);
            for (int i = 0; i < childrenCount; i++)
            {
                var visualChild = (Visual)VisualTreeHelper.GetChild(myWindow, i);
                if (visualChild is TextBox)
                {
                    TextBox tb = (TextBox)visualChild;
                    tb.Clear();
                }
                clearTextBox(visualChild);
            }
        }
    }
}
