using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Base
{
    public class LanguageModel : StaticFunTabels
    {
        public string Name { set; get; }
        public bool IsEnable { set; get; }
    }
}
