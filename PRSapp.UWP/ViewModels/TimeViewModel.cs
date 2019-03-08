using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using PRSapp.Model;
using PRSapp.UWP.CustomHelperClasses;
using PRSapp.UWP.Models;
using PRSapp.UWP.ViewModels.Commands;
using Windows.ApplicationModel;
using Windows.Media.SpeechSynthesis;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Linq;

namespace PRSapp.UWP.ViewModels
{
    public class TimeViewModel : INotifyPropertyChanged
    {
        #region SpeechViewModel (SynthAsync) embedded
        public MediaElement uiMediaElement { get; private set; }
        SpeechModel speechModel = new SpeechModel();
        #endregion

        #region Synthesize Ssml To SpeechAsync Methods

        async Task<IRandomAccessStream> SynthesizeSsmlToSpeechAsync(StorageFile ssmlFile)
        {
            // Windows.Storage.Streams.IRandomAccessStream
            IRandomAccessStream stream = null;
            // Windows.Media.SpeechSynthesis.SpeechSynthesizer
            using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
            {
                // Windows.Media.SpeechSynthesis.SpeechSynthesisStream
                string text = await FileIO.ReadTextAsync(ssmlFile);
                stream = await synthesizer.SynthesizeSsmlToStreamAsync(text);
            }
            return (stream);
        }
        async Task SpeakSsmlFileAsync(StorageFile ssmlFile, MediaElement mediaElement)
        {
            IRandomAccessStream stream = await SynthesizeSsmlToSpeechAsync(ssmlFile);
            // Send the stream to the media object.
            try
            {
                MediaElement mE = new MediaElement();
                mE.SetSource(stream, ssmlFile.ContentType);
                mE.Play();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception: {0}", e.Message.ToString());
            }
            Debug.WriteLine("got past mediaElement.Play()");
        }
        #endregion

        #region Path & FileName Full Properties
        private string path;
        public string Path
        {
            get { return path; }
            set
            {
                path = value;
                RaisePropertyChanged("Path");
            }
        }

