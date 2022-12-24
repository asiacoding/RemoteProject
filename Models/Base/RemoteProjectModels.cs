using System;
using System.Collections.Generic;
using System.Text;
namespace Models.Base
{
    public class RemoteProjectModels
    {
        [SQLite.AutoIncrement]
        [SQLite.PrimaryKey]
        public int Id { set; get; }
        public string Guid { set; get; }
        public string Description { set; get; }
        public string Name { set; get; }
        public DateTime DataTime { set; get; }
    }
}