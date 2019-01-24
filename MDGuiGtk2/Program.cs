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
			new Application (Platforms.Gtk).Run (new MainForm ());
		}
	}
}
