// csharptermproject
// text-editor, unified, extensible
// author: mert akengin
// team members: omar albeik, zafer huzmeli
// created: 2016 march 3

using System;
using Gtk;

using FastColoredTextBoxNS;
using IniParser;

public partial class MainWindow: Gtk.Window
{
	IniParser.Model.IniData settings;
	protected void loadSettings()
	{
		settings = new IniParser.Model.IniData ();
		settings.Sections.AddSection ("ui");
		settings ["ui"].AddKey ("font");
		settings ["ui"].AddKey ("color");
		settings ["ui"].AddKey ("background");
		settings ["ui"] ["font"] = "monospace 12";
		settings ["ui"] ["color"] = "black";
		settings ["ui"] ["background"] = "white";
		IniParser.Model.IniData _set = new FileIniDataParser ().ReadFile ("settings.ini");
		if(_set != null)
			settings.Merge (_set);
		return;
	}
	protected void saveSettings()
	{
		if (settings == null)
			return;
		new FileIniDataParser ().WriteFile ("settings.ini", settings);
	}
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		this.SetIconFromFile ("icon.png");
		System.IO.File.AppendAllText ("settings.ini", "");
		loadSettings ();
		Build ();
		notebook.Scrollable = true;
		notebook.EnablePopup = true;
		//notebook.HomogeneousTabs = true;
		newTab ("hello world", "welcome to utxl!\n");
		return;
	}
	protected bool test()
	{
		return false;
	}
	protected void OnDeleteEvent (object sender, EventArgs a)
	{
		while (notebook.NPages > 0)
			closeDoc (null, null);
		Application.Quit ();
		//a.RetVal = true;
		return;
	}
	protected void newTab(string label, string contents = null)
	{
		ScrolledWindow w = new ScrolledWindow ();
		TextView t = new TextView ();
		t.LeftMargin = t.RightMargin = 5;
		t.PixelsAboveLines = 3;
		t.WrapMode = WrapMode.WordChar;
		t.ModifyFont (Pango.FontDescription.FromString (settings["ui"]["font"]));
		t.Buffer.Text = contents;
		Label l = new Label (label);
		w.Add (t);
		notebook.AppendPage (w,l);
		notebook.SetTabReorderable (notebook.GetNthPage(notebook.NPages-1), true);
		notebook.ShowAll ();
		return;
	}
	protected void closeTab(int num)
	{
		notebook.RemovePage (num);
		return;
	}
	protected void newDoc (object sender, EventArgs e)
	{
		newTab ("new document");
		return;
	}
	protected void openDoc (object sender, EventArgs e)
	{
		FileChooserDialog d = new FileChooserDialog (
								  "OPEN STUFF", this, FileChooserAction.Open,
			                      "OPEN!", ResponseType.Accept,
			                      "NOPE", ResponseType.Cancel
		                      );
		if ((ResponseType)d.Run () == ResponseType.Accept)
			newTab (System.IO.Path.GetFileName (d.Filename),
				System.IO.File.ReadAllText (d.Filename));
		//((TextView)notebook.Children [notebook.Page]).Buffer.Text = 
		d.Destroy ();
		return;
	}
	protected void saveDoc (object sender, EventArgs e)
	{
		FileChooserDialog d = new FileChooserDialog (
			                      "SAVE MEE!", this, FileChooserAction.Save,
			                      "SAVE!", ResponseType.Accept,
			                      "NOPE", ResponseType.Cancel
		                      );
		if ((ResponseType)d.Run () == ResponseType.Accept) {
			System.IO.File.WriteAllText (d.Filename,
				((TextView)((ScrolledWindow)notebook.GetNthPage (notebook.Page)).Child).Buffer.Text);
			//((TextView)notebook.Children [notebook.Page]).Buffer.Text
			notebook.SetTabLabelText (notebook.GetNthPage (notebook.Page),
				System.IO.Path.GetFileName (d.Filename));
		}
		d.Destroy ();
		return;
	}
	protected void printDoc (object sender, EventArgs e)
	{
		return;
	}
	protected void closeDoc (object sender, EventArgs e)
	{
		if (notebook.NPages < 1)
			return;
		//if (((TextView)notebook.Children [notebook.Page]).Buffer.Text.Length > 0) {
		if (((TextView)((ScrolledWindow)notebook.GetNthPage(notebook.Page)).Child).Buffer.Text.Length > 0) {
			MessageDialog d = new MessageDialog (this, DialogFlags.Modal, 
				MessageType.Question, ButtonsType.YesNo, "Changes not saved! Want to save?");
			ResponseType r = (ResponseType) d.Run ();
			if (r == ResponseType.Yes)
				saveDoc (null, null);
			d.Destroy ();
			if (r != ResponseType.No)
				return;
		}
		closeTab (notebook.Page);
		return;
	}
	protected void changeFont (object sender, EventArgs e)
	{
		FontSelectionDialog d = new FontSelectionDialog ("FONT!");
		d.SetFontName (settings ["ui"] ["font"]);
		if ((ResponseType) d.Run () == ResponseType.Ok) {
			for (int i = 0; i < notebook.NPages; i++)
				((TextView)((ScrolledWindow)notebook.GetNthPage (i)).Child).ModifyFont (Pango.FontDescription.FromString(d.FontName));
		}
		settings ["ui"] ["font"] = d.FontName;
		d.Destroy ();
		saveSettings ();
		return;
	}
	protected void aboutDialog(object sender, EventArgs e)
	{
		AboutDialog d = new AboutDialog ();
		d.Authors = new string [] {
			"mert akengin",
			"omar albeik",
			"zafer huzmeli"
		};
		d.ProgramName = "Unified Text Editor Lite";
		d.Version = UTXL.MainClass.verstr;
		d.WindowPosition = WindowPosition.Mouse;
		if(System.IO.File.Exists("LICENSE.md"))
			d.License = System.IO.File.ReadAllText ("LICENSE.md");
		if(System.IO.File.Exists("COPYING.md"))
			d.Comments = System.IO.File.ReadAllText("COPYING.md");
		d.Run ();
		d.Destroy ();
		return;
	}
}
