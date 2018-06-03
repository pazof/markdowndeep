using System;
using Eto.Drawing;
using Eto;
using Eto.Forms;
using static MDGui.GuiControlHandler;
using Eto.Serialization.Xaml;

namespace MDGui
{
    [Handler(typeof(IGuiControlHandler))]
    public partial class GuiControl : Control
    {
        public GuiControl() {
            XamlReader.Load(this);

        }

    }
}

