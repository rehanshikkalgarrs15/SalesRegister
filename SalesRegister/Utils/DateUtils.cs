using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalesRegister.Utils
{
    class DateUtils
    {
        Window window;
        DateTime dateTime;
        public DateUtils(Window window)
        {
            this.window = window;
            dateTime = DateTime.Now;
        }

        public DateUtils()
        {
            dateTime = DateTime.Now;
        }
        public string getTodaysDate()
        {
            string date = dateTime.Date.ToString("dd/M/yyyy");
            return date;
        }

        public string getCurrentTime()
        {
            string time = dateTime.ToString("hh:mm:ss");
            return time;
        }
    }
}
