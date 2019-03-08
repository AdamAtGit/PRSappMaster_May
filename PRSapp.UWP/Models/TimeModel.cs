using System;
using System.ComponentModel;
using System.Diagnostics;
using Windows.ApplicationModel;

namespace PRSapp.UWP.Models
{
    public class TimeModel : INotifyPropertyChanged
    {

        ////Initialize someDateTime with a default value
        //private DateTime someDateTime = DateTime.Parse("07/21/1969 2:56AM");
        //public DateTime SomeDateTime
        //{
        //    get { return someDateTime;}
        //    set
        //    {
        //        someDateTime = value;
        //        OnPropertyChanged("SomeDateTime");
        //    }
        //}

        //public TimeSpan SomeDateTimeTimeSpanProxy
        //{
        //    get
        //    {

        //        //Debug.WriteLine("Getter -before \n SomeDateTimeTimeSpanProxy.ToString(\"T\")");
        //        //Debug.WriteLine(SomeDateTimeTimeSpanProxy.ToString("T"));

        //        //Debug.WriteLine((someDateTime - someDateTime.Date).ToString("T"));
        //        //Debug.WriteLine("Getter -before \n someDateTime - someDateTime.Date");
        //        //Extract timespan from orig datetime
        //        return someDateTime - someDateTime.Date;

        //    }
        //    set
        //    {
        //        //check if timespan is different from current value
        //        if (SomeDateTimeTimeSpanProxy != value)
        //        {
        //            //If it is, set the original datetime
        //            //to the original date, plus the new timespan value
        //            SomeDateTime = someDateTime.Date.Add(value);
        //            //Raise the PropertyChanged event for the timespan property
        //            OnPropertyChanged("SomeDateTimeTimeSpanProxy");

        //            Debug.WriteLine("Setter -After RaiseProp \n SomeDateTimeTimeSpanProxy.ToString(\"T\")");
        //            Debug.WriteLine(SomeDateTimeTimeSpanProxy.ToString("T"));
        //        }
        //    }
        //}

        private string splayTime;
        public string sPlayTime
        {
            get
            {
                return tsPlayTime.ToString("T");
            }
            set
            {
                splayTime = value;
                OnPropertyChanged("sPlayTime");
            }
        }

        private TimeSpan tsplayTime;
        public TimeSpan tsPlayTime
        {
            get
            {
                return tsplayTime;
            }
            set
            {
                tsplayTime = value;
                OnPropertyChanged("tsPlayTime");
                OnPropertyChanged("sPlayTime");
            }
        }

        //Initialize with any default val
        TimeSpan ts = new TimeSpan(11, 14, 23);

        public TimeModel()
        {
            if (DesignMode.DesignModeEnabled)
            {
                tsPlayTime = ts;
                sPlayTime = ts.ToString("T");
            }
            //  sPlayTime = ts.ToString("T");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