        private string fileName;
        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                RaisePropertyChanged("FileName");
            }
        }
        #endregion

        #region Misc .xml file Paths
        //path = "ms-appx:///Speech/SSML/UsageSyntax.xml";
        #endregion

        #region SpeakAsyncCommand
        RelayCommand speakAsyncCommand;
        public ICommand SpeakAsyncCommand
        {
            get
            {
                if (speakAsyncCommand == null)
                {
                    speakAsyncCommand = new RelayCommand(
                    param => SpeakAsync(),
                    param => CanSpeakAsync
                    );
                };
                return speakAsyncCommand;
            }
        }
        public async void SpeakAsync()
        {
            //SpeakAsync Logic goes here
            Debug.WriteLine("from SpeakAsync()");
            try
            {
                if (speechModel.IsCmdMode != true)
                {
#pragma warning disable CS0168 // Variable is declared but never used
                    string ttsRaw;
#pragma warning restore CS0168 // Variable is declared but never used
                    bool isInDb = false;
                    bool isTtsRaw = true;
                    if (isTtsRaw)
                    {

                    }
                    else if(isInDb)
                    {
                        //This query, may, should go in TitleListViewUserControl's
                        //'OK' button handler
                        //using (var db = new PRSappContext())
                        //{
                        //        var titleTtsRaw = 
                        //        from t in db.Titles
                        //        where t.ti
                        //        select t;
                        //        ttsRaw = titleTtsRaw.ToString();
                        //}
            
                        //StorageFile ssmlFile = await StorageFile.GetFileFromApplicationUriAsync(
                        //new Uri(path));
                        //await this.SpeakSsmlFileAsync(
                        //ssmlFile, this.uiMediaElement);
                    }
                    else
                    {
                        Debug.WriteLine("Model synthAsync.IsCmdMode  == true <-- Worked");
                        path = "ms-appx:///Speech/SSML/SED/en-ES/2ndPersonSingular/" + fileName;
                        Debug.WriteLine("property path value: {0}", path);
                        StorageFile ssmlFile = await StorageFile.GetFileFromApplicationUriAsync(
                        new Uri(path));
                        await this.SpeakSsmlFileAsync(
                        ssmlFile, this.uiMediaElement);
                    }


                }
                else
                {
                    Debug.WriteLine("Model synthAsync.IsCmdMode went to else");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: {0}", ex.Message.ToString());
            }
        }
        public bool CanSpeakAsync
        {
            get { return true; }
        }
        #endregion

        //00
        #region  public class RelayCommand : ICommand
        //Create Relay Command that inherits ICommand Interface
        RelayCommand speakAsync00_MMMCommand;
        public ICommand SpeakAsync00_MMMCommand
        {
            get
            {
                if (speakAsync00_MMMCommand == null)
                {
                    speakAsync00_MMMCommand = new RelayCommand(
                    param => SpeakAsync00_MMM(),
                    param => CanSpeakAsync00_MMMCommand
                    );
                };
                return speakAsync00_MMMCommand;
            }
        }

        public async void SpeakAsync00_MMM()
        {
            try
            {
                if (speechModel.IsCmdMode != true)
                {
                    string ttsRaw = string.Empty;
                    bool isTtsRaw = true;

                    if(isTtsRaw)
                    {
                        using (var context = new PRSappContext())
                        {
                            var titleTtsRaw =
                               from t in context.Titles
                               where t.TitleId == 40
                               select t;//.TtsRaw;

                            List<Title> Titles = titleTtsRaw.ToList();
                            foreach (var item in Titles)
                            {
                                ttsRaw = item.TtsRaw.ToString();
                            }

                            //if (titleTtsRaw != null)
                            //{
                            //    ttsRaw = ElementAtOrDefault(usersTitleDetails, 1).ToString();
                            //}                        
                        }
                        try
                        {
                            await this.SpeakTextAsync(ttsRaw, this.uiMediaElement);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.Message.ToString());
                        }
                    }
                    else
                    { 
                    path = "ms-appx:///Speech/SSML/Routine/en-ES/2ndPersonSingular/PlaySet_0000/01_Alarm.xml";

                    StorageFile ssmlFile = await StorageFile.GetFileFromApplicationUriAsync(
                    new Uri(path));
                    await this.SpeakSsmlFileAsync(
                    ssmlFile, this.uiMediaElement);
                    }
                }
                else
                {
                    Debug.WriteLine("Model synthAsync.IsCmdMode went to else");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: {0}", ex.Message.ToString());
            }
        }
        public bool CanSpeakAsync00_MMMCommand
        {
            get { return true; }
        }
        #endregion
        //10
        #region  public class RelayCommand : ICommand
        //Create Relay Command that inherits ICommand Interface
        RelayCommand speakAsync10_DayPart1Command;
        public ICommand SpeakAsync10_DayPart1Command
        {
            get
            {
                if (speakAsync10_DayPart1Command == null)
                {
                    speakAsync10_DayPart1Command = new RelayCommand(
                    param => SpeakAsync10_DayPart1(),
                    param => CanSpeakAsync10_DayPart1Command
                    );
                };
                return speakAsync10_DayPart1Command;
            }
        }

        public async void SpeakAsync10_DayPart1()
        {
            try
            {
                if (speechModel.IsCmdMode != true)
                {
                    path = "ms-appx:///Speech/SSML/Routine/en-ES/2ndPersonSingular/PlaySet_0000/02_SED-Outloud.xml";
                    StorageFile ssmlFile = await StorageFile.GetFileFromApplicationUriAsync(
                    new Uri(path));
                    await this.SpeakSsmlFileAsync(
                    ssmlFile, this.uiMediaElement);
                }
                else
                {
                    Debug.WriteLine("Model synthAsync.IsCmdMode went to else");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: {0}", ex.Message.ToString());
            }
        }
        public bool CanSpeakAsync10_DayPart1Command
        {
            get { return true; }
        }
        #endregion
        //20
        #region  public class RelayCommand : ICommand
        //Create Relay Command that inherits ICommand Interface
        RelayCommand speakAsync20_DayPart2Command;
        public ICommand SpeakAsync20_DayPart2Command
        {
            get
            {
                if (speakAsync20_DayPart2Command == null)
                {
                    speakAsync20_DayPart2Command = new RelayCommand(
                    param => SpeakAsync20_DayPart2(),
                    param => CanSpeakAsync20_DayPart2Command
                    );
                };
                return speakAsync20_DayPart2Command;
            }
        }

        public async void SpeakAsync20_DayPart2()
        {
            try
            {
                if (speechModel.IsCmdMode != true)
                {
                    path = "ms-appx:///Speech/SSML/Routine/en-ES/2ndPersonSingular/PlaySet_0000/03_Run.xml";
                    StorageFile ssmlFile = await StorageFile.GetFileFromApplicationUriAsync(
                    new Uri(path));
                    await this.SpeakSsmlFileAsync(
                    ssmlFile, this.uiMediaElement);
                }
                else
                {
                    Debug.WriteLine("Model synthAsync.IsCmdMode went to else");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: {0}", ex.Message.ToString());
            }
        }
        public bool CanSpeakAsync20_DayPart2Command
        {
            get { return true; }
        }
        #endregion
        //30
        #region  public class RelayCommand : ICommand
        //Create Relay Command that inherits ICommand Interface
        RelayCommand speakAsync30_DayPart3_MentPrepCommand;
        public ICommand SpeakAsync30_DayPart3_MentPrepCommand
        {
            get
            {
                if (speakAsync30_DayPart3_MentPrepCommand == null)
                {
                    speakAsync30_DayPart3_MentPrepCommand = new RelayCommand(
                    param => SpeakAsync30_DayPart3_MentPrep(),
                    param => CanSpeakAsync30_DayPart3_MentPrepCommand
                    );
                };
                return speakAsync30_DayPart3_MentPrepCommand;
            }
        }

        public async void SpeakAsync30_DayPart3_MentPrep()
        {
            try
            {
                if (speechModel.IsCmdMode != true)
                {
                    path = "ms-appx:///Speech/SSML/Routine/en-ES/2ndPersonSingular/PlaySet_0000/04_WorkOut.xml";
                    StorageFile ssmlFile = await StorageFile.GetFileFromApplicationUriAsync(
                    new Uri(path));
                    await this.SpeakSsmlFileAsync(
                    ssmlFile, this.uiMediaElement);
                }
                else
                {
                    Debug.WriteLine("Model synthAsync.IsCmdMode went to else");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: {0}", ex.Message.ToString());
            }
        }
        public bool CanSpeakAsync30_DayPart3_MentPrepCommand
        {
            get { return true; }
        }
        #endregion
        //55
        #region  public class RelayCommand : ICommand
        //Create Relay Command that inherits ICommand Interface
        RelayCommand speakAsync55_PreCrunchTimeCommand;
        public ICommand SpeakAsync55_PreCrunchTimeCommand
        {
            get
            {
                if (speakAsync55_PreCrunchTimeCommand == null)
                {
                    speakAsync55_PreCrunchTimeCommand = new RelayCommand(
                    param => SpeakAsync55_PreCrunchTime(),
                    param => CanSpeakAsync55_PreCrunchTimeCommand
                    );
                };
                return speakAsync55_PreCrunchTimeCommand;
            }
        }

        public async void SpeakAsync55_PreCrunchTime()
        {
            try
            {
                if (speechModel.IsCmdMode != true)
                {
                    path = "ms-appx:///Speech/SSML/Routine/en-ES/2ndPersonSingular/PlaySet_0000/05_ProgPlan1st.xml";
                    StorageFile ssmlFile = await StorageFile.GetFileFromApplicationUriAsync(
                    new Uri(path));
                    await this.SpeakSsmlFileAsync(
                    ssmlFile, this.uiMediaElement);
                }
                else
                {
                    Debug.WriteLine("Model synthAsync.IsCmdMode went to else");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: {0}", ex.Message.ToString());
            }
        }
        public bool CanSpeakAsync55_PreCrunchTimeCommand
        {
            get { return true; }
        }
        #endregion
        //90 MMM_Eve
        #region  public class RelayCommand : ICommand
        //Create Relay Command that inherits ICommand Interface
        RelayCommand speakAsync90_MMM_EveCommand;
        public ICommand SpeakAsync90_MMM_EveCommand
        {
            get
            {
                if (speakAsync90_MMM_EveCommand == null)
                {
                    speakAsync90_MMM_EveCommand = new RelayCommand(
                    param => SpeakAsync90_MMM_Eve(),
                    param => CanSpeakAsync90_MMM_EveCommand
                    );
                };
                return speakAsync90_MMM_EveCommand;
            }
        }

        public async void SpeakAsync90_MMM_Eve()
        {
            try
            {
                if (speechModel.IsCmdMode != true)
                {
                    path = "ms-appx:///Speech/SSML/Routine/en-ES/2ndPersonSingular/PlaySet_0000/06_ListenSuzan.xml";
                    StorageFile ssmlFile = await StorageFile.GetFileFromApplicationUriAsync(
                    new Uri(path));
                    await this.SpeakSsmlFileAsync(
                    ssmlFile, this.uiMediaElement);
                }
                else
                {
                    Debug.WriteLine("Model synthAsync.IsCmdMode went to else");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: {0}", ex.Message.ToString());
            }
        }
        public bool CanSpeakAsync90_MMM_EveCommand
        {
            get { return true; }
        }
        #endregion

        TimeModel timeModel = new TimeModel();

        #region IsMatch set up
        TimeFormatNCompare tfnC_0 = new TimeFormatNCompare();//*Note this was just tfnC = new...
        TimeFormatNCompare tfnC_1 = new TimeFormatNCompare();
        TimeFormatNCompare tfnC_2 = new TimeFormatNCompare();
        public string sOut_0;
        public string sTimePickerTime_0;
        public string sOut_1;
        public string sTimePickerTime_1;
        public string sOut_2;
        public string sTimePickerTime_2;

        TimeFormatNCompare tfnC_3 = new TimeFormatNCompare();
        TimeFormatNCompare tfnC_4 = new TimeFormatNCompare();
        TimeFormatNCompare tfnC_5 = new TimeFormatNCompare();
        public string sOut_3;
        public string sTimePickerTime_3;
        public string sOut_4;
        public string sTimePickerTime_4;
        public string sOut_5;
        public string sTimePickerTime_5;
        #endregion

        private const int INTERVAL_IN_SECONDS = 1;
        public DateTimeOffset dto;
        private string s;
        public string TimeFromStart
        {
            get => s;
        }

        #region VM properties
        private bool isMatch_0;
        public bool IsMatch_0
        {
            get => isMatch_0;
            set
            {
                isMatch_0 = value;
                RaisePropertyChanged("IsMatch_0");
            }
        }

        private bool isMatch_1;
        public bool IsMatch_1
        {
            get => isMatch_1;//*Note was isMatch_0 mistakenly
            set
            {
                isMatch_1 = value;
                RaisePropertyChanged("IsMatch_1");
            }
        }

        private bool isMatch_2;
        public bool IsMatch_2
        {
            get => isMatch_2;
            set
            {
                isMatch_2 = value;
                RaisePropertyChanged("IsMatch_2");
            }
        }

        private bool isMatch_3;
        public bool IsMatch_3
        {
            get => isMatch_3;
            set
            {
                isMatch_3 = value;
                RaisePropertyChanged("IsMatch_3");
            }
        }

        private bool isMatch_4;
        public bool IsMatch_4
        {
            get => isMatch_4;
            set
            {
                isMatch_4 = value;
                RaisePropertyChanged("IsMatch_4");
            }
        }

        private bool isMatch_5;
        public bool IsMatch_5
        {
            get => isMatch_5;
            set
            {
                isMatch_5 = value;
                RaisePropertyChanged("IsMatch_5");
            }
        }

        //Expression style prop 
        public String dtCurrentTime => dto.ToString("T");
        public String CurrentTime => dto.ToString("T");
        public String SstartTime => startTime.ToString("T");
        #endregion

        public TimeSpan tsIntv;
        private DispatcherTimer timer;
        private DateTimeOffset startTime;
        private TimeSpan tsFromStart;

        public event PropertyChangedEventHandler PropertyChanged;

        public TimeViewModel()//Constructor
        {
            TimeFormatNCompare tfnC_0 = new TimeFormatNCompare();//*Note this was just tfnC = new...
            TimeFormatNCompare tfnC_1 = new TimeFormatNCompare();
            TimeFormatNCompare tfnC_2 = new TimeFormatNCompare();

            TimeFormatNCompare tfnC_3 = new TimeFormatNCompare();
            TimeFormatNCompare tfnC_4 = new TimeFormatNCompare();
            TimeFormatNCompare tfnC_5 = new TimeFormatNCompare();

            tsIntv = new TimeSpan(0, 0, INTERVAL_IN_SECONDS);
            timer = new DispatcherTimer();
            startTime = DateTimeOffset.Now;
            tsFromStart = new TimeSpan(0, 0, 0);

            if (DesignMode.DesignModeEnabled)
            {
                Path = "ms-appx:///Speech/SSML/Routine/en-ES/2ndPersonSingular/";
                SomeDateTime = DateTime.Now.AddMinutes(1);//DateTime.Parse("09/2/2018 2:00PM");
                tsIntv = new TimeSpan(0, 0, INTERVAL_IN_SECONDS);
                timer = new DispatcherTimer();
                timer.Interval = tsIntv;
                timer.Tick += Timer_Tick;
                timer.Start();
                startTime = DateTimeOffset.Now;
                tsFromStart = new TimeSpan(0, 0, 0);

                SomeDateTime_0 = DateTime.Now.AddMinutes(1);//DateTime.Parse("09/3/2018 8:23AM");
                RaisePropertyChanged("SomeDateTime_0");
                SomeDateTime_1 = DateTime.Now.AddMinutes(2);
                RaisePropertyChanged("SomeDateTime_1");
                SomeDateTime_2 = DateTime.Now.AddMinutes(3);
                RaisePropertyChanged("SomeDateTime_2");

                SomeDateTime_3 = DateTime.Now.AddMinutes(4);
                RaisePropertyChanged("SomeDateTime_3");
                SomeDateTime_4 = DateTime.Now.AddMinutes(5);
                RaisePropertyChanged("SomeDateTime_4");
                SomeDateTime_5 = DateTime.Now.AddMinutes(6);
                RaisePropertyChanged("SomeDateTime_5");
            }
            else
            {
                SomeDateTime = DateTime.Now.AddMinutes(1);//For DatePicker
                tsIntv = new TimeSpan(0, 0, INTERVAL_IN_SECONDS);
                timer = new DispatcherTimer();
                timer.Interval = tsIntv;
                timer.Tick += Timer_Tick;
                timer.Start();
                startTime = DateTimeOffset.Now;
                tsFromStart = new TimeSpan(0, 0, 0);

                SomeDateTime_0 = DateTime.Now.AddMinutes(1);//DateTime.Parse("09/3/2018 8:23AM");
                RaisePropertyChanged("SomeDateTime_0");
                SomeDateTime_1 = DateTime.Now.AddMinutes(2);
                RaisePropertyChanged("SomeDateTime_1");
                SomeDateTime_2 = DateTime.Now.AddMinutes(3);
                RaisePropertyChanged("SomeDateTime_2");

                SomeDateTime_3 = DateTime.Now.AddMinutes(4);
                RaisePropertyChanged("SomeDateTime_3");
                SomeDateTime_4 = DateTime.Now.AddMinutes(5);
                RaisePropertyChanged("SomeDateTime_4");
                SomeDateTime_5 = DateTime.Now.AddMinutes(6);
                RaisePropertyChanged("SomeDateTime_5");
            }
        }

        private void Timer_Tick(object sender, object e)
        {
            string sTimePickerTime_0 = SomeDateTimeTimeSpanProxy_0.ToString("T");
            string sTimePickerTime_1 = SomeDateTimeTimeSpanProxy_1.ToString("T");
            string sTimePickerTime_2 = SomeDateTimeTimeSpanProxy_2.ToString("T");

            string sTimePickerTime_3 = SomeDateTimeTimeSpanProxy_3.ToString("T");
            string sTimePickerTime_4 = SomeDateTimeTimeSpanProxy_4.ToString("T");
            string sTimePickerTime_5 = SomeDateTimeTimeSpanProxy_5.ToString("T");

            dto = DateTimeOffset.Now;
            tsFromStart = dto - startTime;
            s = tsFromStart.ToString();
            s = s.Remove(8, 8);
            RaisePropertyChanged("TimeFromStart");
            RaisePropertyChanged("CurrentTime");

            #region Find Match works when clock in double digits
            string GetAdjustedTime(string _sOut)
            {
                string sOut;
                sOut = _sOut;
                int startPos = 5;
                string sub = sOut.Substring(0, 2);
                //Check and adjust if hh: change from Single digits(9:) to double digits(10:)
                if (!sub.Contains(":"))//"9:" Versus "10"
                {
                    startPos = 6;
                }
                sub = sOut.Substring(startPos, 2);// --> ss "27"
                if (sub != "00" || sOut.Contains("0000 "))
                {
                    //Check and adjust if ss: "27:1234567"(length 10) to " :0000"(length 
                    if (!sOut.Contains("0000 "))//"10:27:0000 PM"
                    {
                        sOut = sOut.Remove(startPos, 10);// --> "9:27: PM" 
                    }
                    else
                    {
                        sOut = sOut.Remove(startPos, 4);
                    }
                    string endChars;
                    int len = sOut.Length - 2;
                    endChars = sOut.Substring(len, 2);// --> "PM"
                    len = sOut.Length - 3;
                    string holding = sOut.Remove(len, 3);// --> "9:27:"
                    sOut = holding + "00 " + endChars;// --> "9:27:00 PM"             
                }
                return sOut;
            }

            sTimePickerTime_0 = SomeDateTimeTimeSpanProxy_0.ToString("T");
            sOut_0 = tfnC_0.TimeStringFormatter(sTimePickerTime_0);
            #region old approach
            ////sOut_0 = "9:27:0000 PM";  
            ////sOut_0 = "10:27:0000 PM";  
            ////sOut_0 = "10:27:56.1234567 PM"; 

            //int startPos_0 = 5;
            //string sub_0 = sOut_0.Substring(0, 2);
            ////Check and adjust if hh: change from Single digits(9:) to double digits(10:)
            //if(!sub_0.Contains(":"))//"9:" Versus "10"
            //{
            //    startPos_0 = 6;
            //}
            //sub_0 = sOut_0.Substring(startPos_0, 2);// --> ss "27"
            //if (sub_0 != "00" || sOut_0.Contains("0000 "))
            //{
            //   // int len_0 = sOut_0.Length - 2;
            //    //Check and adjust if ss: "27:1234567"(length 10) to " :0000"(length 
            //    if (!sOut_0.Contains("0000 "))//"10:27:0000 PM"
            //    {
            //        sOut_0 = sOut_0.Remove(startPos_0, 10);// --> "9:27: PM" 
            //    }
            //    else
            //    {
            //        sOut_0 = sOut_0.Remove(startPos_0, 4);
            //    }                        
            //    string endChars_0;
            //    int len_0 = sOut_0.Length - 2;
            //    endChars_0 = sOut_0.Substring(len_0, 2);// --> "PM"
            //    len_0 = sOut_0.Length - 3;
            //    string holding_0 = sOut_0.Remove(len_0, 3);// --> "9:27:"
            //    sOut_0 = holding_0 + "00 " + endChars_0;// --> "9:27:00 PM"             
            //}
            #endregion
            string sOutTemp = sOut_0;
            sOut_0 = GetAdjustedTime(sOutTemp);
            isMatch_0 = tfnC_0.TimesMatched(sOut_0, CurrentTime);

            sTimePickerTime_1 = SomeDateTimeTimeSpanProxy_1.ToString("T");
            sOut_1 = tfnC_1.TimeStringFormatter(sTimePickerTime_1);
            #region old approach
            //int startPos_1 = 5;
            //string sub_1 = sOut_1.Substring(0, 2);         
            //if (!sub_1.Contains(":"))
            //{
            //    startPos_1 = 6;
            //}
            //sub_1 = sOut_1.Substring(startPos_1, 2);
            //if (sub_1 != "00" || sOut_1.Contains("0000 "))
            //{        
            //    if (!sOut_1.Contains("0000 "))
            //    {
            //        sOut_1 = sOut_1.Remove(startPos_1, 10);
            //    }
            //    else
            //    {
            //        sOut_1 = sOut_1.Remove(startPos_1, 4);
            //    }
            //    string endChars_1;
            //    int len_1 = sOut_1.Length - 2;
            //    endChars_1 = sOut_1.Substring(len_1, 2);
            //    len_1 = sOut_1.Length - 3;
            //    string holding_1 = sOut_1.Remove(len_1, 3);
            //    sOut_1 = holding_1 + "00 " + endChars_1;
            //}
            #endregion
            sOutTemp = sOut_1;
            sOut_1 = GetAdjustedTime(sOutTemp);
            isMatch_1 = tfnC_1.TimesMatched(sOut_1, CurrentTime);

            sTimePickerTime_2 = SomeDateTimeTimeSpanProxy_2.ToString("T");
            sOut_2 = tfnC_2.TimeStringFormatter(sTimePickerTime_2);
            #region old approach
            //int startPos_2 = 5;
            //string sub_2 = sOut_2.Substring(0, 2);
            //if (!sub_2.Contains(":"))
            //{
            //    startPos_2 = 6;
            //}
            //sub_2 = sOut_2.Substring(startPos_2, 2);
            //if (sub_2 != "00" || sOut_2.Contains("0000 "))
            //{
            //    if (!sOut_2.Contains("0000 "))
            //    {
            //        sOut_2 = sOut_2.Remove(startPos_2, 10);
            //    }
            //    else
            //    {
            //        sOut_2 = sOut_2.Remove(startPos_2, 4);
            //    }
            //    string endChars_2;
            //    int len_2 = sOut_2.Length - 2;
            //    endChars_2 = sOut_2.Substring(len_2, 2);
            //    len_2 = sOut_2.Length - 3;
            //    string holding_2 = sOut_2.Remove(len_2, 3);
            //    sOut_2 = holding_2 + "00 " + endChars_2;
            //}
            #endregion
            sOutTemp = sOut_2;
            sOut_2 = GetAdjustedTime(sOutTemp);
            isMatch_2 = tfnC_2.TimesMatched(sOut_2, CurrentTime);

            sTimePickerTime_3 = SomeDateTimeTimeSpanProxy_3.ToString("T");
            sOut_3 = tfnC_3.TimeStringFormatter(sTimePickerTime_3);
            #region old approach
            //int startPos_3 = 5;
            //string sub_3 = sOut_3.Substring(0, 2);
            //if (!sub_3.Contains(":"))
            //{
            //    startPos_3 = 6;
            //}
            //sub_3 = sOut_3.Substring(startPos_3, 2);
            //if (sub_3 != "00" || sOut_3.Contains("0000 "))
            //{
            //    if (!sOut_3.Contains("0000 "))
            //    {
            //        sOut_3 = sOut_3.Remove(startPos_3, 10);
            //    }
            //    else
            //    {
            //        sOut_3 = sOut_3.Remove(startPos_3, 4);
            //    }
            //    string endChars_3;
            //    int len_3 = sOut_3.Length - 2;
            //    endChars_3 = sOut_3.Substring(len_3, 2);
            //    len_3 = sOut_3.Length - 3;
            //    string holding_3 = sOut_3.Remove(len_3, 3);
            //    sOut_3 = holding_3 + "00 " + endChars_3;
            //}
            #endregion
            sOutTemp = sOut_3;
            sOut_3 = GetAdjustedTime(sOutTemp);
            isMatch_3 = tfnC_3.TimesMatched(sOut_3, CurrentTime);

            sTimePickerTime_4 = SomeDateTimeTimeSpanProxy_4.ToString("T");
            sOut_4 = tfnC_4.TimeStringFormatter(sTimePickerTime_4);
            #region old approach
            //int startPos_4 = 5;
            //string sub_4 = sOut_4.Substring(0, 2);
            //if (!sub_4.Contains(":"))
            //{
            //    startPos_4 = 6;
            //}
            //sub_4 = sOut_4.Substring(startPos_4, 2);
            //if (sub_4 != "00" || sOut_4.Contains("0000 "))
            //{
            //    if (!sOut_4.Contains("0000 "))
            //    {
            //        sOut_4 = sOut_4.Remove(startPos_4, 10);
            //    }
            //    else
            //    {
            //        sOut_4 = sOut_4.Remove(startPos_4, 4);
            //    }
            //    string endChars_4;
            //    int len_4 = sOut_4.Length - 2;
            //    endChars_4 = sOut_4.Substring(len_4, 2);
            //    len_4 = sOut_4.Length - 3;
            //    string holding_4 = sOut_4.Remove(len_4, 3);
            //    sOut_4 = holding_4 + "00 " + endChars_4;
            //}
            #endregion
            sOutTemp = sOut_4;
            sOut_4 = GetAdjustedTime(sOutTemp);
            isMatch_4 = tfnC_4.TimesMatched(sOut_4, CurrentTime);

            sTimePickerTime_5 = SomeDateTimeTimeSpanProxy_5.ToString("T");
            sOut_5 = tfnC_5.TimeStringFormatter(sTimePickerTime_5);
            #region old approach
            //int startPos_5 = 5;
            //string sub_5 = sOut_5.Substring(0, 2);
            //if (!sub_5.Contains(":"))
            //{
            //    startPos_5 = 6;
            //}
            //sub_5 = sOut_5.Substring(startPos_5, 2);
            //if (sub_5 != "00" || sOut_5.Contains("0000 "))
            //{
            //    if (!sOut_5.Contains("0000 "))
            //    {
            //        sOut_5 = sOut_5.Remove(startPos_5, 10);
            //    }
            //    else
            //    {
            //        sOut_5 = sOut_5.Remove(startPos_5, 4);
            //    }
            //    string endChars_5;
            //    int len_5 = sOut_5.Length - 2;
            //    endChars_5 = sOut_5.Substring(len_5, 2);
            //    len_5 = sOut_5.Length - 3;
            //    string holding_5 = sOut_5.Remove(len_5, 3);
            //    sOut_5 = holding_5 + "00 " + endChars_5;
            //}
            #endregion
            sOutTemp = sOut_5;
            sOut_5 = GetAdjustedTime(sOutTemp);
            isMatch_5 = tfnC_5.TimesMatched(sOut_5, CurrentTime);

            #region Find Match Find Match works Single digits     
            //sTimePickerTime_0 = SomeDateTimeTimeSpanProxy_0.ToString("T");
            //sOut_0 = tfnC_0.TimeStringFormatter(sTimePickerTime_0);
            //int len_0 = sOut_0.Length;
            ////int lenTimeCount = 10;
            //int startIndex = 6;
            //if (len_0 == 12 || len_0 == 18) //1:30:0000 AM <-- 12 Chars || 1:27:32:8756657 PM <-- 18 chars
            //    {
            //    startIndex = 5;
            //    //lenTimeCount = 10;
            //}               
            //string sub_0 = sOut_0.Substring(startIndex, 2);           
            //if (sub_0 != "00")
            //{               
            //    try
            //    {
            //        sOut_0 = sOut_0.Remove(startIndex, 10);// --> "1:30: PM"  or "10:30: PM" 
            //    }
            //    catch (ArgumentOutOfRangeException ex)
            //    {
            //        if (ex.HResult.ToString() == "0x80131502")
            //        {
            //            Debug.WriteLine("ex.HResult.ToString()\n0x80131502");
            //        }
            //        else
            //        {
            //            Debug.WriteLine("ex.StackTrace.ToString()\n");
            //            Debug.WriteLine(ex.StackTrace.ToString());
            //        }
            //    }
            //    finally
            //    {                
            //        //Debug.WriteLine("Always will run code in the finally."); 
            //    }                    
            //    string endChars_0;
            //    len_0 = sOut_0.Length - 2;
            //    endChars_0 = sOut_0.Substring(len_0, 2);// --> "PM"
            //    len_0 = sOut_0.Length - 3;
            //    string holding_0 = sOut_0.Remove(len_0, 3);// --> "1:30:" or "10:30:"
            //    sOut_0 = holding_0 + "00 " + endChars_0;// --> "1:30:00 PM" or "10:30:00 PM"          
            //}
            //isMatch_0 = tfnC_0.TimesMatched(sOut_0, CurrentTime);

            //sTimePickerTime_1 = SomeDateTimeTimeSpanProxy_1.ToString("T");
            //sOut_1 = tfnC_1.TimeStringFormatter(sTimePickerTime_1);
            //int len_1 = sOut_1.Length;
            ////Handles when Time goes from single(1:30:10){5} to double digits(10:30:10){6}}          
            //int startIndex_1 = 6;
            //if (len_1 == 12 || len_1 == 18) //1:30:0000 AM <-- 12 Chars || 1:27:32:8756657 PM <-- 18 chars
            //{
            //    startIndex_1 = 5;
            //}
            ////Grabs the Seconds to set to "00" in any case
            //string sub_1 = sOut_1.Substring(startIndex_1, 2);
            //if (sub_1 != "00")
            //{            
            //    sOut_1 = sOut_1.Remove(startIndex_1, 10);           
            //    string endChars_1;
            //    len_1 = sOut_1.Length - 2;
            //    endChars_1 = sOut_1.Substring(len_1, 2);
            //    len_1 = sOut_1.Length - 3;
            //    string holding_1 = sOut_1.Remove(len_1, 3);
            //    sOut_1 = holding_1 + "00 " + endChars_1;
            //}
            //isMatch_1 = tfnC_1.TimesMatched(sOut_1, CurrentTime);

            //sTimePickerTime_2 = SomeDateTimeTimeSpanProxy_2.ToString("T");
            //sOut_2 = tfnC_2.TimeStringFormatter(sTimePickerTime_2);
            //int len_2 = sOut_2.Length;           
            //int startIndex_2 = 6;
            //if (len_2 == 12 || len_2 == 18)
            //{
            //    startIndex_2 = 5;
            //}            
            //string sub_2 = sOut_0.Substring(startIndex_2, 2);
            //if (sub_2 != "00")
            //{
            //    sOut_2 = sOut_2.Remove(startIndex_2, 10); 
            //    string endChars_2;
            //    len_2 = sOut_2.Length - 2;
            //    endChars_2 = sOut_2.Substring(len_2, 2);
            //    len_2 = sOut_2.Length - 3;
            //    string holding_2 = sOut_2.Remove(len_2, 3);
            //    sOut_2 = holding_2 + "00 " + endChars_2;
            //}
            //isMatch_2 = tfnC_2.TimesMatched(sOut_2, CurrentTime);

            //sTimePickerTime_3 = SomeDateTimeTimeSpanProxy_3.ToString("T");
            //sOut_3 = tfnC_3.TimeStringFormatter(sTimePickerTime_3);
            //int len_3 = sOut_3.Length;
            //int startIndex_3 = 6;
            //if (len_3 == 12 || len_3 == 18)
            //{
            //    startIndex_3 = 5;
            //}
            //string sub_3 = sOut_3.Substring(startIndex_3, 2);
            //if (sub_3 != "00")
            //{
            //    sOut_3 = sOut_3.Remove(startIndex_3, 10);
            //    string endChars_3;
            //    len_3 = sOut_3.Length - 2;
            //    endChars_3 = sOut_3.Substring(len_3, 2);
            //    len_3 = sOut_3.Length - 3;
            //    string holding_3 = sOut_3.Remove(len_3, 3);
            //    sOut_3 = holding_3 + "00 " + endChars_3;
            //}
            //isMatch_3 = tfnC_3.TimesMatched(sOut_3, CurrentTime);

            //sTimePickerTime_4 = SomeDateTimeTimeSpanProxy_4.ToString("T");          
            //sOut_4 = tfnC_4.TimeStringFormatter(sTimePickerTime_4);
            //int len_4 = sOut_4.Length;
            //int startIndex_4 = 6;
            //if (len_4 == 12 || len_4 == 18)
            //{
            //    startIndex_4 = 5;
            //}
            //string sub_4 = sOut_4.Substring(startIndex_4, 2);
            //if (sub_4 != "00")
            //{
            //    sOut_4 = sOut_4.Remove(startIndex_4, 10);
            //    string endChars_4;
            //    len_4 = sOut_4.Length - 2;
            //    endChars_4 = sOut_4.Substring(len_4, 2);
            //    len_4 = sOut_4.Length - 3;
            //    string holding_4 = sOut_4.Remove(len_4, 3);
            //    sOut_4 = holding_4 + "00 " + endChars_4;
            //}
            //isMatch_4 = tfnC_4.TimesMatched(sOut_4, CurrentTime);

            //sTimePickerTime_5 = SomeDateTimeTimeSpanProxy_5.ToString("T");
            //sOut_5 = tfnC_5.TimeStringFormatter(sTimePickerTime_5);
            //int len_5 = sOut_5.Length;
            //int startIndex_5 = 6;
            //if (len_5 == 12 || len_5 == 18)
            //{
            //    startIndex_5 = 5;
            //}
            //string sub_5 = sOut_5.Substring(startIndex_5, 2);
            //if (sub_5 != "00")
            //{
            //    sOut_5 = sOut_5.Remove(startIndex_5, 10);
            //    string endChars_5;
            //    len_5 = sOut_5.Length - 2;
            //    endChars_5 = sOut_5.Substring(len_5, 2);
            //    len_5 = sOut_5.Length - 3;
            //    string holding_5 = sOut_5.Remove(len_5, 3);
            //    sOut_5 = holding_5 + "00 " + endChars_5;
            //}
            //isMatch_5 = tfnC_5.TimesMatched(sOut_5, CurrentTime);
            #endregion
            if (isMatch_0 == true)
            {
                SpeakAsync00_MMM();
                //SpeakAsyncContentSelector();
            }
            RaisePropertyChanged("IsMatch_0");

            if (isMatch_1 == true)
            {
                SpeakAsync10_DayPart1();
                //SpeakAsyncContentSelector();
            }
            RaisePropertyChanged("IsMatch_1");

            if (isMatch_2 == true)
            {
                SpeakAsync20_DayPart2();
                //SpeakAsyncContentSelector();
            }
            RaisePropertyChanged("IsMatch_2");


            if (isMatch_3 == true)
            {
                SpeakAsync30_DayPart3_MentPrep();
                //SpeakAsyncContentSelector();
            }
            RaisePropertyChanged("IsMatch_3");

            if (isMatch_4 == true)
            {
                SpeakAsync55_PreCrunchTime();
                //SpeakAsyncContentSelector();
            }

            RaisePropertyChanged("IsMatch_4");

            if (isMatch_5 == true)
            {
                SpeakAsync90_MMM_Eve();
                //SpeakAsyncContentSelector();
            }
            RaisePropertyChanged("IsMatch_5");
            #endregion
        }

        public void SpeakAsyncContentSelector()
        {
            //SpeakAsync00_MMM();
            //SpeakAsync10_DayPart1();
            //SpeakAsync20_DayPart2();
            //SpeakAsync30_DayPart3_MentPrep();
            //SpeakAsync55_PreCrunchTime();
            //SpeakAsync90_MMM_Eve();
        }

        #region  SomeDateTime & SomeDateTimeDateTimeProxy
        #region For DatePicker  
        private DateTime someDateTime;
        public DateTime SomeDateTime
        {
            get { return someDateTime; }
            set
            {
                someDateTime = value;
                RaisePropertyChanged("SomeDateTime");// **Note- no need for multiple someDateTimes???
            }
        }
        public TimeSpan SomeDateTimeTimeSpanProxy
        {
            //Extract timespan from orig datetime
            get => someDateTime - someDateTime.Date;
            set
            {
                //check if timespan is different from current value
                if (SomeDateTimeTimeSpanProxy != value)
                {
                    //If it is, set the original datetime
                    //to the original date, plus the new timespan value
                    SomeDateTime = someDateTime.Date.Add(value);
                    //Raise the PropertyChanged event for the timespan property
                    RaisePropertyChanged("SomeDateTimeTimeSpanProxy");
                }
            }
        }
        #endregion
        #region 0  
        private DateTime someDateTime_0;
        public DateTime SomeDateTime_0
        {
            get { return someDateTime_0; }
            set
            {
                someDateTime_0 = value;
                RaisePropertyChanged("SomeDateTime_0");// **Note- no need for multiple someDateTimes???
            }
        }
        public TimeSpan SomeDateTimeTimeSpanProxy_0
        {
            //Extract timespan from orig datetime
            get => someDateTime_0 - someDateTime_0.Date;
            set
            {
                //check if timespan is different from current value
                if (SomeDateTimeTimeSpanProxy_0 != value)
                {
                    //If it is, set the original datetime
                    //to the original date, plus the new timespan value
                    SomeDateTime_0 = someDateTime_0.Date.Add(value);
                    //Raise the PropertyChanged event for the timespan property
                    RaisePropertyChanged("SomeDateTimeTimeSpanProxy_0");
                }
            }
        }
        #endregion
        #region 1 
        private DateTime someDateTime_1;
        public DateTime SomeDateTime_1
        {
            get => someDateTime_1;
            set
            {
                someDateTime_1 = value;
                RaisePropertyChanged("SomeDateTime_1");
            }
        }
        public TimeSpan SomeDateTimeTimeSpanProxy_1
        {
            get => someDateTime_1 - someDateTime_1.Date;
            set
            {
                if (SomeDateTimeTimeSpanProxy_1 != value)
                {
                    SomeDateTime_1 = someDateTime_1.Date.Add(value);
                    RaisePropertyChanged("SomeDateTimeTimeSpanProxy_1");
                }
            }
        }
        #endregion
        #region 2
        private DateTime someDateTime_2;
        public DateTime SomeDateTime_2
        {
            get { return someDateTime_2; }
            set
            {
                someDateTime_2 = value;
                RaisePropertyChanged("SomeDateTime_2");
            }
        }
        public TimeSpan SomeDateTimeTimeSpanProxy_2
        {
            get
            {
                //Extract timespan from orig datetime
                return someDateTime_2 - someDateTime_2.Date;
            }
            set
            {
                //check if timespan is different from current value
                if (SomeDateTimeTimeSpanProxy_2 != value)
                {
                    //If it is, set the original datetime
                    //to the original date, plus the new timespan value
                    SomeDateTime_2 = someDateTime_2.Date.Add(value);
                    //Raise the PropertyChanged event for the timespan property
                    RaisePropertyChanged("SomeDateTimeTimeSpanProxy_2");
                }
            }
        }
        #endregion
        #region 3  
        private DateTime someDateTime_3;
        public DateTime SomeDateTime_3
        {
            get { return someDateTime_3; }
            set
            {
                someDateTime_3 = value;
                RaisePropertyChanged("SomeDateTime_3");
            }
        }
        public TimeSpan SomeDateTimeTimeSpanProxy_3
        {
            //Extract timespan from orig datetime
            get => someDateTime_3 - someDateTime_3.Date;
            set
            {
                //check if timespan is different from current value
                if (SomeDateTimeTimeSpanProxy_3 != value)
                {
                    //If it is, set the original datetime
                    //to the original date, plus the new timespan value
                    SomeDateTime_3 = someDateTime_3.Date.Add(value);
                    //Raise the PropertyChanged event for the timespan property
                    RaisePropertyChanged("SomeDateTimeTimeSpanProxy_3");
                }
            }
        }
        #endregion
        #region 4 
        private DateTime someDateTime_4;
        public DateTime SomeDateTime_4
        {
            get => someDateTime_4;
            set
            {
                someDateTime_4 = value;
                RaisePropertyChanged("SomeDateTime_4");
            }
        }

        public TimeSpan SomeDateTimeTimeSpanProxy_4
        {
            get => someDateTime_4 - someDateTime_4.Date;
            set
            {
                if (SomeDateTimeTimeSpanProxy_4 != value)
                {
                    SomeDateTime_4 = someDateTime_4.Date.Add(value);
                    RaisePropertyChanged("SomeDateTimeTimeSpanProxy_4");
                }
            }
        }
        #endregion
        #region 5
        private DateTime someDateTime_5;
        public DateTime SomeDateTime_5
        {
            get { return someDateTime_5; }
            set
            {
                someDateTime_5 = value;
                RaisePropertyChanged("SomeDateTime_5");
            }
        }
        public TimeSpan SomeDateTimeTimeSpanProxy_5
        {
            get
            {
                //Extract timespan from orig datetime
                return someDateTime_5 - someDateTime_5.Date;
            }
            set
            {
                //check if timespan is different from current value
                if (SomeDateTimeTimeSpanProxy_5 != value)
                {
                    //If it is, set the original datetime
                    //to the original date, plus the new timespan value
                    SomeDateTime_5 = someDateTime_5.Date.Add(value);
                    //Raise the PropertyChanged event for the timespan property
                    RaisePropertyChanged("SomeDateTimeTimeSpanProxy_5");
                }
            }
        }
        #endregion
        #endregion
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Speech
        async Task<IRandomAccessStream> SynthesizeTextToSpeechAsync(string text)
        {
            // Windows.Storage.Streams.IRandomAccessStream
            IRandomAccessStream stream = null;

            // Windows.Media.SpeechSynthesis.SpeechSynthesizer
            using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
            {
                // Windows.Media.SpeechSynthesis.SpeechSynthesisStream
                stream = await synthesizer.SynthesizeTextToStreamAsync(text);
            }

            return (stream);
        }

        async Task SpeakTextAsync(string text, MediaElement mediaElement)
        {
            IRandomAccessStream stream = await this.SynthesizeTextToSpeechAsync(text);

            await mediaElement.PlayStreamAsync(stream, true);
        }
      
    }
    /////Ends MainPage partial Class and starts a static 'Top Level'(non-nested) class in same NameSpace
    //This below static class is an extension method for MediaElement
    static class MediaElementExtensions
    {
        public static async Task PlayStreamAsync(
          this MediaElement mediaElement,
          IRandomAccessStream stream,
          bool disposeStream = true)
        {
            // bool is irrelevant here, just using this to flag task completion.
            TaskCompletionSource<bool> taskCompleted = new TaskCompletionSource<bool>();

            // Note that the MediaElement needs to be in the UI tree for events
            // like MediaEnded to fire.
            RoutedEventHandler endOfPlayHandler = (s, e) =>
            {
                if (disposeStream)
                {
                    stream.Dispose();
                }
                taskCompleted.SetResult(true);
            };
            mediaElement.MediaEnded += endOfPlayHandler;

            mediaElement.SetSource(stream, string.Empty);
            mediaElement.Play();

            await taskCompleted.Task;
            mediaElement.MediaEnded -= endOfPlayHandler;
        }
    }
    #endregion
}
