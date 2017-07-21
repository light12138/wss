using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Testlogger
{
    public static class HeaperString
    {
        public static int ToInt(this string str)
        {
            int i;
            int.TryParse(str, out i);
            return i;
           
        } 


        public static List<T> ListOrderby<T>(this List<T> list)
        {
            var f = list.First();
            var l = list.Last();
            return new List<T>() { f, l };
        }
    }
}
