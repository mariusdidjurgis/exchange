using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange
{
    public static class EnumHelper
    {
        public static Currency? StringToCurrency(this string value)
        {
            if (!Enum.TryParse<Currency>(value, true, out Currency currency))
                return null;

            return currency;
        }
    }
}
