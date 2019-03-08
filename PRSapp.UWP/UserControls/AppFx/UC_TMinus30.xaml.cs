using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Storage.Pickers;
using Windows.Storage;
using System.Diagnostics;
using Windows.UI.Xaml.Input;
using PRSapp.UWP.CustomHelperClasses;

namespace PRSapp.UWP.UserControls.AppFx
{
    public sealed partial class UC_TMinus30 : UserControl
    {   //below line for app settings
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        public UC_TMinus30()
        {
            this.InitializeComponent();
            //Load FileNames from App Settings
            try
            {
                //switchRemember.IsOn = (bool)localSettings.Values["switchSettings"];
                if (localSettings.Values["TitleFileNameSettings"] != null)
                { tbFilePicked.Text = (string)localSettings.Values["TitleFileNameSettings"]; }
                if (localSettings.Values["TitleFileName2Settings"] != null)
                { tb2FilePicked.Text = (string)localSettings.Values["TitleFileName2Settings"]; }
                if (localSettings.Values["TitleFileName3Settings"] != null)
                { tb3FilePicked.Text = (string)localSettings.Values["TitleFileName3Settings"]; }
                if (localSettings.Values["TitleFileName4Settings"] != null)
                { tb4FilePicked.Text = (string)localSettings.Values["TitleFileName4Settings"]; }
                if (localSettings.Values["TitleFileName5Settings"] != null)
                { tb5FilePicked.Text = (string)localSettings.Values["TitleFileName5Settings"]; }
                //comboMediaType.SelectedValue = (string)localSettings.Values["cboMediaTypeSettings"];

                if (localSettings.Values["CountDownTimeSettings"] != null)
                { txtCountDown.Text = (string)localSettings.Values["CountDownTimeSettings"]; }
                if (localSettings.Values["CountDownTime2Settings"] != null)
                { txt2CountDown.Text = (string)localSettings.Values["CountDownTime2Settings"]; }
                if (localSettings.Values["CountDownTime3Settings"] != null)
                { txt3CountDown.Text = (string)localSettings.Values["CountDownTime3Settings"]; }
                if (localSettings.Values["CountDownTime4Settings"] != null)
                { txt4CountDown.Text = (string)localSettings.Values["CountDownTime4Settings"]; }
                if (localSettings.Values["CountDownTime5Settings"] != null)
                { txt5CountDown.Text = (string)localSettings.Values["CountDownTime5Settings"]; }
            }
            catch (Exception) { }

            PickAFileButton.Click += new RoutedEventHandler(PickAFileButton_Click);
            PickAFileButton2.Click += new RoutedEventHandler(PickAFileButton2_Click);
            PickAFileButton3.Click += new RoutedEventHandler(PickAFileButton3_Click);
            PickAFileButton4.Click += new RoutedEventHandler(PickAFileButton4_Click);
            PickAFileButton5.Click += new RoutedEventHandler(PickAFileButton5_Click);
        }

        #region Timer Decarations
        private DispatcherTimer timer;
        private DispatcherTimer timer2;
        private DispatcherTimer timer3;
        private DispatcherTimer timer4;
        private DispatcherTimer timer5;
        private Int32 CountDown;
        private Int32 CountDown2;
        private Int32 CountDown3;
        private Int32 CountDown4;
        private Int32 CountDown5;

        CondenseDay condenseDay = new CondenseDay();

        const int dayPart1 = 0;
        //90
        TimeSpan dP2 = new TimeSpan(0, 0, 90);
        //210
        TimeSpan dP3 = new TimeSpan(0, 0, 300);
        //420
        TimeSpan dP4 = new TimeSpan(0, 0, 720);
        //530
        TimeSpan dayPart5 = new TimeSpan(0, 0, 1230);
        #endregion

        #region Paths
        const string ENV_PROJ_PATH = "ms-appx:///Assets/AV/PlayLibray/Audio/";
        //const string ENV_CENTRAL_PATH = "C:\\Users\\Flazz\\OneDrive\\Central_AV\\";
        const string ENV_CENTRAL_PATH = @"C:\Users\Flazz\Music\AV\PlayLibray\Audio\";
        #endregion

        #region 1
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CountDown = Convert.ToInt32(txtCountDown.Text);
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            //temp output debug
            condenseDay.CondenseTo10Hrs(dP2, dP3, dP4);
        }

