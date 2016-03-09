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
			main win = new main ();
			win.Show ();
			Application.Run ();
		}
	}
}
