using System.Globalization;

namespace _378daftarkhoneh.Models
{
    public static class PersianDateHelper
    {
        private static readonly PersianCalendar pc = new PersianCalendar();

        public static string ToPersianDigits(string input)
        {
            var persianDigits = new string[] { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
            for (int i = 0; i < 10; i++)
            {
                input = input.Replace(i.ToString(), persianDigits[i]);
            }
            return input;
        }

        public static string ToPersianDate(DateTime date)
        {
            var dateString = $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00}";
            return ToPersianDigits(dateString);
        }

        public static string ToPersianDateWithTime(DateTime date)
        {
            var dateTimeString = $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00} - {date:HH:mm}";
            return ToPersianDigits(dateTimeString);
        }

        public static string GetTodayPersian()
        {
            var today = DateTime.Now;
            return ToPersianDate(today);
        }

        public static string GetPersianDayName(DateTime date)
        {
            var dayNames = new string[] { "یکشنبه", "دوشنبه", "سه‌شنبه", "چهارشنبه", "پنج‌شنبه", "جمعه", "شنبه" };
            return dayNames[(int)date.DayOfWeek];
        }

        public static string GetPersianMonthName(int month)
        {
            var monthNames = new string[]
            {
                "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور",
                "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"
            };
            return monthNames[month - 1];
        }

        public static string ToPersianDateLong(DateTime date)
        {
            var persianDay = pc.GetDayOfMonth(date);
            var persianMonth = pc.GetMonth(date);
            var persianYear = pc.GetYear(date);
            var dayName = GetPersianDayName(date);
            var monthName = GetPersianMonthName(persianMonth);

            return $"{dayName} {ToPersianDigits(persianDay.ToString())} {monthName} {ToPersianDigits(persianYear.ToString())}";
        }

        public static string GetTodayPersianLong()
        {
            var today = DateTime.Now;
            return ToPersianDateLong(today);
        }
    }
} 