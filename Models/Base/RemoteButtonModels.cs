using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Base
{
    public class RemoteButtonModels
    {
        [SQLite.AutoIncrement]
        [SQLite.PrimaryKey]
        public int ID { set; get; } // Def Key Sqlite only no using in App Now
        public string ModelRemote { set; get; } 
        public string Codes { set; get; } // add Hex Code or  Binter
        public string Guid { set; get; } //Add in project only is Key
        public string Index { set; get; }
        public string Name { set; get; } // Name Button or ImageButton 
    }
}
