using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        private int diff;

        public int Difference { get; set; }
        public void FindDifference(string date1, string date2)
        {
            string[] dateData1 = date1.Split(" ");
            string[] dateData2 = date2.Split(" ");
            int year1 = int.Parse(dateData1[0]);
            int month1 = int.Parse(dateData1[1]);
            int day1 = int.Parse(dateData1[2]);
            int year2 = int.Parse(dateData2[0]);
            int month2 = int.Parse(dateData2[1]);
            int day2 = int.Parse(dateData2[2]);
            DateTime date1Parsed = new DateTime(year1, month1, day1);
            DateTime date2Parsed = new DateTime(year2, month2, day2);
            double days = Math.Abs(date1Parsed.Subtract(date2Parsed).TotalDays);
            Console.WriteLine(days);
        }
    }
}
