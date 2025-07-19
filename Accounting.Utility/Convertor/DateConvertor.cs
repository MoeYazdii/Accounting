using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Utility.Convertor
{
    public static class DateConvertor
    {
        public static string ToShamsi(this DateTime datetime)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(datetime) + "/" + pc.GetMonth(datetime).ToString("00") + "/" +
                pc.GetDayOfMonth(datetime).ToString("00");
        }
        public static DateTime ToMiladi(this DateTime datetime)
        {
            return new DateTime(datetime.Year, datetime.Month, datetime.Day, new System.Globalization.PersianCalendar());
        }
    }
}
