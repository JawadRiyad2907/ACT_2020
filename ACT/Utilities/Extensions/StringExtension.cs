using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACT.Utilities.Extensions
{
    public static class StringExtension
    {

        public static decimal? ToNullableDecimal(this string s)
        {
            decimal i;
            if (decimal.TryParse(s, out i)) return i;
            return null;
        }

    }
}