// // TextLine.cs
// /*
// Paul Schneider paul@pschneider.fr 13/04/2019 16:42 20192019 4 13
// */
using System;
using Eto.Forms;
using MarkdownAVToXaml.Rendering.Text.Xaml;
using MarkdownAVToXaml.Rendering.Text.Xaml.Eto;
namespace MDGui
{
    public class TextLine: SingleValueCell<XamlText>
    {
        public TextLine()
        {

            var l = new Label();
            l.Wrap = WrapMode.Word;
        }
    }
}
