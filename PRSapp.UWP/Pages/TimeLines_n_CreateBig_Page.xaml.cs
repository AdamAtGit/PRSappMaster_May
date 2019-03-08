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
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Input;

namespace PRSapp.UWP.Pages
{

    public sealed partial class TimeLines_n_CreateBig_Page : Page
    {
        public string CurrentUserName { get; set; }
        public int CurrentUserId { get; set; }
        public int SelectedTitleId { get; set; }
        public int EditTitleId { get; set; }
        public int DeleteTitleId { get; set; }
        public List<Title> TitleListIds { get; set; }

        //Speech Synth and Recogn
        public string SpeechInputResult { get; set; }

        public TimeLines_n_CreateBig_Page()
        {
            this.InitializeComponent();
            //CurrentUserName = "JRiggins44";
            //SignInUserPwd.Text = "******";
            //TODO: ARS-Get user's Name for Interactive.
            CurrentUserName = "Adam";
            using (var db = new PRSappContext())
            {
                //UsersDefaulHomePageListView.ItemsSource = db.Titles.ToList();
                ShowTitlesListView.ItemsSource = db.Titles.ToList();
                //UpdateTitlesListView.ItemsSource = db.Titles.ToList();
                //DeleteTitlesListView.ItemsSource = db.Titles.ToList();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
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
        }
      
        #region ListView Titles selecting functionality
        private void BtnSetSelectionModeToMulitple_Click(object sender, RoutedEventArgs e)
        {
            //ShowTitlesListView.MultiSelect = true;
            //Below line not doing anything
            ShowTitlesListView.SelectionMode = (ListViewSelectionMode)SelectionMode.Multiple;
        }
        #endregion End - ListView Titles selecting functionality

        #region ListView Titles Multiple Delete Functionality
        public int SelectedItemIndex;
        public object SelectedItem;
        //public string SelectedDataValue;
        // public string SelectedDataPath;
        public IEnumerable<Title> MultiSelectedTitles;
        public List<Title> MultiSelected;

        private void ShowTitlesListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Title dt_t = new Title();
            //List<Title> ts = new List<Title>();
            //ts.Add(dt_t.TitleId = 100);
            //    dt_t.TitleName = "Name1",
            //    dt_t.TtsRaw="IpsumLipsi",
            //    dt_t.UserId= 44,
            //    dt_t.DirPath = "C:Users\\Documents\\Media");

            //ts.Add("TitleName1", "C:Users\\Documents\\Media");
            //Multi selection           
            if (ShowTitlesListView.SelectedItems.Count > 1)
            {
                // List<Object> DeletionTitles;// = new List<Title>();
                //  List<Title>  DeletionTitles = ((Title)ShowTitlesListView.SelectedItems);
                //  DeletionTitles.AddRange(SelectedTitles);

                //List<Title> selectedTitles = selectedTitlesID;
                //Get public Title Id for Deleting a single and user forgets to select it
                // SelectedTitleId = selectedTitlesID.TitleId;

                //var TitlesList = new List<Title>();
                //using (var context = new PRSappContext())
                //{
                //    var TitlesSelected =
                //    from t in context.Titles
                //    where t.TitleId == DeletionTitles.TitleId
                //    select t;

                //    // TitleListIds.AddRange(usersTitleDetails);
                //    TitleListIds = TitlesSelected.ToList();
                //    foreach (var item in TitleListIds)
                //    {
                //        Trace.WriteLine(item);
                //    }


                //Refresh Show Titles List View
                List<Title> selectedTitles = TitleListIds; //usersTitleDetails.ToList();
            }
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

            DataPackage dataPackage = new DataPackage();
            foreach (var item in e.AddedItems.OfType<ListViewItem>())
            {
                // copy 
                dataPackage.RequestedOperation = DataPackageOperation.Copy;
            }
            //TitlesListView Title = ((new_client)Listview.SelectedItem);
            //MyClient.new_name;
            //MyClient.new_clientId;

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

                    ////TitleDetailsListView.ItemsSource = selectedUsersTitles;
                    ////TitleDetailsListView.SelectedIndex = 0;
                }
            }
         
            #region Commented code for Selected item, Index, DataValue, and DataValuePath
            // Debug.WriteLine("Selected: {0}", e.AddedItems[0]);

            // SelectedItemIndex = ShowTitlesListView.SelectedIndex;
            // Debug.WriteLine(SelectedItemIndex.ToString());

            //  SelectedItem = ShowTitlesListView.SelectedItem;
            // Debug.WriteLine(SelectedItem.ToString());

            // var SelectedDataValue = ShowTitlesListView.SelectedValue;
            // Debug.WriteLine(SelectedDataValue.ToString());

            // var SelectedValuePath = ShowTitlesListView.SelectedValuePath;
            // Debug.WriteLine(SelectedValuePath.ToString());

            //  String text = UsersTitlesPListView.SelectedItems[2].ToString();
            //do something

            //  var lookat = text;
            //var item = e.AddedItems?.FirstOrDefault();
            ////int Uid = (int)item.ToString

            //if (TitlesListView.SelectedItems.Count > 0)
            //{
            //    var itemrow = ShowTitlesListView.SelectedItems[0];
            //    //rest of your logic
            //}

            //if (TitlesListView.SelectedItems.Count > 0)
            //{
            //    var myitem = ShowTitlesListView.SelectedItems[0];
            //    //rest of your logic
            //}
            #endregion
        }

        private void ShowTitlesListView_KeyUp(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {

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
                         select t;
                    int count = queryresults.Count();
                    if (count > 0)
                    {
                        //Put queryresults into a collection
                        List<Title> selectedUsersTitles = queryresults.ToList();

                        //Load Update Title Panel with Selected Item            
                        ShowTitlesListView.ItemsSource = selectedUsersTitles;
                    }
                    //List<Title> titles = new List<Title>();

                    //titles = (Title)ShowTitlesListView.SelectedItems;
                    //context.Titles.RemoveRange(items);
                }
            }

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
        #endregion End - ListView Ttitles functionality
    }
}
