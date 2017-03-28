using System;
using Eto;
using Eto.Forms;

namespace MDGui.Gtk3
{
	public class Program
	{
		[STAThread]
		public static void Main (string[] args)
		{
			var generator = new Eto.GtkSharp.Platform();

			// var platform = Eto.Platform.Detect;

			// To register new controls :
			// platform.Add<MyDynamicControl> (() => new MyDynamicControl(null));
			// generator.Add<MDGuiFileDialog> (() => {var dialog = new MDGuiFileDialog(); return dialog; });

			GLib.ExceptionManager.UnhandledException +=  delegate(GLib.UnhandledExceptionArgs exargs) {
				Log.LogError("Glib unhandled",exargs.ExceptionObject.ToString());
			};

			Log.Messages.Subscribe (new ConsoleLogger ());

			new Application (generator).Run (new MainForm ());
		}
	}
}
