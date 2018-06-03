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
        XmlRenderer xmlRenderer;
        public Paragraph(IRenderer<string> inner)
        {
            xmlRenderer = new XmlRenderer("StackLayout");
            xmlRenderer.Parameters.Add("Orientation", "Horizontal");
            xmlRenderer.Parameters.Add("Padding", "5");
        }

        public override string Render()
        {
            return xmlRenderer.Render();
        }
    }
}
