using System;
using System.ComponentModel;
using Windows.ApplicationModel;

namespace PRSapp.UWP.Models
{
    public class SpeechModel : INotifyPropertyChanged
    {
        private bool isCmdMode;
        public bool IsCmdMode
        {
            get { return isCmdMode = false; }
            set { isCmdMode = value; }
        }

        public int Forcerepeats { get; set; }

        //note this will need to go into observeable collection
        //as there will be many.
        private TimeSpan playTime;

        public TimeSpan PlayTime
        {
            get
            {
                return playTime;
            }
            set
            {
                playTime = value;
                OnPropertyChanged("PlayTime");
            }
        }

        private string splayTime;
        public string sPlayTime
        {

            get
            {
                return splayTime;
            }
            set
            {
                splayTime = value;
                OnPropertyChanged("sPlayTime");
            }
        }
        //Current time is not needed to be saved, accept maybe to timestamp or similiar
        private string currentTime;
        public string CurrentTime
        {
            get
            {
                return currentTime;
            }
            set
            {
                currentTime = value;
                OnPropertyChanged("CurrentTime");
            }
        }

        private string contentName;
        public string ContentName
        {
            get { return contentName; }
            set
            {
                contentName = value;
                OnPropertyChanged("ContentName");
                OnPropertyChanged("NameAndCategory");
            }
        }

        private string category;
        public string Category
        {
            get { return category; }
            set
            {
                category = value;
                OnPropertyChanged("Category");
                OnPropertyChanged("NameAndCategory");
            }
        }

        private string nameAndCategory;
        public string NameAndCategory
        {
            get { return ContentName + " - " + Category; }
            set
            {
                nameAndCategory = value;
                OnPropertyChanged("NameAndCategory");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public SpeechModel()
        {
            if (DesignMode.DesignModeEnabled)
            {
                ContentName = "942_DT";
                Category = "SED IB";
                // PlayTime = new TimeSpan(05,22,00);
                sPlayTime = "04:35:00";
            }
            else
            {
                ContentName = "TimePicker Binding";
                Category = "IT";
                // PlayTime = new TimeSpan(05,22,00);
                sPlayTime = "04:47:00";
            }
        }

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
