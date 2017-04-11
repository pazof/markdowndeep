using System;
using Eto.GtkSharp.Forms;

namespace MDGui.Gtk2
{
	public class GuiControlHandler : GtkControl<Widget,GuiControl,GuiControl.ICallback>, GuiControl.IGuiControl
	{
		public GuiControlHandler (): base()
		{
			this.Control = new MDGui.Gtk2.Widget ();
		}
		public void OnStart(MainForm f){
		}
		public void OnBufferChanged()
		{
		}
	}
}

