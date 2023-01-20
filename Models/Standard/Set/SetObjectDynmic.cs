using Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Standard.Set
{
    public static class AddModel<T>
    {
        public static bool Add( T remote)
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

        public static bool Add(List<T> remote)
        {
            try
            {
                return MainSqlite.DataBase.Insert(remote) == remote.Count;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}