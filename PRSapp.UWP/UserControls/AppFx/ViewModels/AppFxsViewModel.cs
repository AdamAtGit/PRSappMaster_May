using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PRSapp.UWP.UserControls.AppFx.ViewModels
{
    public class AppFxsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private string tts;
        public string TTS
        {
            get
            {
                OnPropertyChanged("TTS");
                return tts;
            }
            set
            {
                OnPropertyChanged("TTS");
                tts = value;
            }
        }

    }
}
