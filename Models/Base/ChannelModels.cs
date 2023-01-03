using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Base
{
    //This prived App
    public class ChannelModels : StaticFunTabels
    {
        public string Codes { set; get; }
        public string Name { set; get; }
        public int Pin { set; get; } // ترتيب حساب الاشيء الاهمية
    }
}
