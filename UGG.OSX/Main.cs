#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;

using AppKit;
using Foundation;
#endregion

namespace UGG.OSX.MacOS
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main(string[] args)
		{
			NSApplication.Init ();

			using (var game = new GoodGameCore()) {
            	game.Run ();
			}
		}
	}
}
