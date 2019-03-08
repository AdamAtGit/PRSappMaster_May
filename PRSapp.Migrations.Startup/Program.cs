//using System;

//namespace PRSapp.Migrations.Startup
//{
//    public class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello World!");
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
//ARS- The 2 lines below ad pending EF Migrations
using PRSapp.Model;
#pragma warning disable 169

namespace PRSapp.Migrations.Startup
{
    public class Program
    {
        private static void Main()
        {
            SetupDatabase();

            using (var db = new PRSappContext())
            {
                #region Query
                var pListAndItems= db.PlayListAndItems.ToList();

                foreach (var pListAndItem in pListAndItems)
                {
                    
                    Console.WriteLine($"{pListAndItem.PlayListName} has {pListAndItem.PlayListName} PlayListItems.");//
                    Console.WriteLine();
                }
                #endregion
            }
        }

        private static void SetupDatabase()
        {
            using (var db = new PRSappContext())
            {
                if (db.Database.EnsureCreated())
                {
                    //working way down
                    db.PlayLists.Add(
                        new PlayList
                        {
                            Name = "Fish PlayList",
                            Uses = "ForceTalk",
                            PlayListItems = new List<PlayListItem>
                            {
                                new PlayListItem { ItemTitleName = "Fish care 101" },
                                new PlayListItem { ItemTitleName = "Caring for tropical fish" },
                                new PlayListItem { ItemTitleName = "Types of ornamental fish" }
                            }
                        });

                    db.PlayLists.Add(
                        new PlayList
                        {
                            Name = "Cats PlayList",
                            Uses = "t-30",
                            PlayListItems = new List<PlayListItem>
                            {
                                new PlayListItem { ItemTitleName = "Cat care 101" },
                                new PlayListItem { ItemTitleName = "Caring for tropical cats" },
                                new PlayListItem { ItemTitleName = "Types of ornamental cats" }
                            }
                        });

                    db.PlayLists.Add(
                        new PlayList
                        {
                            Name = "Catfish PlayList",
                            Uses = "Reminder",
                            PlayListItems = new List<PlayListItem>
                            {
                                new PlayListItem { ItemTitleName = "Catfish care 101" },
                                new PlayListItem { ItemTitleName = "History of the catfish name" }
                            }
                        });

                    db.SaveChanges();

                    //I created view manually in sqlite manager
                    //#region View
                    //db.Database.ExecuteSqlCommand(
                    //    @"CREATE VIEW View_PlayListAndItems AS 
                    //        SELECT b.Name, Count(p.PlayListItemId) as ItemCount 
                    //        FROM PlayLists b
                    //        JOIN PlayListItems p on p.PlayListId = b.PlayListId
                    //        GROUP BY b.Name");
                    //#endregion
                }
            }
        }
    }

    //public class PRSappContext : DbContext
    //{
    //    private static readonly ILoggerFactory _loggerFactory
    //        = new LoggerFactory().AddConsole((s, l) => l == LogLevel.Information && !s.EndsWith("Connection"));

    //    public DbSet<PlayList> PlayLists { get; set; }//
    //    public DbSet<PlayListItem> PlayListItems { get; set; }//

    //    public DbQuery<PlayListAndItem> PlayListAndItems { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        optionsBuilder
    //            .UseSqlServer(
    //                @"Server=(localdb)\mssqllocaldb;Database=Sample.QueryTypes;Trusted_Connection=True;ConnectRetryCount=0;")
    //            .UseLoggerFactory(_loggerFactory);
    //    }

    //    #region Configuration
    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder
    //            .Query<PlayListAndItem>().ToView("View_PlayListAndItems")////
    //            .Property(v => v.PlayListName).HasColumnName("Name");////
    //    }
    //    #endregion
    //}

    //#region Entities
    //public class PlayList
    //{
    //    public int PLId { get; set; }
    //    public int UserId { get; set; }
    //    public string Name { get; set; }
    //    public string Uses { get; set; }
    //    public int Repeats { get; set; }//0 no repeat, 1-n repeats times, -1 or 1000 Continuous Repeat
    //    public bool ShuffleIsOn { get; set; }
    //    public ICollection<PlayListItem> PlayListItems { get; set; }
    //}

    //public class PlayListItem
    //{
    //    public int PlayListItemId { get; set; }
    //    public int ItemTitleId { get; set; }
    //    public string ItemTitleName { get; set; }
    //    public int Priority { get; set; }//0 Highest (Favorite or Important) - Multi-Cycle and/or Multi Daily,
    //    //1 High - Multi Daily,
    //    //2 Medium  - Multi Weekly,
    //    //3 Low    - Once Weekly, //4 Once Monthly, //5 Once Quarterly,
    //    //6 Once Semi Annually
    //    public int PlayPositions { get; set; }//plural becuase lie a favorite or important to learn
    //    //may play in more than one position in a PlayList
    //    public int PLId { get; set; }
    //}
    //#endregion

    //#region QueryType
    //public class PlayListAndItem
    //{
    //    public string PlayListName { get; set; }
    //    public string ItemTitleName { get; set; }
    //}
    //#endregion
}