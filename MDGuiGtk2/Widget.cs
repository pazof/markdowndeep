using System;
using Eto.GtkSharp.CustomControls;

namespace MDGui.Gtk2
{
	[System.ComponentModel.ToolboxItem (true)]
	public partial class Widget : SizableBin
	{
		public Widget ()
		{
			this.Build ();
		}
	}
}

