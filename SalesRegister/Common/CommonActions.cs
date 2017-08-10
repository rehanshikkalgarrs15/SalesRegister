using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows; 

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
    
        public void waitForNextOperation(int seconds) {
            System.Threading.Thread.Sleep(seconds * 1000);
        }

        public void waitAndNavigateToAnotherWindow()
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, time);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
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
    }
}
