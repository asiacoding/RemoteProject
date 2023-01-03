using Models.Base;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Models.Standard
{
    public static class MainSqlite
    {

        public static SQLiteConnection DataBase
        {
            get
            {
                if (_DataBase != null) { return _DataBase; }

                _DataBase = GetMainFileDatabase();
                
                return _DataBase;
            }
        }

        private static SQLite.SQLiteConnection _DataBase { set; get; }
        private static SQLite.SQLiteConnection GetMainFileDatabase()
        {
            string applicationFolderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "DataRemotely");
            _ = System.IO.Directory.CreateDirectory(applicationFolderPath);
            string databaseFileName = Path.Combine(applicationFolderPath, "Main.AsiaFile");
            var _API = new SQLiteConnection(databaseFileName, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite);
            LoadModels(_API);
            return _API;
        }

        //Add Here new Models ❕❕
        private static void LoadModels(SQLiteConnection Sql)
        {
            _ = Sql.CreateTable<RemoteButtonModels>();
            _ = Sql.CreateTable<RemoteProjectModels>();
            _ = Sql.CreateTable<LanguageModel>();
            _ = Sql.CreateTable<ChannelModels>();
        }
    }
}
