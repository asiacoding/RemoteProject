using Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.Standard.Get
{
    public class RemotesButton
    {
        public List<RemoteButtonModels> GetALI()
        {

         
            if (MainSqlite.DataBase == null)
            {
                return new List<RemoteButtonModels>();
            }

            return MainSqlite.DataBase.Table<RemoteButtonModels>().ToList();
        }
        public List<RemoteButtonModels> GetByProject(string Guid)
        {
            try
            {
                if (MainSqlite.DataBase == null)
                {
                    return new List<RemoteButtonModels>();
                }

                return MainSqlite.DataBase.Query<RemoteButtonModels>("select * from RemoteButtonModels where Guid = @p0", Guid).ToList();
            }
            catch (Exception)
            {
                return new List<RemoteButtonModels>();
            }

        }
    }
}
