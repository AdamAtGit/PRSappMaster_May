using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

        //For AppFxs that use TTS
        private string tts;
        public string TTS
        {
            get
            {
                //OnPropertyChanged("TTS");//Not needed but may for twoWay bind mode
                                            //to send to Add Title stackpanel for example
                return tts;
            }
            set
            {
                OnPropertyChanged("TTS");
                tts = value;
            }
        }

        //For AppFxs that repeat groups (PLayLists) like T-30, CC, QtA/PhR
        private bool isRepeatOn;
        public bool IsRepeatOn
        {
            get
            {
                //OnPropertyChanged("IsRepeatOn");//Not needed but may for twoWay bind mode
                //to send to Add Title stackpanel for example
                Debug.WriteLine("\nHit IsRepeatOn Getter. \nVal: "
                    + isRepeatOn.ToString());
                return isRepeatOn;
            }
            set
            {
                Debug.WriteLine("\nHit IsRepeatOn Setter. \nVal: "
                   + isRepeatOn.ToString());
                OnPropertyChanged("IsRepeatOn");
                isRepeatOn = value;
            }
        }

        //For AppFxs that repeat groups (PLayLists) like T-30, CC, QtA/PhR
        private bool objNameCurrentlyUsingMediaControl;
        public bool ObjCurrentlyUsingMediaControl
        {
            get
            {
                //OnPropertyChanged("IsRepeatOn");//Not needed but may for twoWay bind mode
                //to send to Add Title stackpanel for example
                return objNameCurrentlyUsingMediaControl;
            }
            set
            {
                OnPropertyChanged("ObjNameCurrentlyUsingMediaControl");
                objNameCurrentlyUsingMediaControl = value;
            }
        }


    }
}
