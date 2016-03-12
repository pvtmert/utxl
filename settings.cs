using System;
using IniParser;

namespace UTXL
{
	public class settings
	{
		private string _sfilename = "settings.ini";
		private IniParser.Model.IniData data;
		public settings ()
		{
			data = new IniParser.Model.IniData ();
			sections ();
			defaults ();
			return;
		}
		private void sections()
		{
			if (data == null)
				return;
			data.Sections.AddSection ("ui");
			data ["ui"].AddKey ("font");
			data ["ui"].AddKey ("color");
			data ["ui"].AddKey ("background");
			data ["ui"].AddKey ("W");
			data ["ui"].AddKey ("H");
			data ["ui"].AddKey ("tab");
			data ["ui"].AddKey ("wrap");
			data ["ui"].AddKey ("icon_size");
			data ["ui"].AddKey ("icon_text");
			data ["ui"].AddKey ("treew");
			return;
		}
		public void defaults()
		{
			if (data == null)
				return;
			data ["ui"] ["font"] = "Courier 11";
			data ["ui"] ["color"] = "black";
			data ["ui"] ["background"] = "white";
			data ["ui"] ["W"] = "800";
			data ["ui"] ["H"] = "600";
			data ["ui"] ["tab"] = "true";
			data ["ui"] ["wrap"] = "3";
			data ["ui"] ["icon_size"] = "0"; //5
			data ["ui"] ["icon_text"] = "0"; //7
			data ["ui"] ["treew"] = "150";
			return;
		}
		public void load()
		{
			IniParser.Model.IniData _set = new FileIniDataParser ().ReadFile (_sfilename);
			if(_set != null)
				data.Merge (_set);
			return;
		}
		public void save()
		{
			if (data == null)
				return;
			new FileIniDataParser ().WriteFile (_sfilename, data);
			return;
		}
		public string font {
			get { return data ["ui"] ["font"]; }
			set { data ["ui"] ["font"] = value; }
		}
		public string color {
			get { return data ["ui"] ["color"]; }
			set { data ["ui"] ["color"] = value; }
		}
		public string bg {
			get { return data ["ui"] ["background"]; }
			set { data ["ui"] ["background"] = value; }
		}
		public int width {
			get { return int.Parse(data ["ui"] ["W"]); }
			set { data ["ui"] ["W"] = value.ToString(); }
		}
		public int height {
			get { return int.Parse(data ["ui"] ["H"]); }
			set { data ["ui"] ["H"] = value.ToString(); }
		}
		public bool tab {
			get { return bool.Parse(data ["ui"] ["tab"]); }
			set { data ["ui"] ["tab"] = value.ToString(); }
		}
		public char wrap {
			get { return char.Parse(data ["ui"] ["wrap"]); }
			set { data ["ui"] ["wrap"] = value.ToString(); }
		}
		public int icon_size {
			get { return int.Parse(data ["ui"] ["icon_size"]); }
			set { data ["ui"] ["icon_size"] = value.ToString(); }
		}
		public int icon_text {
			get { return int.Parse(data ["ui"] ["icon_text"]); }
			set { data ["ui"] ["icon_text"] = value.ToString(); }
		}
		public int treew {
			get { return int.Parse (data ["ui"] ["treew"]); }
			set { data ["ui"] ["treew"] = value.ToString (); }
		}
	}
}

