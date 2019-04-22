// // Button.cs
// /*
// Paul Schneider paul@pschneider.fr 02/06/2018 03:55 20182018 6 2
// */
using System;
using System.Collections.Generic;
using System.Linq;
using MarkdownDeep.Rendering.Abstract;
namespace MarkdownAVToXaml.Rendering.Text.Xaml.Eto
{
    public class Button : XamlText
    {
        public Button(string action, IEnumerable<MdToXamlBlock<MDSpan>> txt, string title, TextStyle style, IMap map) : base(null, style,  map)
        {
            Tag="Button";
            Text = string.Join(" ", txt.Select(b => string.Join(" ", b.Select(w => w.Text))));
            Parameters.Add("CommandParameter", action);

            Parameters.Add("Text", Text);
            Parameters.Add("ToolTip", title);
        }

        public Button(string action, string txt, string title, TextStyle style, IMap map) : base(txt, style, map)
        {
            Tag = "Button";
            Parameters.Add("CommandParameter", action);
            Parameters.Add("Text", Text);
            Parameters.Add("ToolTip", title);
        }

    }
}
