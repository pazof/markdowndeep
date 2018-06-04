// // Paragraph.cs
// /*
// Paul Schneider paul@pschneider.fr 02/06/2018 04:48 20182018 6 2
// */
using System;
using MarkdownDeep.Rendering.Abstract;
namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    public class Paragraph : MdToXamlBlock
    {
        XmlRenderer _xmlRenderer;
        IRenderer<string> _inner;

        public Paragraph(IRenderer<string> inner)
        {
            _inner = inner;
            _xmlRenderer = new XmlRenderer("StackLayout");
            _xmlRenderer.Parameters.Add("Orientation", "Horizontal");
            _xmlRenderer.Parameters.Add("Padding", "5");
        }

        public override string Render()
        {
            return _xmlRenderer.Render(_inner.Render());
        }
    }
}
