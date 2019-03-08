using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRSapp.Classes
{
    public class Title
    {
        //[SQLite.PrimaryKey]
        public string Name { get; set; }

        public string PLName { get; set; }

        public string Description { get; set; }

        public string PlayPriority { get; set; }

        public int PlayPosition { get; set; }

        public DateTime PlayTime { get; set; }
    }
}
