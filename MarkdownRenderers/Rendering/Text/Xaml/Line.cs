// // Line.cs
// /*
// Paul Schneider paul@pschneider.fr 02/06/2018 04:42 20182018 6 2
// */
using System;
using System.Linq;
namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    public class Line : MdToXamlNode
    {
        XmlRenderer xmlRenderer;

        public MdToXamlNode[] Spans { get; protected set; }

        public Line(MdToXamlNode[] inner)
        {
            if (inner.Length < 1 || inner.Any(i => i == null))
                throw new InvalidProgramException();
            Spans = inner;
            xmlRenderer = new XmlRenderer("StackLayout");
            xmlRenderer.Parameters.Add("Orientation", "Horizontal");
        }


        public override string Render()
        {
            return xmlRenderer.Render(Spans);
        }
    }
}
