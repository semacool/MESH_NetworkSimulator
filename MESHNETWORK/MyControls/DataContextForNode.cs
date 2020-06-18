using MESHNETWORK.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESHNETWORK.MyControls
{
    class DataContextForNode
    {
        public Config Config { get; set; }
        public KnotSave Ks { get; set; }

        public DataContextForNode(KnotSave Ks) 
        {
            Config = Logic.Config;
            this.Ks = Ks;
        }
    }
}
