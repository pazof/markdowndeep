using System;
using Eto.Forms;
using Eto.GtkSharp.Forms;
using static Eto.Forms.Control;

namespace MDGui.Gtk2
{
    public class GuiControlHandler : GtkControl<Widget,GuiControl, ICallback>,  IGuiControlHandler
	{
        ICallback handler;

		public GuiControlHandler ()
		{
			this.Control = new MDGui.Gtk2.Widget (); //?
            handler = new Callback();
		}

        class Callback : ICallback
        {
            public void OnGotFocus(Control widget, EventArgs e)
            {
                throw new NotImplementedException();
            }

            public void OnKeyDown(Control widget, KeyEventArgs e)
            {
                throw new NotImplementedException();
            }

            public void OnKeyUp(Control widget, KeyEventArgs e)
            {
                throw new NotImplementedException();
            }

            public void OnLostFocus(Control widget, EventArgs e)
            {
                throw new NotImplementedException();
            }

            public void OnMouseDoubleClick(Control widget, MouseEventArgs e)
            {
                throw new NotImplementedException();
            }

            public void OnMouseDown(Control widget, MouseEventArgs e)
            {
                throw new NotImplementedException();
            }

            public void OnMouseEnter(Control widget, MouseEventArgs e)
            {
                throw new NotImplementedException();
            }

            public void OnMouseLeave(Control widget, MouseEventArgs e)
            {
                throw new NotImplementedException();
            }

            public void OnMouseMove(Control widget, MouseEventArgs e)
            {
                throw new NotImplementedException();
            }

            public void OnMouseUp(Control widget, MouseEventArgs e)
            {
                throw new NotImplementedException();
            }

            public void OnMouseWheel(Control widget, MouseEventArgs e)
            {
                throw new NotImplementedException();
            }

            public void OnShown(Control widget, EventArgs e)
            {
                throw new NotImplementedException();
            }

            public void OnSizeChanged(Control widget, EventArgs e)
            {
                throw new NotImplementedException();
            }

            public void OnTextInput(Control widget, TextInputEventArgs e)
            {
                throw new NotImplementedException();
            }
        }
		public void OnStart(MainForm f){
		}

		

        public void OnBufferChanged(object sender, BufferChangedEventArgs args)
        {
            throw new NotImplementedException();
        }
	}
}

