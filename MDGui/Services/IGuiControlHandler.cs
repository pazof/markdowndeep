using System;
using System.Collections.Generic;
using Eto;
using Eto.Drawing;
using Eto.Forms;

namespace MDGui
{
    public interface IGuiControlHandler : Control.IHandler
    {
        void OnBufferChanged(object sender, BufferChangedEventArgs args);
    }

    public partial class GuiControlHandler : Control, IGuiControlHandler
    {
        public GuiControlHandler()
        {
        }

        public Widget Widget { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void HandleEvent(string id, bool defaultEvent = false)
        {
            throw new NotImplementedException();
        }

        public void OnBufferChanged(object sender, BufferChangedEventArgs args)
        {
            throw new NotImplementedException();
        }

        public void SetParent(Container parent)
        {
            throw new NotImplementedException();
        }

        void Widget.IHandler.Initialize()
        {
            throw new NotImplementedException();
        }

        void IHandler.OnLoad(EventArgs e)
        {
            throw new NotImplementedException();
        }

        void IHandler.OnLoadComplete(EventArgs e)
        {
            throw new NotImplementedException();
        }

        void IHandler.OnPreLoad(EventArgs e)
        {
            throw new NotImplementedException();
        }

        void IHandler.OnUnLoad(EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

