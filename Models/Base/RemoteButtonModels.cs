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
        public string ID { set; get; }
        public string ModelRemote { set; get; }
        public string Codes { set; get; }
        public string Guid { set; get; }
        public string Index { set; get; }
        public string Name { set; get; }
    }
}
