// // Button.cs
// /*
// Paul Schneider paul@pschneider.fr 02/06/2018 03:55 20182018 6 2
// */
using System;
using System.Collections.Generic;
using MarkdownDeep.Rendering.Abstract;
namespace MarkdownAVToXaml.Rendering.Text.Xaml.Eto
{
    public class Button : XamlText
    {
        public Button(string action, string txt, string title, TextStyle style, IMap map) : base(txt, style,  map)
        {
            Tag="Button";
            Parameters.Add("CommandParameter", action);
            Parameters.Add("Text", txt);
            Parameters.Add("ToolTip", title);
        }
    }
}
