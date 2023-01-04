using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Base
{
    //This prived App
    public class ChannelModels : StaticFunTabels
    {
        public string Codes { set; get; } // رقم القناة
        public string Name { set; get; } //اسم القناة
        public int Pin { set; get; } // ترتيب حساب الاشيء الاهمية
        public string Class { set; get; } // فئة القناة
        public string Image { set; get; } //صورة القناة مشفر stringbase64
    }
}
