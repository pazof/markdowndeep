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
			Platform.Get(Platforms.Gtk2)
				.Add<GuiControl.IGuiControl> (() => new GuiControlHandler ());
			new Application (Platforms.Gtk2).Run (new MainForm ());
		}
	}
}
