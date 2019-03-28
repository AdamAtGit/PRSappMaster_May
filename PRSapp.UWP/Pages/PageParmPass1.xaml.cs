using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using PRSapp.UWP.UserControls.AppFx;
using PRSapp.UWP.UserControls.Nested;
using System.Diagnostics;

namespace PRSapp.UWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageParmPass1 : Page
    {
        #region Declare Class Members
        PrompterUC PuChild;
        HintUC HuChild;
        ResponseUC RuChild;

        #region Parent DispatcherTimer 
        DispatcherTimer parentDt = new DispatcherTimer();
        Int32 LeadTime, HintTime, NextSetTime;
        TimeSpan TsInterval, TsHintInterval, TsSetsInterval;       
        int TimesToTick; // Depends on PHR SetNo.
        int I; // Incrementer
        int SetNo; // Sets Counter
        #endregion

        #region Parent StopWatch
        Stopwatch Psw;
        Int32 ElapsedTime;
        TimeSpan TsSwElapsedTime;
        #endregion

        #endregion

        public PageParmPass1()
        {
            this.InitializeComponent();

            var hintUC = new HintUC();//for Show Hint functionality

            #region Initialize child UCs which synthesize at timed intervals
            PuChild = new PrompterUC();
            PuChild.BtnRepeatMediaOutAsyncClick += PuChild.BtnRepeatMediaOutAsync_Click;
            BtnPage1RepeatMediaOutAsync.Click += PuChild.BtnRepeatMediaOutAsync_Click;

            HuChild = new HintUC(); //Todo: synth of hint/Mnemonic

            RuChild = new ResponseUC();
            RuChild.BtnRepeatMediaOutAsync2Click += RuChild.BtnRepeatMediaOutAsync_Click;
            BtnPage1RepeatMediaOutAsync2.Click += RuChild.BtnRepeatMediaOutAsync_Click;
            #endregion

            //Make so parent Run button invokes  
            BtnPlayController.Click += RunPlayListsSets_Click;
            // PrompterUC.BtnRepeatMediaOutAsyncClick += prompterUC.BtnRepeatMediaOutAsync_Click;
            // BtnPage1RepeatMediaOutAsync.Click += prompterUC.BtnRepeatMediaOutAsync_Click;

            TimerSetUp();
            Psw = new Stopwatch();
            
        }

        public void TimerSetUp()
        {
            TimesToTick = 10;//TODO - need to count or query the PHR sets to get this value
            I = 0;
            SetNo = 0;
            parentDt.Tick += ParentDispTimer_Tick;          
        }

        private void ParentDispTimer_Tick(object sender, object e)
        {
            PuChild.BtnRepeatMediaOutAsync_Click(sender, new RoutedEventArgs());
        }

        public void RunPlayListsSets_Click(object sender, RoutedEventArgs e)
        {
            LeadTime = Convert.ToInt32(boxLeadTime.Text);
            TsInterval = new TimeSpan(0, 0, LeadTime);

            parentDt.Interval = TsInterval;
            Psw.Start();
            parentDt.Start();
            Psw.Stop();
            if (!Psw.IsRunning)
            { 
               ElapsedTime = Convert.ToInt32(Psw.Elapsed.TotalSeconds);
               boxElapsedTime.Text = ElapsedTime.ToString();
               TsSwElapsedTime = new TimeSpan(0, 0, ElapsedTime);
            }

            //PuChild.BtnRepeatMediaOutAsync_Click(sender, new RoutedEventArgs());
            ////todo hinterUC.' '(sender, new RoutedEventArgs());
            //RuChild.BtnRepeatMediaOutAsync_Click(this, new RoutedEventArgs());
        }

        private void NavBacktoMain_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var prompterUC = new PrompterUC();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // base.OnNavigatedTo(e); 
            boxSignedInUser.Text = "Hi, " + e.Parameter.ToString();


            //\\ Code Set - Pass data from User Control to Parent page in Windows Phone 8.1
            //Our main page will subscribe to the event that we created on the user control, 
            //to get notification of when the event is fired on the user control.
            uChild.GetDataFromChild += new DateButtonUC.ChildControlDelegate(UChild_GetDataFromChild);
            uChildHint.GetDataFromHintUcChild += new HintUC.ChildHintUCDelegate(HintUC_GetDataFromHintUcChild);
        }

        private void HintUC_GetDataFromHintUcChild(Boolean IsHintVisible)
        {
            Boolean isHintVisible = IsHintVisible;
            boxIsHintVisible.Text = isHintVisible.ToString();
            //boxPage1DateTime.Text = dt.ToShortTimeString();
        }

        //\\ Code Set - Pass data from User Control to Parent page
        private void UChild_GetDataFromChild(DateTime dtCurrentDateTime)
        {
            DateTime dt = dtCurrentDateTime;
            boxPage1DateTime.Text = dt.ToShortTimeString();
        }

    }
}
