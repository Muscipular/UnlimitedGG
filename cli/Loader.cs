using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GG.CoreEngine.Data;

namespace GG.Engine.Cli
{
    class Loader : IDataLoader
    {
        private static readonly string[] ResourceNames = typeof(Loader).Assembly.GetManifestResourceNames();

        public (Stream stream, bool shouldRelease) Load(string path)
        {
            var name = ResourceNames.FirstOrDefault(e => e.EndsWith($"Data.{path}.json"));
            return (typeof(Loader).Assembly.GetManifestResourceStream(name), true);
        }
    }
}