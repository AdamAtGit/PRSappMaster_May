using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PRSapp.Classes
{
    public class PlayList
    {
        //[SQLite.PrimaryKey]
        public string PLName   { get; set; }

        public string PLCat { get; set; }

        public string PLAppFx { get; set; }

        //Method that Returns a List - The Select
        ////public List<PlayList> GetPlayLists()
        ////{
        ////    List<PlayList> playLists = new List<PlayList>();

        ////    using (var db = new SQLite.SQLiteConnection(App.DBPath))
        ////    {
        ////        var query = db.Table<PlayList>().OrderBy(p => p.PLName);

        ////        foreach (var playList in query)
        ////        {
        ////            playLists.Add(playList);
        ////        }
        ////    }


        ////    return playLists;
        ////}
        
        //UpDate Method
        public void UpDatePlayList(PlayList playList)
        {
            //using (var db = new SQLite.SQLiteConnection(App.DBPath))
            //{
                //try
                //{
                //    db.Update(playList);
                //}
                //catch (Exception) { }
            //}
        }


        //Delete Method
        public void DeletePlayList(PlayList playList)
        {
            //using (var db = new SQLite.SQLiteConnection(App.DBPath))
            //{
            //    try
            //    {
            //        db.Delete(playList);
            //    }
            //    catch (Exception) { }
            //}
        }

        //Insert Method
        public void InsertPlayList(PlayList playList)
        {
            //using (var db = new SQLite.SQLiteConnection(App.DBPath))
            //{
            //    try
            //    {
            //        var existingPlayList =
            //        (db.Table<PlayList>().Where(p => p.PLName == playList.PLName)).SingleOrDefault();

            //        if (existingPlayList != null)
            //        {
            //            existingPlayList.PLCat = playList.PLCat;
            //            existingPlayList.PLAppFx = playList.PLAppFx;

            //            this.UpDatePlayList(existingPlayList);
            //        }
            //        else
            //        {
            //            db.Insert(playList);
            //        }
            //    }
            //    catch (Exception) { }
            //}
        }
    }
}
