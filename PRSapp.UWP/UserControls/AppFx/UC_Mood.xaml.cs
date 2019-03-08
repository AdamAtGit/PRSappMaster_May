using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Storage.Pickers;
using Windows.Storage;
using System.Diagnostics;
using PRSapp.UWP.CustomHelperClasses;
using PRSapp.UWP.Models;
using PRSapp.UWP.ViewModels.Commands;
using Windows.ApplicationModel;
using Windows.Media.SpeechSynthesis;

namespace Views.UsrControls
{
    public sealed partial class UC_Mood : UserControl
    {
        public UC_Mood()
        {
            this.InitializeComponent();

            PickAFileButton.Click += new RoutedEventHandler(PickAFileButton_Click);
            PickAFileButton2.Click += new RoutedEventHandler(PickAFileButton2_Click);
            PickAFileButton3.Click += new RoutedEventHandler(PickAFileButton3_Click);
            PickAFileButton4.Click += new RoutedEventHandler(PickAFileButton4_Click);
        }

        #region Timer Decarations
        private DispatcherTimer timer;
        private DispatcherTimer timer2;
        private DispatcherTimer timer3;
        private DispatcherTimer timer4;
        private Int32 CountDown;
        private Int32 CountDown2;
        private Int32 CountDown3;
        private Int32 CountDown4;

        CondenseDay condenseDay = new CondenseDay();

        const int dayPart1 = 0;
        //90
        TimeSpan dP2 = new TimeSpan(0, 0, 90);
        //210
        TimeSpan dP3 = new TimeSpan(0, 0, 300);
        //420
        TimeSpan dP4 = new TimeSpan(0, 0, 720);
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
                Debug.WriteLine(ENV_PROJ_PATH + tb4FilePicked.Text);
            }
            else
            {
                tb4FilePicked.Text = "Operation cancelled.";
            }
        }
        #endregion
    }
}
