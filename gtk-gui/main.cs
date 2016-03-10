
// This file has been generated by the GUI designer. Do not modify.

public partial class main
{
	private global::Gtk.UIManager UIManager;
	
	private global::Gtk.Action fileAction;
	
	private global::Gtk.Action editAction;
	
	private global::Gtk.Action toolsAction;
	
	private global::Gtk.Action helpAction;
	
	private global::Gtk.Action newAction;
	
	private global::Gtk.Action openAction;
	
	private global::Gtk.Action saveAction;
	
	private global::Gtk.Action quitAction;
	
	private global::Gtk.Action printAction;
	
	private global::Gtk.Action undoAction;
	
	private global::Gtk.Action redoAction;
	
	private global::Gtk.Action preferencesAction;
	
	private global::Gtk.Action newAction1;
	
	private global::Gtk.Action openAction1;
	
	private global::Gtk.Action saveAction1;
	
	private global::Gtk.Action saveAsAction;
	
	private global::Gtk.Action printAction1;
	
	private global::Gtk.Action dndAction;
	
	private global::Gtk.Action deleteAction;
	
	private global::Gtk.Action quitAction1;
	
	private global::Gtk.Action undoAction1;
	
	private global::Gtk.Action redoAction1;
	
	private global::Gtk.Action formatAction;
	
	private global::Gtk.Action helpAction1;
	
	private global::Gtk.Action dialogInfoAction;
	
	private global::Gtk.Action syntaxAction;
	
	private global::Gtk.Action colorsAction;
	
	private global::Gtk.Action notesAction;
	
	private global::Gtk.Action buildAction;
	
	private global::Gtk.Action cleanAction;
	
	private global::Gtk.Action preferencesAction1;
	
	private global::Gtk.Action closeAction;
	
	private global::Gtk.Action fontsAction;
	
	private global::Gtk.Action runAction;
	
	private global::Gtk.Action saveAsAction1;
	
	private global::Gtk.VPaned vpaned1;
	
	private global::Gtk.MenuBar menu;
	
	private global::Gtk.VPaned vpaned2;
	
	private global::Gtk.Toolbar tools;
	
	private global::Gtk.HPaned hpaned1;
	
	private global::Gtk.ScrolledWindow GtkScrolledWindow;
	
	private global::Gtk.TreeView tree;
	
