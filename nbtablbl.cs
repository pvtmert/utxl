// Copyright (c) 2010 Alpine Chough Software.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using Gtk;

namespace Alpinechough.Common.GtkUtilities
{
	public class NotebookTabLabel : EventBox
	{
		public string Text;
		public string Path;
		public NotebookTabLabel (string title, string path = "/")
		{
			Text = title;
			Path = path;
			
			Button button = new Button ();
			button.Image = new Gtk.Image (Stock.Close, IconSize.SmallToolbar);
			button.TooltipText = "Close";
			button.Relief = ReliefStyle.None;

			RcStyle rcStyle = new RcStyle ();
			rcStyle.Xthickness = 0;
			rcStyle.Ythickness = 0;
			button.ModifyStyle (rcStyle);

			button.FocusOnClick = false;
			button.Clicked += OnCloseClicked;
			button.Show ();

			Label label = new Label (title);
			label.UseMarkup = false;
			label.UseUnderline = false;
			label.Show ();

			HBox hbox = new HBox (false, 0);
			hbox.Spacing = 0;
			hbox.Add (button);
			hbox.Add (label);
			hbox.Show ();
			this.Add (hbox);
		}

		public event EventHandler<EventArgs> CloseClicked;
		public void OnCloseClicked (object sender, EventArgs e)
		{
			if (CloseClicked != null)
				CloseClicked (sender, e);
		}

		public void OnCloseClicked ()
		{
			OnCloseClicked (this, EventArgs.Empty);
		}
	}
}