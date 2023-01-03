using Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Standard.Delete
{
    public class RemotesButton
    {
        public bool DeleteAll(string EnterPassword)
        {
            //List<RemoteButtonModels>
            try
            {
                if(EnterPassword != "1234")
                {
                    return false;
                }

                if (MainSqlite.DataBase == null)
                {
                    return false;
                }
                var Count = MainSqlite.DataBase.Table<RemoteButtonModels>().ToList().Count;
                var User = MainSqlite.DataBase.DeleteAll<RemoteButtonModels>();
                return Count == User;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteAll(string EnterPassword,string GuidProject)
        {
            try
            {
                if (EnterPassword != "1234")
                {
                    return false;
                }

                if (string.IsNullOrEmpty(GuidProject))
                {
                    return false; 
                }

                if (MainSqlite.DataBase == null)
                {
                    return false;
                }

                string qerys = "DELETE FROM [RemoteButtonModels] WHERE Guid='" + GuidProject + "';";
              
                MainSqlite.DataBase.Query<RemoteButtonModels>(qerys);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
