using System;
using PRSapp.Model;
using System.Collections.Generic;
using System.Linq;
using Windows.ApplicationModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.Media.SpeechSynthesis;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Input;
using Windows.Media.SpeechRecognition;
using Windows.UI.Xaml.Media;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace PRSapp.UWP
{
    public sealed partial class MainPage : Page
    {
        //App settings
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        //Signed in User Info Current Properties
        ApplicationDataContainer localCurrentUserSettings = ApplicationData.Current.LocalSettings;

        public string CurrentUserName { get; set; }
        public int CurrentUserId { get; set; }
        public int SelectedTitleId { get; set; }
        public int EditTitleId { get; set; }
        public int DeleteTitleId { get; set; }
        public string CurrentDetailsTtsRaw { get; set; }
        public List<Title> TitleListIds { get; set; }

        //Media type for speech and media element and media player
        public string MediaType = "TtsRaw";

        //Speech Synth and Recogn
        public string SpeechInputResult { get; set; }

        //Ad-Hoc Dispatcher Timer- code set 
        DispatcherTimer dispatcherTimer;
        DateTimeOffset startTime;
        DateTimeOffset lastTime;
        DateTimeOffset stopTime;
        int timesTicked = 1;
        int timesToTick = 4;
   
    public MainPage()
        {
            this.InitializeComponent();
            ////HardwareButtons.BackPressed += HardwareButtons_BackPressed; //for Phone

            //Open in fullscreeen Mode -Works but already opening in
            //fullscreen mode. So effects nothing currently
            ApplicationView view = ApplicationView.GetForCurrentView();
            bool IsInFullScreenMode = view.IsFullScreenMode;
            if (IsInFullScreenMode)
            {
                view.ExitFullScreenMode();
            }
            else
            {
                view.TryEnterFullScreenMode();
            }

            if (DesignMode.DesignMode2Enabled)
            {
                //Need a Developer Cert(MCP), now to use Design mode enabled
            }
            else
            {
                SignInUserLogin.Text = "JRiggins44";
                SignInUserPwd.Text = "******";
                //TODO: ARS-Get user's Name for Interactive.
                CurrentUserName = "Adam";

                #region Visibility enums of all StackPanels
                //// 1st col
                //CreateLoginPanel.Visibility = Visibility.Collapsed;
                //SignInPanel.Visibility = Visibility.Collapsed;
                //DefaultHomePagePanel.Visibility = Visibility.Collapsed;
                //// 2nd col
                // ShowTitlesPanel.Visibility = Visibility.Collapsed;

                //below lines are for Isolate and make more items visible for Testing
                //EditWrapperPanel.Visibility = Visibility.Visible;
                EditWrapperPanel.SetValue(Grid.RowSpanProperty, 2);
                // StpTitles.Height = 630;
                // StpTitles.SetValue(Grid.RowSpanProperty, 2);
                ShowTitlesListView.Height = 500;


                //// 3rd col
                //AddTitlesPanel.Visibility = Visibility.Collapsed;
                // 3rd & 4th col, 3rd & 4th row
                // CreatePlayListsPanel.Visibility = Visibility.Visible;

                //// 3.5 col
                //ShowPlayListPanel *Not sure if here or bottom col 1

                //TODO: ARS-Build XAML stackpanels below for playlists
                //AddPlayListPanel.Visibility = Visibility.Visible;
                //UpdatePlayListPanel.Visibility = Visibility.Collapsed;
                //DeletePlayListPanel.Visibility = Visibility.Collapsed;

                // 4th Col
                //TweakPlaySettinsPanel.Visibility = Visibility.Collapsed;
                //ArrangePanel.Visibility = Visibility.Collapsed;
                // CreatePlayListsPanel.Visibility = Visibility.Collapsed;
                #endregion

                // Wire up Start Recognizing Routed Event Handlers
                // btnRecognitionTtsRawBigAsync.Click += new RoutedEventHandler(StartRecognizing_Click);

                // Wire up Synthesis Test Plays Routed Event Handlers
                // btnTestPlayBig.Click += new RoutedEventHandler(TestPlayBigAsync_Click);

                // Wire up Add Title Save Changes Async to ORMs
                btnAddTitleLittleAsync.Click += new RoutedEventHandler(AddTitleAsync_Click);
                //btnAddPTitleBigAsync.Click += new RoutedEventHandler(AddTitleBigAsync_Click);

                // ShowTitlesListView.SelectionMode = (ListViewSelectionMode)SelectionMode.Single;

                //Start NavonDelay task
                ////NavOnDelay();
            }
        }

        //Ad-Hoc Dispatcher Timer- code set
        #region DispatcherTimerSetup & dispatcherTimer_Tick 
        public void DispatcherTimerSetup()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 30);
            //IsEnabled defaults to false
            Debug.WriteLine("dispatcherTimer.IsEnabled = " + dispatcherTimer.IsEnabled + "\n");
            startTime = DateTimeOffset.Now;
            lastTime = startTime;
            Debug.WriteLine("Calling dispatcherTimer.Start()\n");
            ////dispatcherTimer.Start();
            //IsEnabled should now be true after calling start
            Debug.WriteLine("dispatcherTimer.IsEnabled = " + dispatcherTimer.IsEnabled + "\n");
        }
        private void DispatcherTimer_Tick(object sender, object e)
        {
            //ARS- adding to start PlayAsync_Click method
            ////PlayAsync_Click(sender, (Windows.UI.Xaml.RoutedEventArgs)e);

            DateTimeOffset time = DateTimeOffset.Now;
            TimeSpan span = time - lastTime;
            lastTime = time;
            //Time since last tick should be very very close to Interval
            Debug.WriteLine(timesTicked + "\t time since last tick: " + span.ToString() + "\n");
            timesTicked++;
            if (timesTicked > timesToTick)
            {
                stopTime = time;
                Debug.WriteLine("Calling dispatcherTimer.Stop()\n");
                dispatcherTimer.Stop();
                //IsEnabled should now be false after calling stop
                Debug.WriteLine("dispatcherTimer.IsEnabled = " + dispatcherTimer.IsEnabled + "\n");
                span = stopTime - startTime;
                Debug.WriteLine("Total Time Start-Stop: " + span.ToString() + "\n");
            }
        }
        #endregion DispatcherTimerSetup & dispatcherTimer_Tick 

        //Redirect to Timeline and create page in 2 seconds
        private async void NavOnDelay()
        {
            await Task.Delay(15000); //wait for 3 seconds asynchronously 
            Frame.Navigate(typeof(Pages.DayPage), SignInUserLogin.Text);
        }

        //////For dev purposes auto redirect to page your working on
        ////protected async override void OnNavigatedTo(NavigationEventArgs e)
        ////{
        ////    //base.OnNavigatedTo(e);
        ////    await this.Dispatcher.RunAsync(Windows.UI.Core.
        ////                                    CoreDispatcherPriority.Normal,() =>
        ////    {
        ////        Frame.Navigate(typeof(Pages.DayPage), SignInUserLogin.Text);
        ////    });
        ////}

        //// LOADING DATA from Database Provider
        
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new PRSappContext())
            {
                UsersDefaulHomePageListView.ItemsSource = db.Titles.ToList();
                //ShowTitlesListView.ItemsSource = db.Titles.ToList();       
            }

            using (var context = new PRSappContext())
            {
                #region Loading a Single Entity - to TextBlock - NOT WORKING YET
                try
                {
                    var userExists = SignInUserLogin.Text.Trim();

                    var loggingInUser =
                    from u in context.Users
                    where u.UserLogin == userExists
                    select u.UserLogin;

                    var loggingInUserTake1 = loggingInUser.Take(1);

                    foreach (var userLogin in loggingInUserTake1)
                    {
                        tbLoggedInUser.Text = userLogin.ToString();
                        Debug.WriteLine(userLogin.ToString());
                    }

                    if (userExists != null)
                    {
                        if (loggingInUser != null)
                        {
                            tbLoggedInUser.Text = userExists.ToString();
                        }
                    }

                    var loggedInUserId =
                    from u in context.Users
                    where u.UserLogin == userExists
                    select u.UserId;

                    var takeFirst1 = loggedInUserId.Take(1);

                    foreach (var id in loggedInUserId)
                    {
                        tbUserId.Text = id.ToString();
                    }
                    CurrentUserId = Convert.ToInt16(tbUserId.Text);
                    //Add Current User Info to localCurrentUserSettings
                    localCurrentUserSettings.Values["CurrentUserIDSettings"] = CurrentUserId;
                    localCurrentUserSettings.Values["CurrentUserNameSettings"] = userExists;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message.ToString());
                }
                #endregion
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
                //foreach (var title in selectedUsersTitles)
                //{
                //    Debug.WriteLine(selectedUsersTitles.ToString());
                //} 
                //Refresh ListView's ItemsSource  
                ShowTitlesListView.ItemsSource = selectedUsersTitles;
            }
            #endregion

            //Ad-Hoc Dispatcher Timer- code set
            DispatcherTimerSetup();
        }

        private async void StartRecognizing_Click(object sender, RoutedEventArgs e)
        {

            // Create an instance of SpeechRecognizer.
            var speechRecognizer = new SpeechRecognizer();

            // Set timeout settings.
            speechRecognizer.Timeouts.InitialSilenceTimeout = TimeSpan.FromSeconds(8.0);
            speechRecognizer.Timeouts.BabbleTimeout = TimeSpan.FromSeconds(6.0);
            speechRecognizer.Timeouts.EndSilenceTimeout = TimeSpan.FromSeconds(3.2);

            // Compile the dictation grammar by default.
            await speechRecognizer.CompileConstraintsAsync();

            //Inform user it's now listening
            // boxTtsRawBig.Header += "  ...listening";
            SolidColorBrush darkGray = new SolidColorBrush(Colors.DarkGray);
            // btnRecognitionTtsRawBigAsync.BorderBrush = new SolidColorBrush(Colors.DarkOrange);
            // Start recognition.
            SpeechRecognitionResult speechRecognitionResult =
                        await speechRecognizer.RecognizeAsync();
            //await speechRecognizer.RecognizeWithUIAsync();



            // Do something with the recognition result.
            SpeechInputResult = speechRecognitionResult.Text;
            // boxTtsRawBig.Text += SpeechInputResult;

            //Inform user it has finished listening and to click the Mic to continue
            // boxTtsRawBig.Header = "listening stopped. Tap the Mic to continue";
            // btnRecognitionTtsRawBigAsync.BorderBrush = darkGray;

            //var messageDialog = new Windows.UI.Popups.MessageDialog(speechRecognitionResult.Text, "Text spoken");
            //await messageDialog.ShowAsync();
        }

        private void UsersDefaulHomePageListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //TODO: ARS-populate DefaultHomePagePanel with playlistAppFx's

            //TODO: ARS- query above selected data value for the userId
            //then filter on userId == CurrentUserId;

            ////Debug.WriteLine(SelectedDataValue.ToString());
            ////using (var context = new PRSappContext())
            ////{
            ////    var usersTitles =
            ////       from t in context.Titles
            ////       where t.UserId == CurrentUserId
            ////       select t;

            ////    ////FILTERING
            ////    //var titles = context.Titles
            ////    //    .Where(b => b.UserId == (int)SelectedDataValue);                        


            ////    List<Title> selectedUsersTitles = usersTitles.ToList();
            ////    //foreach (var title in selectedUsersTitles)
            ////    //{
            ////    //    Debug.WriteLine(selectedUsersTitles.ToString());
            ////    //} 
            ////    //Refresh ListView's ItemsSource  
            ////    UsersTitlesPListView.ItemsSource = selectedUsersTitles;
            ////}
        }

        #region  1st Col 
        ////    ADDING DATA       /   Save     /    Insert
        //Use the DbSet.Add method to add new instances of your
        //entity classes.The data will be inserted in the database
        //when you call SaveChanges.
        private void CreateLogin_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new PRSappContext())
            {
                var user = new User
                {
                    UserLogin = NewUserUserLogin.Text,
                    UserPwd = NewUserUserPwd.Text
                };
                context.Users.Add(user);

                context.SaveChanges();
                JustCreatedUserTextBlock.Text = "Hi, " + NewUserUserLogin.Text;

                //Prep SignIn
                SignInUserLogin.Text = NewUserUserLogin.Text;
                SignInUserPwd.Text = "******";


            }
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            ////UserLoginsTextBlock.Text = NewUserUserLogin.Text + "'s Library";
            using (var context = new PRSappContext())
            {
                UsersDefaulHomePageListView.ItemsSource = context.Titles.ToList();
            }
        }
        #endregion

        #region  2nd Col
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

        // public IEnumerable<string> SelectedItemsRange;
        public List<string> selectedItemsList = new List<string>();

        private void ShowTitlesListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {          
            if (ShowTitlesListView.SelectedItems.Count > 1)
            {

                List<string> selectedItems = new List<string>();
                selectedItems.AddRange(ShowTitlesListView.SelectedItems.OfType<string>());            
                var selectedTitleIds = selectedItems
                                 .Select(x => selectedItems.ToString())
                                       .ToList();
                Debug.WriteLine("selectedTitleIds: " + " - " + selectedTitleIds.ToString());

                int h = 0;
                foreach (int item in selectedItems.ToString())
                {
                    Debug.WriteLine("selectedItems: " + h + " - " + item.ToString());
                    h++;
                }
              
                int z = 0;
                foreach (int item in selectedItems.ToString())
                {
                    Debug.WriteLine("itemId: " + z + " - " + item.ToString());
                    z++;
                }
                #region Commented out stuff that may be useful
                // Or just do it in one line:

                //// List<string> selectedFields = chkDFMFieldList.CheckedItems.OfType<string>().ToList();

                //////////////////////////////

                // selectedItemsList.Add(ShowTitlesListView.SelectedItem.ToString());
                //  List<String> lstitems = new List<String>();
                //  int y = 0;

                //  selectedItemsList.Add(ShowTitlesListView.SelectedItems.ToString());
                //  lstitems.Add(ShowTitlesListView.SelectedItem.ToString());
                //  // Retrieve the value, since that's usually what's important
                //  lstitems = ShowTitlesListView.SelectedItems
                //                       .Select(x => ShowTitlesListView.Items[y].ToString())
                //                       .ToList();



                //var  lstitems2 = ShowTitlesListView.SelectedItems
                //                     .Select(x => ShowTitlesListView.SelectedItems.ToString())
                //                     .ToList();

                //var lstitems3 = ShowTitlesListView.SelectedItems

                //                    .Select(x => ShowTitlesListView.SelectedItems.ToString())
                //                    .ToList();


                //  int z = 0;
                //  foreach (int itemId in ShowTitlesListView.SelectedItems.ToString())
                //  {
                //      selectedItemsList.Add(itemId.ToString());
                //      Debug.WriteLine("itemId: " + z + " - " + itemId.ToString());
                //      z++;
                //  }



                //Refresh Show Titles List View
                //// List<Title> selectedTitles = TitleListIds; //usersTitleDetails.ToList();
                #endregion
            }

            #region More Commented out stuff that may be useful
            //}


            //== "test")
            //if (ShowTitlesListView.SelectedItems.Count > 1)
            //{

            //        Title selectedTitleID = ((Title)ShowTitlesListView.SelectedItem);
            //        List<Title> selectedTitlesID = new List<Title>();
            //        //Get public Title Id for Deleting a single and user forgets to select it
            //        SelectedTitleId = selectedTitleID.TitleId;

            //    var TitlesList = new List<Title>();
            //        using (var context = new PRSappContext())
            //        {
            //           var usersTitleDetails =
            //           from t in context.Titles
            //           where t.TitleId == selectedTitleID.TitleId
            //           select t;

            //       // TitleListIds.AddRange(usersTitleDetails);

            //        List<Title> selectedUsersTitles = TitleListIds; //usersTitleDetails.ToList();

            //        }

            //}
            #endregion

            DataPackage dataPackage = new DataPackage();
            foreach (var item in e.AddedItems.OfType<ListViewItem>())
            {
                // copy 
                dataPackage.RequestedOperation = DataPackageOperation.Copy;
            }        

            if (ShowTitlesListView.SelectedItems.Count > 0)
            {
                Title selectedTitleID = ((Title)ShowTitlesListView.SelectedItem);
                int _selectedTitleID = selectedTitleID.TitleId;
                //Get public Title Id for Deleting a single and user forgets to select it
                SelectedTitleId = selectedTitleID.TitleId;

                using (var context = new PRSappContext())
                {
                    var usersTitleDetails =
                       from t in context.Titles
                       where t.TitleId == selectedTitleID.TitleId
                       select t;

                    List<Title> selectedUsersTitles = usersTitleDetails.ToList();

                    TitleDetailsListView.ItemsSource = selectedUsersTitles;
                    TitleDetailsListView.SelectedIndex = 0;
                }
                
                //put TTS in the Mental Prep user Control's TextBox
                using (var context = new PRSappContext())
                {
                    var usersTitleDetails =
                       from t in context.Titles
                       where t.TitleId == selectedTitleID.TitleId
                       select t.TtsRaw;       
                }
                #region Enable/Disable TitleDeatilPanle's buttons when it's list view has no Item
                if (TitleDetailsListView.Items.Count > 0 &&
                    TitleDetailsListView.Items.Count < 2)
                {
                    btnDetailsPlay.IsEnabled = true;
                    btnShowUpDatePanel.IsEnabled = true;
                    btnShowDeletePanel.IsEnabled = true;
                }
                else
                {
                    btnDetailsPlay.IsEnabled = false;
                    btnShowUpDatePanel.IsEnabled = false;
                    btnShowDeletePanel.IsEnabled = false;
                    TitleDetailsPanel.Visibility = Visibility.Visible;
                    TitleDetailsPanel.Height = 630;                  
                }
                #endregion
            }           
        }

        private void ShowTitlesListView_KeyUp(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {

        }
        #endregion

        #region 3rd Col
        #region Add Title
        ////    ASYNCHRONOUS SAVING
        //  Asynchronous saving avoids blocking a thread while the changes
        //are written to the database.This can be useful to
        //avoid freezing the UI of a thick-client application.
        //  Asynchronous operations can also increase throughput in a
        //web application, where the thread can be freed up to service
        //other requests while the database operation completes. 
        private async void AddTitleAsync_Click(object sender, RoutedEventArgs e)
        {
            string ttsRaw;
            string tag = (sender as Button).Tag.ToString();
            #region Little
            if (tag == "AddTitleLittleAsync")
            {
                #region validation user input checking (if,else if)
                if (String.IsNullOrEmpty(boxAddTitleName.Text.Trim()))
                {

                    ttsRaw = CurrentUserName + "," +
                        "some belive, that one should give the title a name before adding it.";
                    boxAddTitleName.Focus(FocusState.Pointer);
                    try
                    {
                        await this.SpeakTextAsync(ttsRaw, this.uiMediaElement);
                    }
                    catch (Exception ex)
                    { Debug.WriteLine(ex.Message.ToString()); }

                    return;
                }
                else if (String.IsNullOrEmpty(boxAddTitleTtsRaw.Text.Trim()))
                {
                    ttsRaw = "Confucious say" + "." +
                        ", there are times when it helps to give it something" +
                        " to speak before adding it.";
                    boxAddTitleTtsRaw.Focus(FocusState.Pointer);
                    try
                    {
                        await this.SpeakTextAsync(ttsRaw, this.uiMediaElement);
                    }
                    catch (Exception ex)
                    { Debug.WriteLine(ex.Message.ToString()); }

                    return;
                }
                #endregion
                using (var context = new PRSappContext())
                {
                    var title = new Title
                    {
                        //TitleId = Auto Generated - Primary Key                  
                        TitleName = boxAddTitleName.Text,
                        TtsRaw = boxAddTitleTtsRaw.Text,
                        UserId = CurrentUserId,
                        DirPath = "In Database"
                        //Titles = new List<Title>
                        //{
                        //    new Title
                        //    {
                        //        TitleName = NewTitleTitleName.Text,
                        //        TtsRaw = NewTitleTtsRaw.Text
                        //    },
                        //}
                    };
                    context.Titles.Add(title);
                    //Async Save 
                    await context.SaveChangesAsync();

                    #region refresh Titles and Titles Details of Title just Added
                    var usersTitles =
                           from t in context.Titles
                           where t.UserId == CurrentUserId
                           orderby t.TitleId descending
                           select t;

                    List<Title> refreshedUsersTitles = usersTitles.ToList();
                    ShowTitlesListView.ItemsSource = refreshedUsersTitles;

                    //validation logic
                    btnAddTitleLittleAsync.IsEnabled = false;
                    #endregion
                    #region validation logic
                    boxAddTitleName.IsReadOnly = true;
                    boxAddTitleTtsRaw.IsReadOnly = true;
                    btnAddTestPlay.Focus(FocusState.Pointer);
                    #endregion
                }
                #region  refresh Titles and Title Details of Title just Added
                //TODO: ARS- Get last PK Id Inserted
                using (var context = new PRSappContext())
                {
                    var usersTitle =
                         (from t in context.Titles
                              // where t.UserId == CurrentUserId
                              // select t;

                          where t.UserId == CurrentUserId
                          orderby t.TitleId descending
                          select t);//.FirstOrDefault();

                    var takeOne = usersTitle.Take(1);
                    List<Title> refreshedUsersTitles = takeOne.ToList();

                    //TitleDetailsListView.ItemsSource = refreshedUsersTitles;
                }
                #endregion




                //private void AddNewTitle_Click(object sender, RoutedEventArgs e)
                //{
                //    using (var context = new PRSappContext())
                //    {
                //        var user = new User
                //        {
                //            UserLogin = NewUserUserLogin.Text,
                //            UserPwd = NewUserUserPwd.Text,
                //            Titles = new List<Title>
                //            {
                //                new Title
                //                {
                //                      TitleName = boxAddTitleName.Text,
                //                      TtsRaw = boxAddTitleTtsRaw.Text,
                //                },
                //                //new Title { TitleName = "TitleName_3"}
                //            }

                //        };
                //        context.Users.Add(user);
                //        context.SaveChanges();

                //        ShowTitlesListView.ItemsSource = context.Titles.ToList();
                //    }
                //}


                #region Big
                //private async void AddTitleBigAsync_Click(object sender, RoutedEventArgs e)
                //{
                //    string ttsRaw;
                //    string tag = (sender as Button).Tag.ToString();
                //    if (tag == "btnAddTitleBigAsync")
                //    {
                //        #region validation user input checking (if,else if)
                //        if (String.IsNullOrEmpty(boxAddTitleNameBig.Text.Trim()))
                //        {

                //            ttsRaw = CurrentUserName + "," +
                //                "some belive, that one should give the title a name before adding it.";
                //            boxAddTitleNameBig.Focus(FocusState.Pointer);
                //            try
                //            {
                //                await this.SpeakTextAsync(ttsRaw, this.uiMediaElement);
                //            }
                //            catch (Exception ex)
                //            { Debug.WriteLine(ex.Message.ToString()); }

                //            return;
                //        }
                //        else if (String.IsNullOrEmpty(boxTtsRawBig.Text.Trim()))
                //        {
                //            ttsRaw = "Confucious say" + "." +
                //                ", there are times when it helps to give it something" +
                //                " to speak before adding it.";
                //            boxTtsRawBig.Focus(FocusState.Pointer);
                //            try
                //            {
                //                await this.SpeakTextAsync(ttsRaw, this.uiMediaElement);
                //            }
                //            catch (Exception ex)
                //            { Debug.WriteLine(ex.Message.ToString()); }

                //            return;
                //        }
                //        #endregion
                //        using (var context = new PRSappContext())
                //        {
                //            var title = new Title
                //            {
                //                //TitleId = Auto Generated - Primary Key                  
                //                TitleName = boxAddTitleNameBig.Text,
                //                TtsRaw = boxTtsRawBig.Text,
                //                UserId = CurrentUserId,
                //                DirPath = "In Database"
                //                //Titles = new List<Title>
                //                //{
                //                //    new Title
                //                //    {
                //                //        TitleName = NewTitleTitleName.Text,
                //                //        TtsRaw = NewTitleTtsRaw.Text
                //                //    },
                //                //}
                //            };
                //            context.Titles.Add(title);
                //            //Async Save 
                //            await context.SaveChangesAsync();

                //            #region refresh Titles and Titles Details of Title just Added
                //            var usersTitles =
                //                   from t in context.Titles
                //                   where t.UserId == CurrentUserId
                //                   orderby t.TitleId descending
                //                   select t;

                //            List<Title> refreshedUsersTitles = usersTitles.ToList();
                //            ShowTitlesListView.ItemsSource = refreshedUsersTitles;

                //            //validation logic
                //            btnAddPTitleBigAsync.IsEnabled = false;
                //            #endregion
                //            #region validation logic
                //            boxAddTitleNameBig.IsReadOnly = true;
                //            boxTtsRawBig.IsReadOnly = true;
                //            btnTestPlayBig.Focus(FocusState.Pointer);
                //            #endregion
                //        }
                #region  refresh Titles and Title Details of Title just Added
                //TODO: ARS- Get last PK Id Inserted
                using (var context = new PRSappContext())
                {
                    var usersTitle =
                         (from t in context.Titles
                              // where t.UserId == CurrentUserId
                              // select t;

                          where t.UserId == CurrentUserId
                          orderby t.TitleId descending
                          select t);//.FirstOrDefault();

                    var takeOne = usersTitle.Take(1);
                    List<Title> refreshedUsersTitles = takeOne.ToList();

                    //TitleDetailsListView.ItemsSource = refreshedUsersTitles;
                }
                #endregion

                #endregion
            }

        }
        private async void TestPlayAsync_Click(object sender, RoutedEventArgs e)
        {
            string ttsRaw = "no Text to Speak of!";

            string tag = (sender as Button).Tag.ToString();
            if (tag == "btnAddTestPlay")
            {
                ttsRaw = boxAddTitleTtsRaw.Text.Trim();
                if (String.IsNullOrEmpty(ttsRaw))
                {
                    ttsRaw = "no Text to Speak of. Give me something.";
                }
            }

            try
            {
                await this.SpeakTextAsync(ttsRaw, this.uiMediaElement);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
            }
            Debug.WriteLine("ttsraw: " + ttsRaw);
        }

        private async void PlayAsync_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("PlayAsync_Click" + timesTicked.ToString());
            //if (timesTicked < 1)
            //{
            //    dispatcherTimer.Start();
            //}
            //else if(timesTicked > 0 && timesTicked < 4)
            //{
            //    dispatcherTimer.Stop();
            //}

            string ttsRaw = "no Text to Speak of!";
            //H- var whoRanThisMethod = (sender as dispatcherTimer).
            string tag = (sender as Button).Tag.ToString();
            if (tag == "btnDetailsPlay")
            {
                //H -someOne hacked in and did this code  ttsRaw = boxWatchAndPlayTtsRaw.Text.Trim();
                if (String.IsNullOrEmpty(ttsRaw))
                {
                    ttsRaw = "no Text to Speak of. Give me something.";
                }
                else
                {
                    ttsRaw = CurrentDetailsTtsRaw;
                }
            }
            try
            {
                await this.SpeakTextAsync(ttsRaw, this.uiMediaElement);
                //Ad-Hoc Dispatcher Timer- code set

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
            }
            Debug.WriteLine("ttsraw: " + ttsRaw);
        }
        //private async void TestPlayBigAsync_Click(object sender, RoutedEventArgs e)
        //{
        //    string ttsRaw = "no Text to Speak of!";
        //    string tag = (sender as Button).Tag.ToString();

        //    if (tag == "btnTestPlayBig")
        //    {
        //        ttsRaw = boxTtsRawBig.Text.Trim();
        //    }
        //    try
        //    {
        //        await this.SpeakTextAsync(ttsRaw, this.uiMediaElement);
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message.ToString());
        //    }
        //    Debug.WriteLine("ttsraw: " + ttsRaw);
        //}

        private void ClearAddBoxes_Click(object sender, RoutedEventArgs e)
        {
            boxAddTitleName.Text = "";
            boxAddTitleTtsRaw.Text = "";

            boxAddTitleName.IsReadOnly = false;
            boxAddTitleTtsRaw.IsReadOnly = false;
            boxAddTitleName.Focus(FocusState.Pointer);
            btnAddTitleLittleAsync.IsEnabled = true;
        }

        //private void ClearAddBoxesBig_Click(object sender, RoutedEventArgs e)
        //{
        //    boxAddTitleNameBig.Text = "";
        //    boxTtsRawBig.Text = "";

        //    boxAddTitleNameBig.IsReadOnly = false;
        //    boxTtsRawBig.IsReadOnly = false;
        //    boxAddTitleNameBig.Focus(FocusState.Pointer);
        //    btnAddPTitleBigAsync.IsEnabled = true;
        //}

        #region Below 'static async Task' not sure how to use  
        ////**Below Task/MethodS not in use yet, not sure how to call it.
        ////+also not sure affects of saving straight to Title entity of the Context
        ////use in a method something like this:
        //// AddNewTitleAsync(NewUserUserLogin.Text, NewUserUserPwd.Text);
        //public static async Task AddNewTitleAsync(string titleName, string ttsRaw)
        //{
        //    using (var context = new PRSappContext())
        //    {
        //        var title = new Title
        //        {
        //            TitleName = titleName,
        //            TtsRaw = ttsRaw
        //        };
        //        context.Titles.Add(title);
        //        await context.SaveChangesAsync();
        //    }
        //}
        #endregion
        #endregion ends Add Title
        #region Editing Titles
        private void TitleDetailsListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Title selectedTitle = ((Title)TitleDetailsListView.SelectedItem);

            if (TitleDetailsListView.Items.Count > 0)

                //Load Update Title Panel with Selected Item    
                if (selectedTitle != null)
                {
                    //Verbose and play
                    CurrentDetailsTtsRaw = selectedTitle.TtsRaw;
                    EditTitleId = selectedTitle.TitleId;
                    boxUpdateTitleName.Text = selectedTitle.TitleName;
                    boxUpdateTitleTtsRaw.Text = selectedTitle.TtsRaw;
                    //Put TitleId and UserId into public fields for Delete
                    DeleteTitleId = selectedTitle.TitleId;
                    CurrentUserId = selectedTitle.UserId;

                    //WIP 
                    //Load page-->child UCs, that is bool IsAppFxCompatible with
                    //with values.
                    //Next step will be to make a page level bool ToggleButton in case
                    //user wants to run some other content
                  this.MPrepUC.TTS = selectedTitle.TtsRaw;
                   this.MPrepUC.PassPageValsToSetBindings(this.MPrepUC.TTS);


                }
        }

        ////UPDATING DATA       /   Modify   /    Update      
        private void BtnShowUpDatePanel_Click(object sender, RoutedEventArgs e)
        {
            TitleDetailsPanel.Height = 0;
            TitleDetailsListView.SelectedIndex = 0;
            if (DeleteTitlesPanel.Visibility == Visibility.Visible)
            {
                DeleteTitlesPanel.Visibility = Visibility.Collapsed;
            }

            UpdateTitlesPanel.Visibility = Visibility.Visible;
          //not needed, set at Des. time   UpdateTitlesPanel.Height = 630;
            //Fill Delete Panel with selected Title\\
            //Query DBContext
            using (var context = new PRSappContext())
            {
                var results =
                     from t in context.Titles
                     where t.TitleId == EditTitleId &&
                           t.UserId == CurrentUserId
                     select t;

                //Assign results
                List<Title> deleteTitle = results.ToList();
                //Show in ListView
                DeleteTitlesListView.ItemsSource = deleteTitle;
            }
            //Approach 2 - DeleteTitlesListView.ItemsSource = TitleDetailsListView.ItemsSource;
            DeleteTitlesListView.SelectedIndex = 0;
        }

        private void UpdateData_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new PRSappContext())
            {
                var title = context.Titles.First();
                title.TtsRaw = "80Raw-Updated";
                context.SaveChanges();

                //refresh listview after update
                //?\\UpdateDataListView.ItemsSource = context.Titles.ToList();
            }
        }

        private async void UpDateChangesAsync_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new PRSappContext())
            {
                var title =
                await context.Titles.FirstOrDefaultAsync(x => x.TitleId == EditTitleId);
                title.TitleName = boxUpdateTitleName.Text.Trim();
                title.TtsRaw = boxUpdateTitleTtsRaw.Text.Trim();
                await context.SaveChangesAsync();

                //refresh listview after update              
                var queryresults =
                     from t in context.Titles
                     where t.TitleId == EditTitleId
                     select t;

                //Put queryresults into a collection
                List<Title> selectedUsersTitles = queryresults.ToList();

                //Load Update Title Panel with Selected Item            
                TitleDetailsListView.ItemsSource = selectedUsersTitles;

                //Clear controls in Edit title panel
                boxUpdateTitleName.Text = String.Empty;
                boxUpdateTitleTtsRaw.Text = String.Empty;
                //Collapse Update Titles Panel and Showing Details Panel after edit complete
                UpdateTitlesPanel.Visibility = Visibility.Collapsed;
                TitleDetailsPanel.Visibility = Visibility.Visible;
                TitleDetailsPanel.Height = 630;
            }
        }

        private void UndoChanges_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new PRSappContext())
            {
                var title = context.Titles;
                //title.TtsRaw = "80Raw-Updated";
                context.SaveChanges();

                //refresh listview after update
            }
        }

        private void UndoChangesAsync_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Deleting Data
        /// <summary>
        /// For User Validation or better flowing experience, this method
        /// programatically Selects or Deselects Control Items. Example,
        /// Would you really require a user to select a listviews item,
        /// where there is only  one item in the listview anyway?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ItemClickEventArgs"></param>
        public void SelectOrDeselectControlsItems(object sender, ItemClickEventArgs e)
        {
            Debug.WriteLine("Clicked item");
            //Get controls type and Cast it.
            ListView ctlr = sender as ListView;
            //Get the item(s) selected, if any

            ListViewItem listItem = ctlr.ContainerFromItem(e.ClickedItem) as ListViewItem;
            if (listItem != null)//For De-Selecting item(s)
            {
                if (listItem.IsSelected)
                {
                    listItem.IsSelected = false;
                    ctlr.SelectionMode = ListViewSelectionMode.None;
                }
                else
                {
                    ctlr.SelectionMode = ListViewSelectionMode.Single;
                    listItem.IsSelected = true;
                }
            }
            else //For Selecting item(s)
            {
                if (!listItem.IsSelected)
                {
                    ctlr.SelectedIndex = 0;
                    ctlr.SelectionMode = ListViewSelectionMode.Single;
                }
                else
                {
                    ctlr.SelectionMode = ListViewSelectionMode.None;
                    listItem.IsSelected = true;
                }
            }
        }
        /// <summary>
        /// /// For User Validation or better flowing experience, this method
        /// programatically Selects or De-selects Control Items. Example,
        /// Would you really require a user to select a listviews item,
        /// where there is only one item in the listview anyway?
        /// The Overload is for controls that have SelectionMode enumeration
        /// of .None .Single, .Multiple, or .None(single or multiple) selection item(s).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ItemClickEventArgs"></param>
        /// <param name="selectionMode"></param>
        public void SelectControlsItems(object sender, ItemClickEventArgs e, Int16 selectionMode)
        {
            Debug.WriteLine("Clicked item");
            ListView list = sender as ListView;
            ListViewItem listItem = list.ContainerFromItem(e.ClickedItem) as ListViewItem;
            Int16 _selectionMode = (Int16)list.SelectionMode;
            //0 = none      >>  user can't select item(s)
            //1 = single    >>  user can select one item
            //2 = multiple  >>  user can select multiple items w/o entering
            //3 = extended  >>  user can select multiple items by entering a special mode,
            //                  for example when depressing a modifier key.
            if (listItem == null)//Select the item programatically
            {
                if (!listItem.IsSelected)
                {
                    listItem.IsSelected = true;
                    list.SelectionMode = ListViewSelectionMode.Single;
                }
                //else
                //{
                //    list.SelectionMode = ListViewSelectionMode.;
                //    listItem.IsSelected = true;
                //}
            }
        }

        private void TitleDetailsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Debug.WriteLine("Clicked item");
            ListView listView = sender as ListView;
            ListViewItem listItem = listView.ContainerFromItem(e.ClickedItem) as ListViewItem;

            //if (!listItem.IsSelected)
            //{
            //    listItem.IsSelected = true;
            //    listView.SelectionMode = ListViewSelectionMode.Single;
            //}

            //////Below is to De-Select item
            ////if (listItem.IsSelected)
            ////{
            ////    listItem.IsSelected = false;
            ////    listView.SelectionMode = ListViewSelectionMode.None;
            ////}
            ////else
            ////{
            ////    listView.SelectionMode = ListViewSelectionMode.Single;
            ////    listItem.IsSelected = true;
            ////}
        }

        private void BtnShowDeletePanel_Click(object sender, RoutedEventArgs e)
        {
            TitleDetailsPanel.Height = 0;
            DeleteTitlesListView.SelectedIndex = 0;
            if (UpdateTitlesPanel.Visibility == Visibility.Visible)
            {
                UpdateTitlesPanel.Visibility = Visibility.Collapsed;
            }

            DeleteTitlesPanel.Visibility = Visibility.Visible;
           // DeleteTitlesPanel.Height = 630;

            //Fill Delete Panel with selected Title\\
            //Query DBContext
            using (var context = new PRSappContext())
            {
                var results =
                     from t in context.Titles
                     where t.TitleId == DeleteTitleId && t.UserId == CurrentUserId
                     select t;

                //Assign results
                List<Title> deleteTitle = results.ToList();
                //Show in ListView
                DeleteTitlesListView.ItemsSource = deleteTitle;

                Title selectedTitle = ((Title)TitleDetailsListView.SelectedItem);

            }
            //Approach 2 - DeleteTitlesListView.ItemsSource = TitleDetailsListView.ItemsSource;
        }
        ////DELETING DATA       /   Remove    /    Delete
        //Use the DbSet.Remove method to delete instances of your entity classes.
        //If the entity already exists in the database, it will be deleted during
        //SaveChanges.If the entity has not yet been saved to the
        //database(that is, it is tracked as added) then it will be removed from
        //the context and will no longer be inserted when SaveChanges is called.
        private void DeleteData_Click(object sender, RoutedEventArgs e)
        {
            //TODO: ARS- Use this if/else approach for PlayListFxsDetails List or Titles List
            //      becuase we only want one item/row/title domain object at a sime here
            ////if(TitleDetailsListView.SelectedItems.Count > 0)
            ////{ 
            ///
            if (TitleDetailsListView.SelectedItems.Count > 0)
            {
                var title = new Title()
                {
                    TitleId = DeleteTitleId //SelectedTitleId
                };
                using (var context = new PRSappContext())
                {
                    //EntityState is set as ‘Deleted’                 
                    context.Titles.Remove(title);

                    //Have EF Core actually delete record from db
                    context.SaveChanges();

                    //Refresh listview after delete      
                    var queryresults =
                         from t in context.Titles
                         where t.UserId == CurrentUserId
                         orderby t.TitleId descending
                         select t;
                    int count = queryresults.Count();
                    if (count > 0)
                    {
                        //Put queryresults into a collection
                        List<Title> selectedUsersTitles = queryresults.ToList();

                        //Load Update Title Panel with Selected Item            
                        ShowTitlesListView.ItemsSource = selectedUsersTitles;

                    }
                    TitleDetailsPanel.Visibility = Visibility.Visible;
                    TitleDetailsPanel.Height = 630;
                    ////else
                    ////{

                    // DeleteTitlesPanel.Visibility = Visibility.Collapsed;
                    ////}
                }
                using (var context = new PRSappContext())
                {
                    //Refresh TitleDetailsListView & DeleteTitlesListView after delete      
                    var queryresults =
                         from t in context.Titles
                         where t.UserId == CurrentUserId && t.TitleId == DeleteTitleId
                         orderby t.TitleId descending
                         select t;

                    //Put queryresults into a collection
                    List<Title> selectedUsersTitles = queryresults.ToList();

                    //Show results if Any
                    TitleDetailsListView.ItemsSource = selectedUsersTitles;
                    DeleteTitlesListView.ItemsSource = selectedUsersTitles;

                    #region Enable/Disable TitleDeatilPanle's buttons when it's list view has no Item
                    if (TitleDetailsListView.Items.Count > 0 &&
                        TitleDetailsListView.Items.Count < 2)
                    {
                        btnDetailsPlay.IsEnabled = true;
                        btnShowUpDatePanel.IsEnabled = true;
                        btnShowDeletePanel.IsEnabled = true;
                    }
                    else
                    {
                        btnDetailsPlay.IsEnabled = false;
                        btnShowUpDatePanel.IsEnabled = false;
                        btnShowDeletePanel.IsEnabled = false;
                        DeleteTitlesPanel.Visibility = Visibility.Collapsed;
                        TitleDetailsPanel.Visibility = Visibility.Visible;
                       //dup TitleDetailsPanel.Height = 630;
                    }
                    #endregion

                }
            }
            ////}
        }

        private async void DeleteSelectionAsync_Click(object sender, RoutedEventArgs e)
        {
            //List<Object> items = ShowTitlesListView.SelectedItems.Cast<ListViewItem>()
            //    .Select(item => item.tit)
            //List<SelectedItems> selItems = new List<SelectedItems>();
            var listViewItems = ShowTitlesListView.SelectedItems;
            foreach (var item in listViewItems)
            {

            }
            //ListView.sho; SelectedItems selectedItems 
            //  =  new
            //I need to to get the selected items into a list first.
            //Multi selection
            if (ShowTitlesListView.SelectedItems.Count > 0)
            {

                //                List<Title> selectedtitles = new List<Title>()
                //                {
                //                    foreach(var item in ShowTitlesListView.SelectedItems)
                //                    new Department(){TitleID=1},
                //                    new Department(){Id=2},
                //                    new Department(){Id=3}
                //};
                //  (Title)ShowTitlesListView = ((Title)ShowTitlesListView.SelectedItems);

                using (var context = new PRSappContext())
                {

                    //(
                    //var queryresults =
                    //    from t in context.Titles
                    //    where t.TitleId == ShowTitlesListView.SelectedItems.Add() // && t.TitleId == SelectedTitleId
                    //     select t;
                    //context.Titles.RemoveRange(selectedTitles);

                    await context.SaveChangesAsync();

                    //Refresh listview after delete      
                    var queryresults =
                         from t in context.Titles
                         where t.UserId == CurrentUserId // && t.TitleId == SelectedTitleId
                         orderby t.TitleId descending
                         select t;
                    int count = queryresults.Count();
                    if (count > 0)
                    {
                        //Put queryresults into a collection
                        List<Title> selectedUsersTitles = queryresults.ToList();

                        //Load Update Title Panel with Selected Item            
                        ShowTitlesListView.ItemsSource = selectedUsersTitles;
                        btnShowUpDatePanel.Visibility = Visibility.Collapsed;
                    }
                    //List<Title> titles = new List<Title>();

                    //titles = (Title)ShowTitlesListView.SelectedItems;
                    //context.Titles.RemoveRange(items);
                }
            }
            #endregion
            //TODO: ARS- Use this if/else approach for PlayListFxsDetails List or Titles List
            //      becuase we only want one item/row/title domain object at a sime here
            ////if(TitleDetailsListView.SelectedItems.Count > 0)
            ////{ 
            //    var title = new Title()
            //{
            //    TitleId = DeleteTitleId
            //};
            //using (var context = new PRSappContext())
            //{
            //    //EntityState is set as ‘Deleted’
            //    context.Titles.Remove(title);

            //    //Have EF Core actually delete record from db
            //    context.SaveChanges();

            //    //Refresh listview after delete      
            //    var queryresults =
            //         from t in context.Titles
            //         where t.UserId == CurrentUserId
            //         select t;
            //    int count = queryresults.Count();
            //    if (count > 0)
            //    {
            //        //Put queryresults into a collection
            //        List<Title> selectedUsersTitles = queryresults.ToList();

            //        //Load Update Title Panel with Selected Item            
            //        TitleDetailsListView.ItemsSource = selectedUsersTitles;
            //    }
            //    ////else
            //    ////{
            //    ////}
            //}
            ////}
        }

        private void btnDeleteGoBack_Click(object sender, RoutedEventArgs e)
        {           
            DeleteTitlesPanel.Visibility = Visibility.Collapsed;
            TitleDetailsPanel.Height = 630;
            TitleDetailsPanel.Visibility = Visibility.Visible;
        }
        #endregion

        #region 4th Col 
        private void BtnTestPlayAsync_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ModifyTitleSettings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ArrangeTitlesAsync_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Test Area Code 
        private void TestArea1_Click(object sender, RoutedEventArgs e)
        {

            using (var context = new PRSappContext())
            {
                #region Loading a Single Entity - to TextBlock - NOT WORKING YET
                //try
                //{
                //    var singleUser = 
                //        context.Users.Single(u => u.UserId == 48);
                //    if (singleUser != null)
                //    {
                //       TestAreaTextBlock.Text = singleUser.ToString();
                //    }
                //}
                //catch (Exception ex)
                //{
                //    Debug.WriteLine(".Single(u => u.UserId == 48);\n" +
                //                    "TestAreaTextBlock.Text = singleUser.ToString();\n" +
                //                    "TestAreaTextBlock.Text Val:  " + TestAreaTextBlock.Text + "\n" +
                //                    ex.Message.ToString());
                //}
                #endregion

                #region .ThenInclude test w/o JetBrains's Resharper Intellisense Extension
                //var users = context.Users
                //        .Include(user => user.Titles)
                //        .ThenInclude(title => title.TitleName)
                //        .ToList();
                #endregion

            }
        }

        private void TestArea2_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new PRSappContext())
            {
                #region Remove First
                //var title = context.Titles.First();
                //context.Titles.Remove(title);

                //context.SaveChanges();
                #endregion

                ////FILTERING
                var user = context.Users
                    .Where(b => b.UserId == 45)//SelectedItemIndex)
                    .ToList();

                List<User> userTitles = user;
                //Refresh ListView's ItemsSource
                //TestAreaListView.ItemsSource = userTitles;
                //TestAreaListView.ItemsSource = context.Titles.ToList();
            }
        }

        private void TestArea3_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new PRSappContext())
            {
                var userContains = context.Users
                    .Where(b => b.UserLogin.Contains("Rig"))
                    .ToList();

                List<User> listUserContains = userContains;
                //Populate ListView's ItemsSource
                //TestAreaListView.ItemsSource = listUserContains;
            }
        }
        #endregion

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

        private void NavToQnAPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pages.QnAPage), SignInUserLogin.Text);
        }

        private void NavToDayPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pages.DayPage), SignInUserLogin.Text);
        }

        private void BtnSignOut_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnNavToPageParmPass1_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pages.PageParmPass1), SignInUserLogin.Text);
        }    
    }
    /////Ends MainPage partial Class and starts a static 'Top Level'(non-nested) class in same NameSpace
    //This below static class is an extension method for MediaElement
    //Callers are:
    //  1. MainPage\TitleDetails Play AppBarButton
    //  2.  MainPage\Add Title TestPlay AppBarButton
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
            //start Stop watch TimeSpenBegin
            await taskCompleted.Task;//HERE is where it waits till complete
            //TimeSPanEnd
            //Then add or subtract uc2 intervals.
            mediaElement.MediaEnded -= endOfPlayHandler;
        }
    }
    #endregion
    #endregion
}