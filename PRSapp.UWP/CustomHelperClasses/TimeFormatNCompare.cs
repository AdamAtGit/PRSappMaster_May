using System;
using System.Diagnostics;

namespace PRSapp.UWP.CustomHelperClasses
{
    public class TimeFormatNCompare
    {
        public string TimeStringFormatter(string _sTime)
        {
            string sOutputTime;
            //14:00:00
            string sInputTime = _sTime;//TimePicker TimeSPan 
            if (sInputTime.EndsWith("M"))
            {

                return sInputTime;
            }
            else
            {
                #region time format conversion
                string sub = sInputTime.Substring(0, 3);
                if (sub == "00:")
                {
                    sOutputTime = sInputTime.Replace("00:", "12:") + " AM";
                }
                else if (sub == "01:")
                {
                    sOutputTime = sInputTime.Replace("01:", "1:") + " AM";
                }
                else if (sub == "02:")
                {
                    sOutputTime = sInputTime.Replace("02:", "2:") + " AM";
                }
                else if (sub == "03:")
                {
                    sOutputTime = sInputTime.Replace("03:", "3:") + "AM";
                }
                else if (sub == "04:")
                {
                    sOutputTime = sInputTime.Replace("04:", "4:") + " AM";
                }
                else if (sub == "05:")
                {
                    sOutputTime = sInputTime.Replace("05:", "5:") + " AM";
                }
                else if (sub == "06:")
                {
                    sOutputTime = sInputTime.Replace("06:", "6:") + " AM";
                }
                else if (sub == "07:")
                {
                    sOutputTime = sInputTime.Replace("07:", "7:") + " AM";
                }
                else if (sub == "08:")
                {
                    sOutputTime = sInputTime.Replace("08:", "8:") + " AM";
                }
                else if (sub == "09:")
                {
                    sOutputTime = sInputTime.Replace("09:", "9:") + " AM";
                }
                else if (sub == "10:")
                {
                    sOutputTime = sInputTime.Replace("10:", "10:") + " AM";
                }
                else if (sub == "11:")
                {
                    sOutputTime = sInputTime.Replace("11:", "11:") + " AM";
                }
                else if (sub == "12:")
                {
                    sOutputTime = sInputTime.Replace("12:", "12:") + " PM";
                }
                else if (sub == "13:")
                {
                    sOutputTime = sInputTime.Replace("13:", "1:") + " PM";
                }
                else if (sub == "14:")
                {
                    sOutputTime = sInputTime.Replace("14:", "2:") + " PM";
                }
                else if (sub == "15:")
                {
                    sOutputTime = sInputTime.Replace("15:", "3:") + " PM";
                }
                else if (sub == "16:")
                {
                    sOutputTime = sInputTime.Replace("16:", "4:") + " PM";
                }
                else if (sub == "17:")
                {
                    sOutputTime = sInputTime.Replace("17:", "5:") + " PM";
                }
                else if (sub == "18:")
                {
                    sOutputTime = sInputTime.Replace("18:", "6:") + " PM";
                }
                else if (sub == "19:")
                {
                    sOutputTime = sInputTime.Replace("19:", "7:") + " PM";
                }
                else if (sub == "20:")
                {
                    sOutputTime = sInputTime.Replace("20:", "8:") + " PM";
                }
                else if (sub == "21:")
                {
                    sOutputTime = sInputTime.Replace("21:", "9:") + " PM";
                }
                else if (sub == "22:")
                {
                    sOutputTime = sInputTime.Replace("22:", "10:") + " PM";
                }
                else if (sub == "23:")
                {
                    sOutputTime = sInputTime.Replace("23:", "11:") + " PM";
                }
                else
                    sOutputTime = "unknown";
                #endregion

            }
            return sOutputTime;
        }

        public bool TimesMatched(string _sSchedTime, string _sCurrentTime)
        {
            bool bTimesMatched = false;
            string sSchedTime = _sSchedTime.Trim();
            string sCurrentTime = _sCurrentTime.Trim();

            if (sSchedTime == null || sCurrentTime == null)
            {
                Debug.WriteLine("A Time value was null\n" +
                    "sSchedTime:\t{0}\tsCurrentTime:\t{1}",
                    sSchedTime.ToString(), sCurrentTime.ToString());

                return bTimesMatched;
            }
            if (sSchedTime == sCurrentTime)
            {
                bTimesMatched = true;
            }
            return bTimesMatched;
        }


        ////    Usage Example   //////
        //  using CustomHelperClasses;
        //  TimeFormatNCompare tFnC = new TimeFormatNCompare();
        //  string sOut = TimeStringFormatter(sTimePickerTime);
        //  bool bMatchHit = TimesMatched(sOut, CurrentTime);

        ////  Raise Event and handler delgate etc. ////
        //  if(bMatchHit == true)
        //  { 
        //    Raise EventHandler PlayAsyncSynth(string sPlayCommandName);
        //  }
        //  public delegate += PlayAsyncSynth("AsyncSynthXYZCommand");


    }
}
