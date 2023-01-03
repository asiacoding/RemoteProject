using System;
using System.Collections.Generic;
using System.Text;
namespace Models.Base
{
    public class RemoteProjectModels : StaticFunTabels
    {
        public string Guid { set; get; }
        public string Description { set; get; }
        public string Name { set; get; }
    }
}