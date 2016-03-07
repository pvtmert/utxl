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
		while (0 != notebook.Page)
			closeDoc (null, null);
		Application.Quit ();
		//a.RetVal = true;
		return;
	}
	protected void newTab(string label, string contents = null)
	{
		TextView t = new TextView ();
		t.LeftMargin = t.RightMargin = 5;
		t.PixelsAboveLines = 3;
		t.WrapMode = WrapMode.Word;
		t.ModifyFont (Pango.FontDescription.FromString (settings["ui"]["font"]));
		t.Buffer.Text = contents;
		Label l = new Label (label);
		notebook.AppendPage (t,l);
		notebook.SetTabReorderable (this, true);
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
				((TextView)notebook.GetNthPage (notebook.Page)).Buffer.Text);
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
		if (((TextView)notebook.GetNthPage(notebook.Page)).Buffer.Text.Length > 0) {
			MessageDialog d = new MessageDialog (this, DialogFlags.Modal, 
				MessageType.Question, ButtonsType.YesNo, "Changes not saved! Want to save?");
			ResponseType r = (ResponseType) d.Run ();
			if (r == ResponseType.Yes)
				saveDoc (null, null);
			//else if (r == ResponseType.No)
			//	closeTab (notebook.Page);
			d.Destroy ();
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
				((TextView)notebook.GetNthPage (i)).ModifyFont (Pango.FontDescription.FromString(d.FontName));
		}
		settings ["ui"] ["font"] = d.FontName;
		d.Destroy ();
		saveSettings ();
		return;
	}
}
