using System;
using System.Collections.Generic;
using System.Linq;
using GG.CoreEngine;

namespace GG.Engine.Cli
{
    internal class TestCommand : ICommand
    {
        /// <summary>
        ///   初始化 <see cref="T:System.Object" /> 类的新实例。
        /// </summary>
        public TestCommand(string v)
        {
            V = v;
        }

        public void Execute(CoreEngine.Engine engine)
        {
            Console.WriteLine("TestCommand:" + V);
        }

        public string V { get; private set; }

        public override string ToString()
        {
            return V;
        }
    }
}