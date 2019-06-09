using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GG.CoreEngine.Data;

namespace GG.Engine.Cli
{
    class Loader : IDataLoader
    {
        public Stream Load(string path)
        {
            return new MemoryStream(File.ReadAllBytes($"Data/{path}.json"));
        }
    }
}