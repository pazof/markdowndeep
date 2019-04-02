using System;
using System.Collections.Generic;
using Eto;
using Eto.Forms;
using Eto.GtkSharp.Forms.Controls;
using Eto.Markdown;
using GLib;
using Mono.Options;


namespace MDGui.Gtk3
{
	public class Program
	{
		[STAThread]
		public static void Main (string[] args)
        {
            Log.Messages.Subscribe(new ConsoleLogger());
            var generator = Platform.Detect;

            // To register new controls :
            // platform.Add<MyDynamicControl> (() => new MyDynamicControl(null));
            // generator.Add<MDGuiFileDialog> (() => {var dialog = new MDGuiFileDialog(); return dialog; });
            // platform.Add<MyCustomControl.IMyCustomControl>(() => new MyCustomControlHandler());

            GLib.ExceptionManager.UnhandledException +=  delegate(GLib.UnhandledExceptionArgs exargs) {
                Log.LogError("Glib unhandled",exargs.ExceptionObject.ToString());
			};
            bool show_help = false;
            var names = new List<string>();
            var extra = new List<string>();
            int verbosity = 0;

            var p = new OptionSet() {
                { "f|file=", "the name of someone to greet.",
                  v => names.Add (v) },
                { "v", "increase debug message verbosity",
                  v => { if (v != null) ++verbosity; } },
                { "h|help",  "show this message and exit",
                  v => show_help = v != null },
            };

            string targetFileName = null;
            try
            {
                extra = p.Parse(args);
            }
            catch (OptionException e)
            {
                Console.Write("greet: ");
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `greet --help' for more information.");
                return;
            }
            if (extra.Count == 1)
            {
                targetFileName = extra[0];
            }
            else if (extra.Count >= 1)
            {
                throw new NotImplementedException("extra.Count >= 1");
            }
			var app = new Application (generator);
			var form = new MainForm ();
            if (targetFileName != null)
                form.LoadMarkdownFile(targetFileName);
            app.Run (form);


		}
	}
}
