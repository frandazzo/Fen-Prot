using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions.Forms.Utility
{
    public class MonthYearSuggest
    {
        private static int _currentMonth = DateTime.Now.Month;
        private static int _currentYear = DateTime.Now.Year;

        private static string GetCurrentMonthName()
        {
            DateTime t = new DateTime(_currentYear, _currentMonth, 1);
            return t.ToString("MMM", new CultureInfo("it-IT"));
        }


        public static string GetDefaultPeriod()
        {
            return string.Format("{0} {1}", GetCurrentMonthName(), _currentYear.ToString());
        }

        public static void SetCurrentMonth(int month)
        {
            if (month > 0 && month < 13)
                _currentMonth = month;
            else
                throw new ArgumentException("Numero mese non corretto");
        }

        public static void SetCurrentYear(int year)
        {
            if (year > 1990 && year < 3099)
                _currentYear = year;
            else
                throw new ArgumentException("Anno non corretto");
        }


        public static int CurrentMonth
        {
            get { return _currentMonth; }
        }

        public static int CurrentYear
        {
            get { return _currentYear; }
        }

    }
}
