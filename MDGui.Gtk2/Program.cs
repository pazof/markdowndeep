using System;
using Eto;
using Eto.Forms;

namespace MDGui.Gtk2
{
	public class Program
	{
		[STAThread]
		public static void Main (string[] args)
		{
			var generator = new Eto.GtkSharp.Platform();

			var platform = Eto.Platform.Detect;

			// To register new controls :
			platform.Add<GuiControl.IGuiControl> (() => new GuiControlHandler());

			new Application (generator).Run (new MainForm ());
		}
	}
}
