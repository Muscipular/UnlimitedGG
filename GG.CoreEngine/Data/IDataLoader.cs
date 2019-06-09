using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GG.CoreEngine.Data
{
    public interface IDataLoader
    {
        Stream Load(string path);
    }
}