using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.Classes
{
    public class DecimalFormat
    {
        public string DoFormat(decimal? myNumber)
        {
            var s = string.Format("{0:0.00}", myNumber);

            if (s.EndsWith("00"))
            {
                return ((int)myNumber).ToString();
            }
            else
            {
                return s;
            }
        }
    }
}