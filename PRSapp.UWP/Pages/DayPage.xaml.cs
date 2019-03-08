using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using PRSapp.Classes;
using PRSapp.UWP.Classes;

namespace PRSapp.UWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DayPage : Page
    {
        public DayPage()
        {
            this.InitializeComponent();

            #region Wire AddCreateExist Buttons
            BtnChooseCreateExist0.Click +=
                new RoutedEventHandler(BtnChooseCreateExist_Click);
            BtnChooseCreateExist1.Click +=
                new RoutedEventHandler(BtnChooseCreateExist_Click);
            BtnChooseCreateExist2.Click +=
                new RoutedEventHandler(BtnChooseCreateExist_Click);
            BtnChooseCreateExist3.Click +=
                new RoutedEventHandler(BtnChooseCreateExist_Click);
            BtnChooseCreateExist4.Click +=
                new RoutedEventHandler(BtnChooseCreateExist_Click);
            BtnChooseCreateExist5.Click +=
                new RoutedEventHandler(BtnChooseCreateExist_Click);
            #endregion

            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // base.OnNavigatedTo(e); 
            tbNaveInfo.Text = e.Parameter.ToString() + "'s " + "Daily Timelines";
            //tbNaveInfo.Text = e.Parameter.ToString();// + "'s " + "Daily Timelines";
        }

        private void NavBacktoMain_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        private void BtnChooseCreateExist_Click(object sender, RoutedEventArgs e)
        {

           
        }

        private void MenuFlyoutItemCreateTTS_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuFlyoutItemCreateAudio_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuFlyoutItemExistingTTS_Click(object sender, RoutedEventArgs e)
        {
          
            ucListUserControl.Visibility = Visibility.Visible;            
        }

        private void MenuFlyoutItemExistingTTSFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuFlyoutItemExistingAudioFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuFlyoutItemExistingVideoFile_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}