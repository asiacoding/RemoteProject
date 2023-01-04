using Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.Standard.Get
{
    public class Channel
    {
        public List<ChannelModels> GetAll()
        {
            try
            {

                if (MainSqlite.DataBase == null)
                {
                    return new List<ChannelModels>();
                }

                return MainSqlite.DataBase.Table<ChannelModels>().ToList();
            }
            catch (Exception)
            {
                return new List<ChannelModels>();
            }
        }

        public List<ChannelModels> Find(ChannelModels channel, params InterFaceing.TypesFindChaneelsModels[] Filter)
        {
            try
            {
                var GetChanel = new Channel();
                var OutputList = new List<ChannelModels>();
                var AllObject = GetChanel.GetAll();

                foreach (var item in Filter)
                {
                    if (item == InterFaceing.TypesFindChaneelsModels.Class) { OutputList.AddRange(AllObject.Where(a => a.Class == channel.Class).ToList()); }
                    else if (item == InterFaceing.TypesFindChaneelsModels.Codes) { OutputList.AddRange(AllObject.Where(a => a.Codes == channel.Codes).ToList()); }
                    else if (item == InterFaceing.TypesFindChaneelsModels.Image) { OutputList.AddRange(AllObject.Where(a => a.Image == channel.Image).ToList()); }
                    else if (item == InterFaceing.TypesFindChaneelsModels.Name) { OutputList.AddRange(AllObject.Where(a => a.Name == channel.Name).ToList()); }
                    else if (item == InterFaceing.TypesFindChaneelsModels.Pin) { OutputList.AddRange(AllObject.Where(a => a.Pin == channel.Pin).ToList()); }
                }

                return OutputList;
            }
            catch (Exception)
            {
                return null;
            }
        }





    }
}
