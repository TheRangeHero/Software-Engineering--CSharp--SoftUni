using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateModifier
{
    public class DateModifier
    {
        public static int DateDifference(string startDateAsString, string endDateAsString)
        {
            DateTime startDate = DateTime.Parse(startDateAsString);
            DateTime endDate = DateTime.Parse(endDateAsString);

            return Math.Abs((endDate - startDate).Days);
        }
    }
}
