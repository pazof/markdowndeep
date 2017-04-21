using System;

namespace MDGui.Gtk3
{
	[System.ComponentModel.ToolboxItem (true)]
	public partial class Widget : Gtk.Bin
	{
		public Widget ()
		{
			this.Build ();
		}
	}
}

