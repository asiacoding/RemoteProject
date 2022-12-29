using Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Standard.Set
{
    public class RemotesButton
    {
        public  bool Add(RemoteButtonModels remote)
        {
            try
            {
                return MainSqlite.DataBase.Insert(remote) == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}