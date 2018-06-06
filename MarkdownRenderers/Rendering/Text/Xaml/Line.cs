// // Line.cs
// /*
// Paul Schneider paul@pschneider.fr 02/06/2018 04:42 20182018 6 2
// */
using System;
using System.Collections.Generic;
using System.Linq;
using MarkdownDeep.Rendering.Abstract;
using System.Text;

namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    public class Line : MdToXamlNode
    {
        XmlRenderer xmlRenderer;

        List<IRenderer<string>> spans;

        public IEnumerable<IRenderer<string>> Spans { get {
                return spans;
            } 
            protected set {
                spans = new List<IRenderer<string>>(value);
            }
        }

        public Line(IEnumerable<IRenderer<string>> inner, IMap map)
        {
            if (inner.Count() < 1 || inner.Any(i => i == null))
                throw new InvalidProgramException();
            Spans = inner;
            xmlRenderer = new XmlRenderer("StackLayout");
            xmlRenderer.Parameters.Add("Orientation", "Horizontal");
        }

        public override string Render()
        {
            if (Spans.Count()>1) {
                StringBuilder sb = new StringBuilder();
                foreach (var item in Spans)
                    sb.AppendLine(item.Render());
                return xmlRenderer.RenderRaw(sb.ToString());
            }
            return Spans.First().Render();
        }
        public override string ToString()
        {
            return $"[Line Spans:{Spans.Count()} {Style} {Level}]";
        }
    }
}
