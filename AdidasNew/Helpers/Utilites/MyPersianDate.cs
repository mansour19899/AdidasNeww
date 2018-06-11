using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public static class PersianDate
    {
        public static DateTime ToGeorgianDateTime(this string persianDate)
        {
            int year = Convert.ToInt32(persianDate.Substring(0, 4));
            int month = Convert.ToInt32(persianDate.Substring(5, 2));
            int day = Convert.ToInt32(persianDate.Substring(8, 2));
            DateTime georgianDateTime = new DateTime(year, month, day, new System.Globalization.PersianCalendar());
            return georgianDateTime;
        }

        public static string ToPersianDateString(this DateTime georgianDate)
        {
            System.Globalization.PersianCalendar persianCalendar = new System.Globalization.PersianCalendar();

            string year = persianCalendar.GetYear(georgianDate).ToString();
            string month = persianCalendar.GetMonth(georgianDate).ToString().PadLeft(2, '0');
            string day = persianCalendar.GetDayOfMonth(georgianDate).ToString().PadLeft(2, '0');
            string persianDateString = string.Format("{0}/{1}/{2}", year, month, day);
            return persianDateString;
        }
        public static string AddDaysToShamsiDate(this string persianDate, int days)
        {
            DateTime dt = persianDate.ToGeorgianDateTime();
            dt = dt.AddDays(days);
            return dt.ToPersianDateString();
        }
        public static string ToPersianday(this string persianDate)
        {
            System.Globalization.PersianCalendar persianCalendar = new System.Globalization.PersianCalendar();

            DateTime dt = persianDate.ToGeorgianDateTime();
            var day = dt.DayOfWeek;
            string dayy="";
            switch (day)
            {
                case DayOfWeek.Friday:
                    dayy = "جمعه"; 
                     break;
                case DayOfWeek.Saturday:
                    dayy = "شنبه";
                    break;
                case DayOfWeek.Sunday:
                    dayy = "یک شنبه";
                    break;
                case DayOfWeek.Monday:
                    dayy = "دوشنبه";
                    break;
                case DayOfWeek.Tuesday:
                    dayy = "سه شنبه";
                    break;
                case DayOfWeek.Wednesday:
                    dayy = "چهارشنبه";
                    break;
                case DayOfWeek.Thursday:
                    dayy = "پنج شنبه";
                    break;
            }
            return dayy;
        }

        public static int DiffDaysShamsi(this string FirstDate, string SecondtDate)
        {
            DateTime dt = FirstDate.ToGeorgianDateTime();
            DateTime dtt = SecondtDate.ToGeorgianDateTime();
            TimeSpan dif = dt - dtt;
            
            return dif.Days;
        }
    }
