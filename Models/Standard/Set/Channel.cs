using Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Standard.Set
{
    public class Channel
    {
        public bool Add(ChannelModels remote)
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
