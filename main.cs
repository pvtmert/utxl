// csharptermproject
// text-editor, unified, extensible
// author: mert akengin
// team members: omar albeik, zafer huzmeli
// created: 2016 march 3

using System;
using Gtk;

using FastColoredTextBoxNS;
using Alpinechough.Common.GtkUtilities;

using UTXL;

public partial class main: Gtk.Window
{
	private settings settings;
	private void threadAdapter(object dir) {
		if (dir == null)
			dir = ".";
		populateTree ((TreeStore)tree.Model, (string)dir, TreeIter.Zero);
		tree.Show ();
		return;
	}
	private void defs(object o, EventArgs a)
	{
		((VPaned)o).Position = -1;
		return;
	}
	public main () : base (Gtk.WindowType.Toplevel)
	{
		settings = new settings ();
		this.SetIconFromFile ("icon.png");
		SetDefaultIconFromFile ("icon.png");
		System.IO.File.AppendAllText ("settings.ini", "");
		settings.load ();
		Build ();
		this.Resize (settings.width, settings.height);
		this.Show ();
		hpaned1.Position = settings.treew;
		hpaned1.BorderWidth = 3;
		hpaned1.Show ();
		notebook.Scrollable = true;
		notebook.EnablePopup = true;
		//notebook.HomogeneousTabs = true;
		newTab ("hello world", "welcome to utxl!\n",System.IO.Directory.GetCurrentDirectory()
			+System.IO.Path.DirectorySeparatorChar
			+"utxl.txt"
		);
		tree.EnableTreeLines = true;
		tree.HeadersVisible = false;
		tree.AppendColumn ("files & dirs", new CellRendererText (), "text", 0);
		tree.ModifyFont (Pango.FontDescription.FromString (settings.font));
		TreeStore t = new TreeStore (typeof(string),typeof(string));
		tree.Model = t;
		try {
			new System.Threading.Thread (threadAdapter)
				.Start (System.IO.Directory.GetCurrentDirectory ());
		} catch(Exception e) {
			Console.WriteLine (e.Message);
		}
		return;
	}
	protected bool test()
	{
		return false;
	}
	protected string text(Notebook n, int page)
	{
		return null;
	}
	protected void newTab(string label, string contents = null, string path = "/")
	{
		ScrolledWindow w = new ScrolledWindow ();
		TextView t = new TextView ();
		t.LeftMargin = t.RightMargin = 5;
		t.PixelsAboveLines = 3;
		t.WrapMode = WrapMode.WordChar;
		t.ModifyFont (Pango.FontDescription.FromString (settings.font));
		t.Buffer.Text = contents;
		//Label l = new Label (label);
		Node ll = new Node (t.Buffer.Text);
		NotebookTabLabel l = new NotebookTabLabel(label,path,ll);
		t.Buffer.Changed += delegate(object sender, EventArgs e) {
			l.ptr.add(new Node(t.Buffer.Text.ToString()));
			l.ptr = l.ptr.next;
			return;
		};
		w.Add (t);
		notebook.AppendPageMenu (w,l,new Label(label));
		notebook.SetTabReorderable (notebook.GetNthPage (notebook.NPages - 1), true);
		notebook.SetTabDetachable (notebook.GetNthPage (notebook.NPages - 1), true);
		l.CloseClicked += delegate(object obj, EventArgs eventArgs) {
			//closeTab (notebook.PageNum(w));
			for(int i=notebook.Page;i>notebook.PageNum(w);i--)
				notebook.PrevPage();
			for(int i=notebook.Page;i<notebook.PageNum(w);i++)
				notebook.NextPage();
			closeDoc(null,null);
		};
		notebook.ShowAll ();
		for (int i = notebook.Page; i < notebook.NPages; i++)
			notebook.NextPage ();
		return;
	}
	protected void closeTab(int num)
	{
		notebook.RemovePage (num);
		notebook.PrevPage ();
		notebook.ShowAll ();
		return;
	}
	protected void newDoc (object o, EventArgs e)
	{
		newTab ("new document",null,System.IO.Directory.GetCurrentDirectory()
			+System.IO.Path.DirectorySeparatorChar
			+"new.txt"
		);
		return;
	}
	protected void openDoc (object o, EventArgs e)
	{
		FileChooserDialog d = new FileChooserDialog (
			"OPEN STUFF", this, FileChooserAction.SelectFolder,
			"OPEN!", ResponseType.Accept,
			"NOPE", ResponseType.Cancel
		);
		if ((ResponseType)d.Run () == ResponseType.Accept)
			//newTab (System.IO.Path.GetFileName (d.Filename),
			//	System.IO.File.ReadAllText (d.Filename));
		//((TextView)notebook.Children [notebook.Page]).Buffer.Text = 
		try {
			new System.Threading.Thread (threadAdapter)
				.Start ( /*System.IO.Path.GetDirectoryName*/ (
					System.IO.Path.GetFullPath (d.Filename)));
		} catch(Exception x) {
			Console.WriteLine (x.Message);
		}
		d.Destroy ();
		return;
	}
	protected void saveDoc (object o, EventArgs e)
	{
		FileChooserDialog d = new FileChooserDialog (
			                      "SAVE MEE!", this, FileChooserAction.Save,
			                      "SAVE!", ResponseType.Accept,
			                      "NOPE", ResponseType.Cancel
		                      );
		d.SetFilename(((NotebookTabLabel)notebook.GetTabLabel (notebook.GetNthPage (notebook.Page))).Pth);
		if ((ResponseType)d.Run () == ResponseType.Accept) {
			if (System.IO.File.Exists (d.Filename)) {
				MessageDialog d2 = new MessageDialog (this, DialogFlags.Modal, 
					                   MessageType.Question, ButtonsType.YesNo, "File Exists! Overwrite?");
				if ((ResponseType)d2.Run () != ResponseType.Yes) {
					d2.Destroy ();
					d.Destroy ();
					return;
				}
				d2.Destroy ();
			}
			System.IO.File.WriteAllText (d.Filename,
				((TextView)((ScrolledWindow)notebook.GetNthPage (notebook.Page)).Child).Buffer.Text);
			//((TextView)notebook.Children [notebook.Page]).Buffer.Text
			notebook.SetTabLabel (notebook.GetNthPage (notebook.Page),
				new NotebookTabLabel (System.IO.Path.GetFileName (d.Filename), d.Filename));
			notebook.SetMenuLabel (notebook.GetNthPage (notebook.Page),
				new Label (System.IO.Path.GetFileName (d.Filename)));
			int p = notebook.Page;
			((NotebookTabLabel)notebook.GetTabLabel(notebook.GetNthPage(notebook.Page))).CloseClicked += delegate(object obj, EventArgs eventArgs) {
				//closeTab (notebook.PageNum(w));
				for(int i=notebook.Page;i>p;i--)
					notebook.PrevPage();
				for(int i=notebook.Page;i<p;i++)
					notebook.NextPage();
				closeDoc(null,null);
			};
		}
		d.Destroy ();
		return;
	}
	protected void printDoc (object o, EventArgs e)
	{
		return;
	}
	protected void closeDoc (object o, EventArgs e)
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
		notebook.ShowAll ();
		return;
	}
	protected void changeFont (object o, EventArgs e)
	{
		FontSelectionDialog d = new FontSelectionDialog ("FONT!");
		d.SetFontName (settings.font);
		if ((ResponseType) d.Run () == ResponseType.Ok) {
			for (int i = 0; i < notebook.NPages; i++)
				((TextView)((ScrolledWindow)notebook.GetNthPage (i)).Child).ModifyFont (Pango.FontDescription.FromString(d.FontName));
		}
		settings.font = d.FontName;
		d.Destroy ();
		settings.save ();
		tree.ModifyFont (Pango.FontDescription.FromString (settings.font));
		return;
	}
	protected void aboutDialog(object o, EventArgs e)
	{
		AboutDialog d = new AboutDialog ();
		d.WrapLicense = true;
		d.Website = "http://github.com/pvtmert/utxl";
		d.WebsiteLabel = "UTXL @GitHub";
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
	private void populateTree(TreeStore t, string root, TreeIter parent) 
	{
		try {
			TreeIter p;
			if (parent.Equals(TreeIter.Zero))
				p = t.AppendValues( new string [] { System.IO.Path.GetFileName(root)+"/", System.IO.Path.GetFullPath(root), } );
			else
				p = t.AppendValues(parent, new string [] { System.IO.Path.GetFileName(root)+"/", System.IO.Path.GetFullPath(root), } );
			tree.ExpandToPath(t.GetPath(p));
			foreach (string d in System.IO.Directory.GetDirectories(root)) {
				if (parent.Equals(TreeIter.Zero))
					this.populateTree (t,d,p);
				continue;
			}
			foreach (string f in System.IO.Directory.GetFiles(root,"*")) {
				t.AppendValues(p, new string [] { System.IO.Path.GetFileName(f), System.IO.Path.GetFullPath(f), } );
				continue;
			}
		} catch(Exception e) {
			Console.WriteLine (e.Message);
		}
		return;
	}

	protected void treeOpen (object o, RowActivatedArgs args)
	{
		TreeIter i;
		//tree.ExpandToPath (args.Path);
		if (tree.GetRowExpanded (args.Path))
			tree.CollapseRow (args.Path);
		else
			tree.ExpandRow (args.Path, true);
		((TreeStore)tree.Model).GetIter (out i, args.Path);
		for(int j=0;j<notebook.NPages;j++)
			if(((NotebookTabLabel)notebook.GetTabLabel(notebook.GetNthPage(j))).Pth == (string)((TreeStore)tree.Model).GetValue (i, 1))
			{
				for(int k=notebook.Page;k>j;k--)
					notebook.PrevPage();
				for(int k=notebook.Page;k<j;k++)
					notebook.NextPage();
				return;
			}
		if (System.IO.Directory.Exists ((string)((TreeStore)tree.Model).GetValue (i, 1)))
			//if (tree.GetRowExpanded (args.Path))
				foreach (string d in System.IO.Directory.GetDirectories((string)((TreeStore)tree.Model).GetValue (i, 1)))
					populateTree ((TreeStore)tree.Model, System.IO.Path.GetFullPath (d), i);
			//else ((TreeStore)tree.Model).Remove (ref i);
		else
			newTab ((string)((TreeStore)tree.Model).GetValue (i, 0),
				System.IO.File.ReadAllText ((string)(
					(TreeStore)tree.Model).GetValue (i, 1)),
				(string)((TreeStore)tree.Model).GetValue (i, 1));
		return;
	}

	protected bool treeSearch(TreeStore t, string fp)
	{
		if (t == null)
			return false;
		t.Foreach(new TreeModelForeachFunc(delegate(TreeModel m, TreePath p, TreeIter i) {
			t.GetIter (out i, p);
			if((string)m.GetValue(i,1) == fp)
				return true;
			return false;
		}));
		return false;
	}
	protected void treeDel (object o, EventArgs a)
	{
		TreeIter i;
		TreeSelection s = tree.Selection;
		s.GetSelected (out i);
		((TreeStore)tree.Model).Remove (ref i);
		return;
	}

	protected void QUIT(object o, EventArgs a)
	{
		while (notebook.NPages > 0)
			closeDoc (null, null);
		for (int i = 0; i < notebook.NPages; i++) {
			notebook.NextPage ();
			while (notebook.Page > 0)
				notebook.PrevPage ();
			closeDoc(null, null);
			notebook.Show ();
		}
		//if (notebook.NPages > 0) throw new InvalidOperationException();
		settings.treew = hpaned1.Position;
		if(settings != null)
			settings.save ();
		Destroy ();
		Application.Quit ();
		return;
	}
	protected void winResize (object o, SizeRequestedArgs a)
	{
		int x, y;
		this.GetSize (out x, out y);
		settings.width = x;
		settings.height = y;
		return;
	}
	protected void OnDeleteEvent(object o, DeleteEventArgs a)
	{
		QUIT (null,null);
		return;
	}
	protected void OnShown(object o, EventArgs a)
	{
		return;
	}
	protected void OnFocused(object o, EventArgs a)
	{
		return;
	}
	protected void OnHidden(object o, EventArgs a)
	{
		return;
	}
	protected void OnStateChanged(object o, EventArgs a)
	{
		return;
	}
	protected void OnDestroyEvent(object o, DestroyEventArgs a)
	{
		return;
	}
	protected void OnFocusOut (object o, FocusOutEventArgs a)
	{
		return;
	}
	protected void OnFocusIn (object o, FocusInEventArgs a)
	{
		return;
	}
	protected void OnWindowStateChanged (object o, WindowStateEventArgs a)
	{
		return;
	}
	protected void OnFocusActivated(object o, EventArgs a)
	{
		return;
	}
	protected void OnToggleHandleFocus (object o, ToggleHandleFocusArgs args)
	{
		if (o == vpaned1 || o == vpaned2)
			((VPaned)o).Position = 32;
		if (o == hpaned1)
			((HPaned)o).Position = 160;
		return;
	}
	protected void OnBtnPressEvent (object o, ButtonPressEventArgs args)
	{
		return;
	}
	protected void OnBtnReleaseEvent (object o, ButtonReleaseEventArgs args)
	{
		return;
	}
	protected void undo (object o, EventArgs e)
	{
		if (((NotebookTabLabel)notebook.GetTabLabel (notebook.GetNthPage (notebook.Page))).ptr.prev != null)
		{
			Node n = ((NotebookTabLabel)notebook.GetTabLabel (notebook.GetNthPage (notebook.Page))).ptr.prev;
			Node c = new Node(
				((NotebookTabLabel)notebook.GetTabLabel (notebook.GetNthPage (notebook.Page))).ptr.data.ToString(),
				((NotebookTabLabel)notebook.GetTabLabel (notebook.GetNthPage (notebook.Page))).ptr.next,
				((NotebookTabLabel)notebook.GetTabLabel (notebook.GetNthPage (notebook.Page))).ptr.prev
			);
			((TextView)((ScrolledWindow)notebook.GetNthPage (notebook.Page)).Child).Buffer.Text =
				((NotebookTabLabel)notebook.GetTabLabel (notebook.GetNthPage (notebook.Page))).ptr.prev.data.ToString();
			((NotebookTabLabel)notebook.GetTabLabel (notebook.GetNthPage (notebook.Page))).ptr = n;
			n.next = c;
			c.prev = n;
		}
		return;
	}
	protected void redo (object o, EventArgs e)
	{
		if (((NotebookTabLabel)notebook.GetTabLabel (notebook.GetNthPage (notebook.Page))).ptr.next != null)
		{
			Node n = ((NotebookTabLabel)notebook.GetTabLabel (notebook.GetNthPage (notebook.Page))).ptr.next;
			Node c = new Node(
				((NotebookTabLabel)notebook.GetTabLabel (notebook.GetNthPage (notebook.Page))).ptr.data.ToString(),
				((NotebookTabLabel)notebook.GetTabLabel (notebook.GetNthPage (notebook.Page))).ptr.next,
				((NotebookTabLabel)notebook.GetTabLabel (notebook.GetNthPage (notebook.Page))).ptr.prev
			);
			((TextView)((ScrolledWindow)notebook.GetNthPage (notebook.Page)).Child).Buffer.Text =
				((NotebookTabLabel)notebook.GetTabLabel (notebook.GetNthPage (notebook.Page))).ptr.next.data.ToString();
			((NotebookTabLabel)notebook.GetTabLabel (notebook.GetNthPage (notebook.Page))).ptr = n;
			n.prev = c;
			c.next = n;
		}
		return;
	}
}