	private global::Gtk.Notebook notebook;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget main
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.fileAction = new global::Gtk.Action ("fileAction", global::Mono.Unix.Catalog.GetString ("file"), null, null);
		this.fileAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("file");
		w1.Add (this.fileAction, null);
		this.editAction = new global::Gtk.Action ("editAction", global::Mono.Unix.Catalog.GetString ("edit"), null, null);
		this.editAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("edit");
		w1.Add (this.editAction, null);
		this.toolsAction = new global::Gtk.Action ("toolsAction", global::Mono.Unix.Catalog.GetString ("tools"), null, null);
		this.toolsAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("tools");
		w1.Add (this.toolsAction, null);
		this.helpAction = new global::Gtk.Action ("helpAction", global::Mono.Unix.Catalog.GetString ("help"), null, null);
		this.helpAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("help");
		w1.Add (this.helpAction, null);
		this.newAction = new global::Gtk.Action ("newAction", null, null, "gtk-new");
		w1.Add (this.newAction, null);
		this.openAction = new global::Gtk.Action ("openAction", null, null, "gtk-open");
		w1.Add (this.openAction, null);
		this.saveAction = new global::Gtk.Action ("saveAction", null, null, "gtk-save");
		w1.Add (this.saveAction, null);
		this.quitAction = new global::Gtk.Action ("quitAction", null, null, "gtk-quit");
		w1.Add (this.quitAction, null);
		this.printAction = new global::Gtk.Action ("printAction", null, null, "gtk-print");
		w1.Add (this.printAction, null);
		this.undoAction = new global::Gtk.Action ("undoAction", null, null, "gtk-undo");
		w1.Add (this.undoAction, null);
		this.redoAction = new global::Gtk.Action ("redoAction", null, null, "gtk-redo");
		w1.Add (this.redoAction, null);
		this.preferencesAction = new global::Gtk.Action ("preferencesAction", null, null, "gtk-preferences");
		w1.Add (this.preferencesAction, null);
		this.newAction1 = new global::Gtk.Action ("newAction1", global::Mono.Unix.Catalog.GetString ("new"), null, "gtk-new");
		this.newAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("new");
		w1.Add (this.newAction1, null);
		this.openAction1 = new global::Gtk.Action ("openAction1", global::Mono.Unix.Catalog.GetString ("open"), null, "gtk-open");
		this.openAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("open");
		w1.Add (this.openAction1, null);
		this.saveAction1 = new global::Gtk.Action ("saveAction1", global::Mono.Unix.Catalog.GetString ("save"), null, "gtk-save");
		this.saveAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("save");
		w1.Add (this.saveAction1, null);
		this.saveAsAction = new global::Gtk.Action ("saveAsAction", global::Mono.Unix.Catalog.GetString ("save as"), null, "gtk-save-as");
		this.saveAsAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("save as");
		w1.Add (this.saveAsAction, null);
		this.printAction1 = new global::Gtk.Action ("printAction1", global::Mono.Unix.Catalog.GetString ("print"), null, "gtk-print");
		this.printAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("print");
		w1.Add (this.printAction1, "<Primary><Mod2>p");
		this.dndAction = new global::Gtk.Action ("dndAction", global::Mono.Unix.Catalog.GetString ("properties"), null, "gtk-dnd");
		this.dndAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("properties");
		w1.Add (this.dndAction, null);
		this.deleteAction = new global::Gtk.Action ("deleteAction", global::Mono.Unix.Catalog.GetString ("close"), null, "gtk-delete");
		this.deleteAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("close");
		w1.Add (this.deleteAction, "<Primary><Mod2>w");
		this.quitAction1 = new global::Gtk.Action ("quitAction1", global::Mono.Unix.Catalog.GetString ("quit"), null, "gtk-quit");
		this.quitAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("quit");
		w1.Add (this.quitAction1, null);
		this.undoAction1 = new global::Gtk.Action ("undoAction1", global::Mono.Unix.Catalog.GetString ("undo"), null, null);
		this.undoAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("undo");
		w1.Add (this.undoAction1, null);
		this.redoAction1 = new global::Gtk.Action ("redoAction1", global::Mono.Unix.Catalog.GetString ("redo"), null, null);
		this.redoAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("redo");
		w1.Add (this.redoAction1, null);
		this.formatAction = new global::Gtk.Action ("formatAction", global::Mono.Unix.Catalog.GetString ("format"), null, null);
		this.formatAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("format");
		w1.Add (this.formatAction, null);
		this.helpAction1 = new global::Gtk.Action ("helpAction1", global::Mono.Unix.Catalog.GetString ("contents"), null, "gtk-help");
		this.helpAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("contents");
		w1.Add (this.helpAction1, null);
		this.dialogInfoAction = new global::Gtk.Action ("dialogInfoAction", global::Mono.Unix.Catalog.GetString ("about"), null, "gtk-dialog-info");
		this.dialogInfoAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("about");
		w1.Add (this.dialogInfoAction, null);
		this.syntaxAction = new global::Gtk.Action ("syntaxAction", global::Mono.Unix.Catalog.GetString ("syntax"), null, null);
		this.syntaxAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("syntax");
		w1.Add (this.syntaxAction, null);
		this.colorsAction = new global::Gtk.Action ("colorsAction", global::Mono.Unix.Catalog.GetString ("colors"), null, null);
		this.colorsAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("colors");
		w1.Add (this.colorsAction, null);
		this.notesAction = new global::Gtk.Action ("notesAction", global::Mono.Unix.Catalog.GetString ("notes"), null, null);
		this.notesAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("notes");
		w1.Add (this.notesAction, null);
		this.buildAction = new global::Gtk.Action ("buildAction", global::Mono.Unix.Catalog.GetString ("build"), null, null);
		this.buildAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("build");
		w1.Add (this.buildAction, null);
		this.cleanAction = new global::Gtk.Action ("cleanAction", global::Mono.Unix.Catalog.GetString ("clean"), null, null);
		this.cleanAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("clean");
		w1.Add (this.cleanAction, null);
		this.preferencesAction1 = new global::Gtk.Action ("preferencesAction1", global::Mono.Unix.Catalog.GetString ("preferences"), null, "gtk-preferences");
		this.preferencesAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("preferences");
		w1.Add (this.preferencesAction1, null);
		this.closeAction = new global::Gtk.Action ("closeAction", null, null, "gtk-close");
		w1.Add (this.closeAction, null);
		this.fontsAction = new global::Gtk.Action ("fontsAction", global::Mono.Unix.Catalog.GetString ("fonts"), null, null);
		this.fontsAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("fonts");
		w1.Add (this.fontsAction, null);
		this.runAction = new global::Gtk.Action ("runAction", global::Mono.Unix.Catalog.GetString ("run"), null, null);
		this.runAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("run");
		w1.Add (this.runAction, null);
		this.saveAsAction1 = new global::Gtk.Action ("saveAsAction1", null, null, "gtk-save-as");
		w1.Add (this.saveAsAction1, null);
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.Name = "main";
		this.Title = global::Mono.Unix.Catalog.GetString ("Unified Text Editor Lite");
		this.WindowPosition = ((global::Gtk.WindowPosition)(2));
		this.AllowShrink = true;
		this.DefaultWidth = 640;
		this.DefaultHeight = 480;
		this.Gravity = ((global::Gdk.Gravity)(5));
		this.Role = "text editor";
		// Container child main.Gtk.Container+ContainerChild
		this.vpaned1 = new global::Gtk.VPaned ();
		this.vpaned1.CanFocus = true;
		this.vpaned1.Name = "vpaned1";
		this.vpaned1.Position = 24;
		// Container child vpaned1.Gtk.Paned+PanedChild
		this.UIManager.AddUiFromString ("<ui><menubar name='menu'><menu name='fileAction' action='fileAction'><menuitem name='newAction1' action='newAction1'/><menuitem name='openAction1' action='openAction1'/><menuitem name='saveAction1' action='saveAction1'/><menuitem name='saveAsAction' action='saveAsAction'/><menuitem name='deleteAction' action='deleteAction'/><menuitem name='printAction1' action='printAction1'/><menuitem name='dndAction' action='dndAction'/><menuitem name='quitAction1' action='quitAction1'/></menu><menu name='editAction' action='editAction'><menuitem name='undoAction1' action='undoAction1'/><menuitem name='redoAction1' action='redoAction1'/><menuitem name='preferencesAction1' action='preferencesAction1'/></menu><menu name='toolsAction' action='toolsAction'><menuitem name='runAction' action='runAction'/><menuitem name='buildAction' action='buildAction'/><menuitem name='cleanAction' action='cleanAction'/></menu><menu name='helpAction' action='helpAction'><menuitem name='helpAction1' action='helpAction1'/><menuitem name='dialogInfoAction' action='dialogInfoAction'/></menu></menubar></ui>");
		this.menu = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menu")));
		this.menu.Name = "menu";
		this.vpaned1.Add (this.menu);
		global::Gtk.Paned.PanedChild w2 = ((global::Gtk.Paned.PanedChild)(this.vpaned1 [this.menu]));
		w2.Resize = false;
		// Container child vpaned1.Gtk.Paned+PanedChild
		this.vpaned2 = new global::Gtk.VPaned ();
		this.vpaned2.CanFocus = true;
		this.vpaned2.Name = "vpaned2";
		this.vpaned2.Position = 30;
		// Container child vpaned2.Gtk.Paned+PanedChild
		this.UIManager.AddUiFromString ("<ui><toolbar name='tools'><toolitem name='newAction' action='newAction'/><toolitem name='openAction' action='openAction'/><toolitem name='saveAction' action='saveAction'/><toolitem name='saveAsAction1' action='saveAsAction1'/><toolitem name='closeAction' action='closeAction'/><toolitem name='printAction' action='printAction'/><toolitem name='undoAction' action='undoAction'/><toolitem name='redoAction' action='redoAction'/><toolitem name='preferencesAction' action='preferencesAction'/><toolitem name='quitAction' action='quitAction'/></toolbar></ui>");
		this.tools = ((global::Gtk.Toolbar)(this.UIManager.GetWidget ("/tools")));
		this.tools.Name = "tools";
		this.tools.ShowArrow = false;
		this.tools.IconSize = ((global::Gtk.IconSize)(2));
		this.vpaned2.Add (this.tools);
		global::Gtk.Paned.PanedChild w3 = ((global::Gtk.Paned.PanedChild)(this.vpaned2 [this.tools]));
		w3.Resize = false;
		// Container child vpaned2.Gtk.Paned+PanedChild
		this.hpaned1 = new global::Gtk.HPaned ();
		this.hpaned1.CanFocus = true;
		this.hpaned1.Name = "hpaned1";
		this.hpaned1.Position = 142;
		// Container child hpaned1.Gtk.Paned+PanedChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.tree = new global::Gtk.TreeView ();
		this.tree.CanFocus = true;
		this.tree.Name = "tree";
		this.tree.Reorderable = true;
		this.tree.SearchColumn = 0;
		this.GtkScrolledWindow.Add (this.tree);
		this.hpaned1.Add (this.GtkScrolledWindow);
		global::Gtk.Paned.PanedChild w5 = ((global::Gtk.Paned.PanedChild)(this.hpaned1 [this.GtkScrolledWindow]));
		w5.Resize = false;
		// Container child hpaned1.Gtk.Paned+PanedChild
		this.notebook = new global::Gtk.Notebook ();
		this.notebook.CanFocus = true;
		this.notebook.Name = "notebook";
		this.notebook.CurrentPage = -1;
		this.hpaned1.Add (this.notebook);
		this.vpaned2.Add (this.hpaned1);
		this.vpaned1.Add (this.vpaned2);
		this.Add (this.vpaned1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.SizeRequested += new global::Gtk.SizeRequestedHandler (this.winResize);
		this.newAction.Activated += new global::System.EventHandler (this.newDoc);
		this.openAction.Activated += new global::System.EventHandler (this.openDoc);
		this.saveAction.Activated += new global::System.EventHandler (this.saveDoc);
		this.quitAction.Activated += new global::System.EventHandler (this.OnDeleteEvent);
		this.printAction.Activated += new global::System.EventHandler (this.printDoc);
		this.newAction1.Activated += new global::System.EventHandler (this.newDoc);
		this.openAction1.Activated += new global::System.EventHandler (this.openDoc);
		this.saveAction1.Activated += new global::System.EventHandler (this.saveDoc);
		this.deleteAction.Activated += new global::System.EventHandler (this.closeDoc);
		this.quitAction1.Activated += new global::System.EventHandler (this.OnDeleteEvent);
		this.dialogInfoAction.Activated += new global::System.EventHandler (this.aboutDialog);
		this.preferencesAction1.Activated += new global::System.EventHandler (this.changeFont);
		this.closeAction.Activated += new global::System.EventHandler (this.closeDoc);
		this.fontsAction.Activated += new global::System.EventHandler (this.changeFont);
		this.tree.RowActivated += new global::Gtk.RowActivatedHandler (this.treeOpen);
		this.tree.PopupMenu += new global::Gtk.PopupMenuHandler (this.treeDel);
	}
}