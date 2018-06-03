// // Button.cs
// /*
// Paul Schneider paul@pschneider.fr 02/06/2018 03:55 20182018 6 2
// */
using System;
using System.Collections.Generic;
using MarkdownDeep.Rendering.Abstract;
namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    public class Button : XamlText
    {
        XmlRenderer xmlRenderer = new XmlRenderer("LinkButton");

        public Button(string action, string txt, int start, int len) : base(txt, start, len)
        {
            xmlRenderer.Parameters.Add("CommandParameter", action);
            xmlRenderer.Parameters.Add("Text", txt);
        }

        public override string Render()
        {
            return xmlRenderer.Render();
        }

    }
}
