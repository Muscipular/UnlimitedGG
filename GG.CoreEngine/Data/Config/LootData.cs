using System;
using System.Collections.Generic;
using System.Linq;

namespace GG.CoreEngine.Data.Config
{
    public class LootData
    {
        public int Gold { get; set; }

        public int Exp { get; set; }

        public LootItem[] Item { get; set; }
    }
}