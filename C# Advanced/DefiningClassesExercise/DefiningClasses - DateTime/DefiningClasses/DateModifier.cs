using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public static class DateModifier
    {
        public static int CalculateDifference(string firstDateAsString, string secondDateAsString)
        {
            DateTime firstDate = DateTime.Parse(firstDateAsString);
            DateTime secondDate = DateTime.Parse(secondDateAsString);

            int result = Math.Abs((firstDate - secondDate).Days);

            return result;
        }

    }
}
