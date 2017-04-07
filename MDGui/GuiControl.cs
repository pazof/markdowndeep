using System;
using Eto.Drawing;
using Eto.Forms;
using Eto;

namespace MDGui
{
	[Handler(typeof(IGuiControl))]
	public class GuiControl : Control
	{
		IGuiControl Handler { get { return (IGuiControl)base.Handler; } }

		// interface to the platform implementations
		public new interface IGuiControl : Control.IHandler
		{
			void OnStart(MainForm f);
			void OnBufferChanged();
		}
	}
}

