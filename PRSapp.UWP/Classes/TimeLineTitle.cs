using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRSapp.UWP.Classes
{
    public class TimeLineTitle
    {
        private bool isTtsRaw;
        public bool IsTtsRaw
        {
            get { return isTtsRaw; }
            set { isTtsRaw = value; }
        }

        private int tliNo;
        public int TliNo
        {
            get { return tliNo; }
            set { tliNo = value; }
        }

        private string selectedName;
        public string SelectedName
        {
            get { return selectedName; }//May need to return first 15 chars
            set { selectedName = value; }
        }

        private string tts;
        public string TTS
        {
            get { return tts; }
            set { tts = value; }
        }

    }
}
