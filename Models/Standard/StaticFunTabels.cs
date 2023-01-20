using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Base
{
    public class StaticFunTabels
    {
        public StaticFunTabels()
        {
            if (DataTime == null)
                this.DataTime = DateTime.Now;
        }

        [SQLite.AutoIncrement]
        [SQLite.PrimaryKey]
        public int Id { set; get; } // Def Key Sqlite only no using in App Now
        public DateTime? DataTime { set; get; } = null;

        /// <summary>
        /// In Base 
        /// <para> Add in project only is Key </para>
        /// </summary>
        public string Guid { set; get; }

    }
}
