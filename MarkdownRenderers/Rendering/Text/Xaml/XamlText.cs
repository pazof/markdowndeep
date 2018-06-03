// // MDText.cs
// /*
// Paul Schneider paul@pschneider.fr 01/06/2018 14:15 20182018 6 1
// */
using System;
using System.Collections.Generic;
using MarkdownDeep.Rendering.Abstract;
namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    public class XamlText : MdToXamlNode
    {
        public string Text { get; protected set; }

        public XamlText(string txt, int start, int len)
        {
            Start = start;
            Length = len;
            Text = txt;
        }

        public override string Render()
        {
            return Text;
        }
    }
}
