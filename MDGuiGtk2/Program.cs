using System;
using Eto;
using Eto.Forms;

namespace MDGui.Gtk2
{
	public class Program
	{
        static GuiControl control;
		[STAThread]
		public static void Main (string[] args)
		{
			Platform.Get(Platforms.Gtk2)
				.Add<GuiControl.ICallback> (() => (Eto.Forms.Control.ICallback)control);
			new Application (Platforms.Gtk2).Run (new MainForm ());
		}
	}
}
