// // Button.cs
// /*
// Paul Schneider paul@pschneider.fr 02/06/2018 03:55 20182018 6 2
// */
using System;
using System.Collections.Generic;
using MarkdownDeep.Rendering.Abstract;
namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    public class Button : MdToXamlNode
    {
        XmlRenderer xmlRenderer = new XmlRenderer("LinkButton");

        public Button(string action, string txt, string title) 
        {
            xmlRenderer.Parameters.Add("CommandParameter", action);
            xmlRenderer.Parameters.Add("Text", txt);
            xmlRenderer.Parameters.Add("ToolTip", title);
        }

        public override string Render()
        {
            return xmlRenderer.RenderEmpty();
        }

    }
}
