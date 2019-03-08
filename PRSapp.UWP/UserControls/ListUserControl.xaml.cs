using System;
using PRSapp.Model;
using System.Collections.Generic;
using System.Linq;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace PRSapp.UWP.UserControls
{
    public sealed partial class ListUserControl : UserControl
    {
        //Signed in User Info Current Properties
        ApplicationDataContainer localCurrentUserSettings = ApplicationData.Current.LocalSettings;

        public string CurrentUserName { get; set; }
        public int CurrentUserId { get; set; }
        public int SelectedTitleId { get; set; }
        public int EditTitleId { get; set; }
        public int DeleteTitleId { get; set; }
        //public List<Title> TitleListIds { get; set; }

        //Speech Synth and Recogn
        public string SpeechInputResult { get; set; }

        public ListUserControl()
        {
            this.InitializeComponent();

            CurrentUserName =
                (string)localCurrentUserSettings.Values["CurrentUserNameSettings"];
            CurrentUserId =
                (int)localCurrentUserSettings.Values["CurrentUserIDSettings"];
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new PRSappContext())
            {
                ShowTitlesListView.ItemsSource = db.Titles.ToList();
            }

            #region Show current users titles
            using (var context = new PRSappContext())
            {
                var usersTitles =
                   from t in context.Titles
                   where t.UserId == CurrentUserId
                   orderby t.TitleId descending
                   select t;

                List<Title> selectedUsersTitles = usersTitles.ToList();

                //Refresh ListView's ItemsSource  
                ShowTitlesListView.ItemsSource = selectedUsersTitles;
            }
            #endregion
        }

        private void BtnSetSelectionModeToMulitple_Click(object sender, RoutedEventArgs e)
        {
            if (ShowTitlesListView.SelectionMode == (ListViewSelectionMode)SelectionMode.Extended)
            {
                ShowTitlesListView.SelectionMode = (ListViewSelectionMode)SelectionMode.Multiple;
            }
            else
            {
                ShowTitlesListView.SelectionMode = (ListViewSelectionMode)SelectionMode.Extended;
            }
        }
      
        private void ShowTitlesListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ////Refresh Show Titles List View
            //List<Title> selectedTitles = TitleListIds; //usersTitleDetails.ToList()
        }
        
        private void ShowTitlesListView_KeyUp(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {

        }

    }
}
