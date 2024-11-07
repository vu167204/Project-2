using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom1.Helpers
{
    public class AppHelper
    {
        public static string FormatMoney(double amount)
        {
            return FormatNumber(amount) + "₫";
        }

        public static string FormatNumber(double amount)
        {
            var str = ReverseString(amount.ToString());
            List<string> arr = new List<string>();

            while (str.Length > 0)
            {
                arr.Add(str.Substring(0, str.Length > 2 ? 3 : str.Length));
                str = str.Substring(str.Length > 2 ? 3 : str.Length);
            }
            str = string.Join(".", arr.ToArray());

            return ReverseString(str);
        }

        public static string ReverseString(string str)
        {
            var arr = str.ToCharArray();
            Array.Reverse(arr);

            return string.Join("", arr);
        }

        public static bool IsEmptyString(string str)
        {
            return str == null || str.Trim() == "";
        }
    }
}