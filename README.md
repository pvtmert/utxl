# Unified Text Editor Lite
###### * just a casual name i come up with
### c-sharp term project

A casual text editor, with file-tree to allow easy navigation within editor (which is currently standard in most modern editors), supports tabs.

Actually this is our term project in C-sharp class in Bahcesehir University. Uses GTK (GTK#) for UI stuff to make it avaliable for OSX, Linux and Windows (aka cross-platform).

Currently it still needs to be updated, such as undo-redo operations are missing. But we use INI file as settings storage and all are implemented, of course functioning again but has no UI.

Let's look at core functions:
- Open button opens directory, not files... When you open directory you double click those files from the left side tree. Thus will open such file in new tab within main editor area. And won't switch to tab if the file is opened already _it will reopen in new tab_
- If you want to delete unnecessary items from tree, you need to select it and press close button in the toolbar.
- There is no save-as function (as of March 12th, 2016) just the save function. Even if file opened, save function won't overwrite file, still asks for your input to file to save. But if you type same filename as original, _it will overwrite!_
- Preferences button currently only changes font, font change also applies all tabs and the file-tree...
- File tree double clicking directories should expand unexpand these... You can also move these (drag and drop) but it won't change actual filesystem statuses of files or directories. It is just temporary to make user feel better :)
- Tabs: You can also drag and drop tabs. I'm currently working on drag and drop tabs to other windows, let's say other instances of this application. But I am sure this will fail 99% :)

authors:
- mert akengin / [@pvtmert]
- omar albeik / [@omaralbeik]
- zafer huzmeli / [@zaferhuzmeli]

#### more to come later...

[@pvtmert]: //github.com/pvtmert
[@omaralbeik]: //github.com/omaralbeik
[@zaferhuzmeli]: //github.com/zaferhuzmeli
