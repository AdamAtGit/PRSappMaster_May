using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace PRSapp.Model
{
    public class PRSappContext : DbContext
    {
#pragma warning disable CS0649 // Field 'PRSappContext._loggerFactory' is never assigned to, and will always have its default value null
        private readonly ILoggerFactory _loggerFactory;
#pragma warning restore CS0649 // Field 'PRSappContext._loggerFactory' is never assigned to, and will always have its default value null
        //private static readonly ILoggerFactory _loggerFactory
        //    = new LoggerFactory().AddConsole((s, l) => l == LogLevel.Information && !s.EndsWith("Connection"));

        public DbSet<User> Users { get; set; } //<User> the entity can be queried via LINQ,

        //the 's on end of Users names the Tables
        public DbSet<Title> Titles { get; set; }

        public DbSet<PlayList> PlayLists { get; set; } //
        public DbSet<PlayListItem> PlayListItems { get; set; } //

        public DbQuery<PlayListAndItem> PlayListAndItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite("Data Source=PRSapp.db")
                .UseLoggerFactory(_loggerFactory);
        }

        #region Configuration

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Query<PlayListAndItem>().ToView("View_PlayListAndItems") ////
                .Property(v => v.PlayListName).HasColumnName("Name"); ////
        }
        #endregion
    }

    #region Entities
    public class User //Entity-> Table
    {
        public int UserId { get; set; } //Q>how Does EF Core know this is P-Key AutoIncrement Column?
        public string UserLogin { get; set; } //Test was UserLoginName
        public string UserPwd { get; set; } //Test was UserName

        //Q>Referencing tables using a Collection List is collection Generic<T>. Why?
        //A>Because one-to-many 
        public List<Title> Titles { get; set; } //Navigation property- in <ListT> Lists
        //depicts this is a dependency property (-Many) plural

        public override string ToString()
        {
            ////return "Title: " +  TitleName + "Raw Content: " + TtsRaw;
            return UserId + " " + UserLogin + " ";
        }
        //TODO: ARS-test tasklist 
    }

    public class Title
    {
        public int TitleId { get; set; }
        public string TitleName { get; set; }
        public string TtsRaw { get; set; }
        public string DirPath { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } //Navigation property- depicts this is priciple (1to) property

        public override string ToString()
        {          
            return UserId + TitleId + TitleName;// + "- " + TtsRaw;
        }
    }

    public class PlayList
    {
        public int PlayListId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Uses { get; set; }
        public int Repeats { get; set; } //0 no repeat, 1-n repeats times, -1 or 1000 Continuous Repeat
        public bool ShuffleIsOn { get; set; }
        public ICollection<PlayListItem> PlayListItems { get; set; }
    }

    public class PlayListItem
    {
        public int PlayListItemId { get; set; }
        public int ItemTitleId { get; set; }
        public string ItemTitleName { get; set; }
        public int Priority { get; set; } //0 Highest (Favorite or Important) - Multi-Cycle and/or Multi Daily,
                                          //1 High - Multi Daily, 2 Medium - Multi Weekly, 3 Low - Once Weekly,
                                          //4 Once Monthly, 5 Once Quarterly, 6 Once Semi Annually
        public int PlayPositions { get; set; } //plural becuase lie a favorite or important to learn
                                               //may play in more than one position in a PlayList
        public int PlayListId { get; set; }
    }
    #endregion

    #region QueryType
    public class PlayListAndItem
    {
        public string PlayListName { get; set; }
        public string ItemTitleName { get; set; }
    }
    #endregion
}