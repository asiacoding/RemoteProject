using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Base
{
    public class LanguageModel
    {
        [SQLite.AutoIncrement]
        [SQLite.PrimaryKey]
        public int Id { set; get; }
        public string Name { set; get; }
        public bool IsEnable { set; get; }
    }
}
