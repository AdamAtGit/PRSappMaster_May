using System;
using System.Diagnostics;

namespace PRSapp.UWP.CustomHelperClasses
{
    public class CondenseDay
    {
        TimeSpan span12 = new TimeSpan(0, 0, 720);
        TimeSpan spanDecrementBase = new TimeSpan(0, 0, 40);
        TimeSpan spanDecrementAmt = new TimeSpan(0, 0, 0);

        const int dayPart1 = 0; //MMM 
                                //90
        TimeSpan dayPart2 = new TimeSpan(0, 0, 90);
        //210
        TimeSpan dayPart3 = new TimeSpan(0, 0, 300);
        //420
        TimeSpan dayPart4 = new TimeSpan(0, 0, 720);
        //530
        // TimeSpan dayPart5 = new TimeSpan(0, 0, 1230);

        public void CondenseTo10Hrs(TimeSpan _dayPart2, TimeSpan _dayPart3, TimeSpan _dayPart4)
        {
            spanDecrementAmt = spanDecrementAmt.Add(spanDecrementBase);
            _dayPart2 = dayPart2.Subtract(spanDecrementAmt);
            _dayPart3 = dayPart3.Subtract(spanDecrementAmt);
            _dayPart4 = dayPart4.Subtract(spanDecrementAmt);

            #region Debugging
            Debug.WriteLine("________________________________________");
            Debug.WriteLine("Hit CondenseDays.cs");
            Debug.Write("spanDecrementAmt.TotalSeconds: ");
            Debug.WriteLine(spanDecrementAmt.TotalSeconds.ToString());
            Debug.WriteLine("_dayPart2 :{0} \n_dayPart3 :{1} \n_dayPart4 :{2}",
                            _dayPart2.ToString(), _dayPart3.ToString(), _dayPart4.ToString());
            Debug.WriteLine("_________________________________________\n");
            #endregion
        }
    }
}