        private void timer_Tick(object sender, object e)
        {
            CountDown--;
            txtCountDown.Text = CountDown.ToString();
            if ((CountDown <= 0))
            {
                CountDown = 0;
                try
                {
                    // MediaTool.Source = new Uri(ENV_CENTRAL_PATH + tbFilePicked.Text);
                    MediaTool.Source = new Uri(ENV_PROJ_PATH + tbFilePicked.Text);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message.ToString());
                }
                MediaTool.Volume = 100;

                //MediaTool.IsFullWindow = true;

                MediaTool.Play();
                timer.Stop();
            }
        }

        private async void PickAFileButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear previous returned file name, if it exists, between iterations of this scenario
            tbFilePicked.Text = "";

            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.MusicLibrary;
            openPicker.FileTypeFilter.Add(".mp3");
            openPicker.FileTypeFilter.Add(".m4a");
            openPicker.FileTypeFilter.Add(".m4v");
            openPicker.FileTypeFilter.Add(".avi");
            openPicker.FileTypeFilter.Add(".wav");
            openPicker.FileTypeFilter.Add(".wmv");
            openPicker.FileTypeFilter.Add(".mp4");
            openPicker.FileTypeFilter.Add(".xml");

            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                tbFilePicked.Text = file.Name;

                try
                {
                    //Save Settings Value
                    localSettings.Values["TitleFileNameSettings"] = file.Name;
                    //Read Settings Value
                    Debug.WriteLine(localSettings.Values["TitleFileNameSettings"].ToString());
                }
                catch (Exception) { }

                Debug.WriteLine(ENV_CENTRAL_PATH + tbFilePicked.Text);
            }
            else
            {
                tbFilePicked.Text = "Operation cancelled.";
            }
        }
        #endregion
        #region 2
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CountDown2 = Convert.ToInt32(txt2CountDown.Text);
            timer2 = new DispatcherTimer();
            timer2.Interval = TimeSpan.FromSeconds(1);
            timer2.Tick += timer2_Tick;
            timer2.Start();
        }

        private void timer2_Tick(object sender, object e)
        {
            CountDown2--;
            txt2CountDown.Text = CountDown2.ToString();
            if ((CountDown2 <= 0))
            {
                CountDown2 = 0;
                try
                {
                    MediaTool.Source = new Uri(ENV_PROJ_PATH + tb2FilePicked.Text);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message.ToString());
                }
                MediaTool.Volume = 100;
                MediaTool.Play();
                //MediaTool.IsRightTapEnabled = true;
                timer2.Stop();
            }
        }

        private async void PickAFileButton2_Click(object sender, RoutedEventArgs e)
        {
            // Clear previous returned file name, if it exists, between iterations of this scenario
            tb2FilePicked.Text = "";

            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.MusicLibrary;
            openPicker.FileTypeFilter.Add(".mp3");
            openPicker.FileTypeFilter.Add(".m4a");
            //openPicker.FileTypeFilter.Add(".m4p");
            openPicker.FileTypeFilter.Add(".m4v");
            openPicker.FileTypeFilter.Add(".avi");
            openPicker.FileTypeFilter.Add(".wav");
            openPicker.FileTypeFilter.Add(".wmv");
            openPicker.FileTypeFilter.Add(".mp4");

            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                tb2FilePicked.Text = file.Name;

                try
                {
                    //Save Settings Value
                    localSettings.Values["TitleFileName2Settings"] = file.Name;
                    //Read Settings Value
                    Debug.WriteLine(localSettings.Values["TitleFileName2Settings"].ToString());
                }
                catch (Exception) { }

                Debug.WriteLine(ENV_PROJ_PATH + tb2FilePicked.Text);
            }
            else
            {
                tb2FilePicked.Text = "Operation cancelled.";
            }
        }
        #endregion
        #region 3
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            CountDown3 = Convert.ToInt32(txt3CountDown.Text);
            timer3 = new DispatcherTimer();
            timer3.Interval = TimeSpan.FromSeconds(1);
            timer3.Tick += timer3_Tick;
            timer3.Start();
        }

        private void timer3_Tick(object sender, object e)
        {
            CountDown3--;
            txt3CountDown.Text = CountDown3.ToString();
            if ((CountDown3 <= 0))
            {
                CountDown3 = 0;
                try
                {
                    MediaTool.Source = new Uri(ENV_PROJ_PATH + tb3FilePicked.Text);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message.ToString());
                }
                MediaTool.Volume = 100;
                MediaTool.Play();
                timer3.Stop();
            }
        }

        private async void PickAFileButton3_Click(object sender, RoutedEventArgs e)
        {
            // Clear previous returned file name, if it exists, between iterations of this scenario
            tb3FilePicked.Text = "";

            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.MusicLibrary;
            openPicker.FileTypeFilter.Add(".mp3");
            openPicker.FileTypeFilter.Add(".m4a");
            //openPicker.FileTypeFilter.Add(".m4p");
            openPicker.FileTypeFilter.Add(".m4v");
            openPicker.FileTypeFilter.Add(".avi");
            openPicker.FileTypeFilter.Add(".wav");
            openPicker.FileTypeFilter.Add(".wmv");
            openPicker.FileTypeFilter.Add(".mp4");

            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                tb3FilePicked.Text = file.Name;

                try
                {
                    //Save Settings Value
                    localSettings.Values["TitleFileName3Settings"] = file.Name;
                    //Read Settings Value
                    Debug.WriteLine(localSettings.Values["TitleFileName3Settings"].ToString());
                }
                catch (Exception) { }

                Debug.WriteLine(ENV_PROJ_PATH + tb3FilePicked.Text);
            }
            else
            {
                tb3FilePicked.Text = "Operation cancelled.";
            }
        }
        #endregion
        #region 4
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            CountDown4 = Convert.ToInt32(txt4CountDown.Text);
            timer4 = new DispatcherTimer();
            timer4.Interval = TimeSpan.FromSeconds(1);
            timer4.Tick += timer4_Tick;
            timer4.Start();
        }

        private void timer4_Tick(object sender, object e)
        {
            CountDown4--;
            txt4CountDown.Text = CountDown4.ToString();
            if ((CountDown4 <= 0))
            {
                CountDown4 = 0;
                try
                {
                    MediaTool.Source = new Uri(ENV_PROJ_PATH + tb4FilePicked.Text);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message.ToString());
                }
                MediaTool.Volume = 100;
                MediaTool.Play();
                timer4.Stop();
            }
        }

        private async void PickAFileButton4_Click(object sender, RoutedEventArgs e)
        {
            // Clear previous returned file name, if it exists, between iterations of this scenario
            tb4FilePicked.Text = "";

            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.MusicLibrary;
            openPicker.FileTypeFilter.Add(".mp3");
            openPicker.FileTypeFilter.Add(".m4a");
            //openPicker.FileTypeFilter.Add(".m4p");
            openPicker.FileTypeFilter.Add(".m4v");
            openPicker.FileTypeFilter.Add(".avi");
            openPicker.FileTypeFilter.Add(".wav");
            openPicker.FileTypeFilter.Add(".wmv");
            openPicker.FileTypeFilter.Add(".mp4");

            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                tb4FilePicked.Text = file.Name;

                try
                {
                    //Save Settings Value
                    localSettings.Values["TitleFileName4Settings"] = file.Name;
                    //Read Settings Value
                    Debug.WriteLine(localSettings.Values["TitleFileName4Settings"].ToString());
                }
                catch (Exception) { }

                Debug.WriteLine(ENV_PROJ_PATH + tb4FilePicked.Text);
            }
            else
            {
                tb4FilePicked.Text = "Operation cancelled.";
            }
        }
        #endregion
        #region 5
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            CountDown5 = Convert.ToInt32(txt5CountDown.Text);
            timer5 = new DispatcherTimer();
            timer5.Interval = TimeSpan.FromSeconds(1);
            timer5.Tick += timer5_Tick;
            timer5.Start();
        }

        private void timer5_Tick(object sender, object e)
        {
            CountDown5--;
            txt5CountDown.Text = CountDown5.ToString();
            if ((CountDown5 <= 0))
            {
                CountDown5 = 0;
                try
                {
                    MediaTool.Source = new Uri(ENV_PROJ_PATH + tb5FilePicked.Text);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message.ToString());
                }
                MediaTool.Volume = 100;
                MediaTool.Play();
                timer5.Stop();
            }
        }

        private async void PickAFileButton5_Click(object sender, RoutedEventArgs e)
        {
            // Clear previous returned file name, if it exists, between iterations of this scenario
            tb5FilePicked.Text = "";

            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.MusicLibrary;
            openPicker.FileTypeFilter.Add(".mp3");
            openPicker.FileTypeFilter.Add(".m4a");
            //openPicker.FileTypeFilter.Add(".m4p");
            openPicker.FileTypeFilter.Add(".m4v");
            openPicker.FileTypeFilter.Add(".avi");
            openPicker.FileTypeFilter.Add(".wav");
            openPicker.FileTypeFilter.Add(".wmv");
            openPicker.FileTypeFilter.Add(".mp4");

            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                tb5FilePicked.Text = file.Name;

                try
                {
                    //Save Settings Value
                    localSettings.Values["TitleFileName5Settings"] = file.Name;
                    //Read Settings Value
                    Debug.WriteLine(localSettings.Values["TitleFileName5Settings"].ToString());
                }
                catch (Exception) { }

                Debug.WriteLine(ENV_PROJ_PATH + tb5FilePicked.Text);
            }
            else
            {
                tb5FilePicked.Text = "Operation cancelled.";
            }
        }

        #endregion

        #region KeyUps TODO IsNumeric Validation
        private void txtCountDown_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            //int i = 0;
            //char [] keyPressed = txtCountDown.Text.ToCharArray();
            //foreach (char val in keyPressed)
            //{
            //    if (char.IsNumber(keyPressed[i]))
            //    {
            //        try
            //        {
            //            //Save Settings Value
            //            localSettings.Values["txtCountDownSecSettings"] = keyPressed[i].ToString();
            //            //Read Settings Value

            //        }
            //        catch (Exception) { }
            //    }
            //    i++;
            //}
            //Debug.WriteLine(localSettings.Values["txtCountDownSecSettings"].ToString());
        }

        private void txt2CountDown_KeyUp(object sender, KeyRoutedEventArgs e)
        {

        }

        private void txt3CountDown_KeyUp(object sender, KeyRoutedEventArgs e)
        {

        }

        private void txt4CountDown_KeyUp(object sender, KeyRoutedEventArgs e)
        {

        }

        private void txt5CountDown_KeyUp(object sender, KeyRoutedEventArgs e)
        {

        }
        #endregion

        #region txtCountDowns LostFocused Time Settings Save
        private void txtCountDown_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                //Save Settings Value
                localSettings.Values["CountDownTimeSettings"] = txtCountDown.Text.Trim();
                //Read Settings Value
                Debug.WriteLine(localSettings.Values["CountDownTimeSettings"].ToString());
            }
            catch (Exception) { }
        }

        private void txt2CountDown_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                //Save Settings Value
                localSettings.Values["CountDownTime2Settings"] = txt2CountDown.Text.Trim();
                //Read Settings Value
                Debug.WriteLine(localSettings.Values["CountDownTime2Settings"].ToString());
            }
            catch (Exception) { }
        }

        private void txt3CountDown_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                //Save Settings Value
                localSettings.Values["CountDownTime3Settings"] = txt3CountDown.Text.Trim();
                //Read Settings Value
                Debug.WriteLine(localSettings.Values["CountDownTime3Settings"].ToString());
            }
            catch (Exception) { }
        }

        private void txt4CountDown_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                //Save Settings Value
                localSettings.Values["CountDownTime4Settings"] = txt4CountDown.Text.Trim();
                //Read Settings Value
                Debug.WriteLine(localSettings.Values["CountDownTime4Settings"].ToString());
            }
            catch (Exception) { }
        }

        private void txt5CountDown_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                //Save Settings Value
                localSettings.Values["CountDownTime5Settings"] = txt5CountDown.Text.Trim();
                //Read Settings Value
                Debug.WriteLine(localSettings.Values["CountDownTime5Settings"].ToString());
            }
            catch (Exception) { }
        }
        #endregion

        private void btnResestGroup_Click(object sender, RoutedEventArgs e)
        {
            //Load FileNames from App Settings
            try
            {
                //switchRemember.IsOn = (bool)localSettings.Values["switchSettings"];
                if (localSettings.Values["TitleFileNameSettings"] != null)
                { tbFilePicked.Text = (string)localSettings.Values["TitleFileNameSettings"]; }
                if (localSettings.Values["TitleFileName2Settings"] != null)
                { tb2FilePicked.Text = (string)localSettings.Values["TitleFileName2Settings"]; }
                if (localSettings.Values["TitleFileName3Settings"] != null)
                { tb3FilePicked.Text = (string)localSettings.Values["TitleFileName3Settings"]; }
                if (localSettings.Values["TitleFileName4Settings"] != null)
                { tb4FilePicked.Text = (string)localSettings.Values["TitleFileName4Settings"]; }
                if (localSettings.Values["TitleFileName5Settings"] != null)
                { tb5FilePicked.Text = (string)localSettings.Values["TitleFileName5Settings"]; }
                //comboMediaType.SelectedValue = (string)localSettings.Values["cboMediaTypeSettings"];

                if (localSettings.Values["CountDownTimeSettings"] != null)
                { txtCountDown.Text = (string)localSettings.Values["CountDownTimeSettings"]; }
                if (localSettings.Values["CountDownTime2Settings"] != null)
                { txt2CountDown.Text = (string)localSettings.Values["CountDownTime2Settings"]; }
                if (localSettings.Values["CountDownTime3Settings"] != null)
                { txt3CountDown.Text = (string)localSettings.Values["CountDownTime3Settings"]; }
                if (localSettings.Values["CountDownTime4Settings"] != null)
                { txt4CountDown.Text = (string)localSettings.Values["CountDownTime4Settings"]; }
                if (localSettings.Values["CountDownTime5Settings"] != null)
                { txt5CountDown.Text = (string)localSettings.Values["CountDownTime5Settings"]; }
            }
            catch (Exception) { }
        }

        private void btnRePlayGroup_Click(object sender, RoutedEventArgs e)
        {
            #region Re-Load FileNames from App Settings
            //try
            //{
            //    //switchRemember.IsOn = (bool)localSettings.Values["switchSettings"];
            //    if (localSettings.Values["TitleFileNameSettings"] != null)
            //    { tbFilePicked.Text = (string)localSettings.Values["TitleFileNameSettings"]; }
            //    if (localSettings.Values["TitleFileName2Settings"] != null)
            //    { tb2FilePicked.Text = (string)localSettings.Values["TitleFileName2Settings"]; }
            //    if (localSettings.Values["TitleFileName3Settings"] != null)
            //    { tb3FilePicked.Text = (string)localSettings.Values["TitleFileName3Settings"]; }
            //    if (localSettings.Values["TitleFileName4Settings"] != null)
            //    { tb4FilePicked.Text = (string)localSettings.Values["TitleFileName4Settings"]; }
            //    if (localSettings.Values["TitleFileName5Settings"] != null)
            //    { tb5FilePicked.Text = (string)localSettings.Values["TitleFileName5Settings"]; }
            //    //comboMediaType.SelectedValue = (string)localSettings.Values["cboMediaTypeSettings"];

            //    if (localSettings.Values["CountDownTimeSettings"] != null)
            //    { txtCountDown.Text = (string)localSettings.Values["CountDownTimeSettings"]; }
            //    if (localSettings.Values["CountDownTime2Settings"] != null)
            //    { txt2CountDown.Text = (string)localSettings.Values["CountDownTime2Settings"]; }
            //    if (localSettings.Values["CountDownTime3Settings"] != null)
            //    { txt3CountDown.Text = (string)localSettings.Values["CountDownTime3Settings"]; }
            //    if (localSettings.Values["CountDownTime4Settings"] != null)
            //    { txt4CountDown.Text = (string)localSettings.Values["CountDownTime4Settings"]; }
            //    if (localSettings.Values["CountDownTime5Settings"] != null)
            //    { txt5CountDown.Text = (string)localSettings.Values["CountDownTime5Settings"]; }
            //}
            //catch (Exception) { }
            #endregion
            btnResestGroup_Click(sender, e);

            Button_Click_1(sender, e);
            Button_Click_2(sender, e);
            Button_Click_3(sender, e);
            Button_Click_4(sender, e);
            Button_Click_5(sender, e);
        }
      
    }
}
