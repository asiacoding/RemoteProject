using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BlueApp1
{
    public class CoustomButton : Button
    {
        public string Code { set; get; }
        public bool ReadMethod { set; get; }
        public bool WriteMethod { set; get; } = true;
    }
}
