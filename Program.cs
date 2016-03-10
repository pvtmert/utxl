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
			Gtk.Settings.Default.SetLongProperty ("gtk-menu-images", 1, "");
			Gtk.Settings.Default.SetLongProperty ("gtk-button-images", 1, "");
			Gtk.Settings.Default.SetLongProperty ("gtk-application-prefer-dark-theme", 1, "");
			Gtk.Settings.Default.SetStringProperty ("gtk-icon-theme-name", "Tango", "");
			Gtk.Settings.Default.SetStringProperty ("gtk-toolbar-style", "GTK_TOOLBAR_ICONS", "");
			main win = new main ();
			win.Show ();
			Application.Run ();
		}
	}
}
