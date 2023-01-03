using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Base
{
    public class RemoteButtonModels : StaticFunTabels
    {
        public string ModelRemote { set; get; }
        public string Codes { set; get; } // add Hex Code or  Binter
        public string Guid { set; get; } //Add in project only is Key
        public string Index { set; get; }
        public string Name { set; get; } // Name Button or ImageButton 
    }
}
