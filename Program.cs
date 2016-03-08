using System;
using Gtk;

namespace UTXL
{
	class MainClass
	{
		public static string verstr;
		public static void Main (string[] args)
		{
			verstr = "";
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}
