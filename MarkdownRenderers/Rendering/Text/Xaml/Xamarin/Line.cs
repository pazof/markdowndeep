// // Line.cs
// /*
// Paul Schneider paul@pschneider.fr 02/06/2018 04:42 20182018 6 2
// */
using System;
using System.Collections.Generic;
using System.Linq;
using MarkdownDeep.Rendering.Abstract;
using System.Text;

namespace MarkdownAVToXaml.Rendering.Text.Xaml.Xamarin
{
    public class Line : MdToXamlBlock
    {
        XmlRenderer xmlRenderer;

        public Line(IEnumerable<MdToXamlBlock> inner, IMap map)
        {
            Spans = inner;
            xmlRenderer = new XmlRenderer("Label");
        }
        public Line(string txt, int start, int len, IMap map)
        {
            Spans = new List<MdToXamlBlock>
            {
                new XamlText(txt, start, len, TextStyle.Normal, map)
            };
        }

        string header_render_Format = "<Label.FormattedText><FormattedString><FormattedString.Spans>";
        string footer_render_Format = "</FormattedString.Spans></FormattedString></Label.FormattedText>";

        public enum XamlFormats
        {
            Xamarin,
            Eto
        };

        public static XamlFormats GlobalSetup { get; set; } = XamlFormats.Eto;

        public override string Render()
        {
            if (Spans == null) return null;
            StringBuilder sb = new StringBuilder();
            sb.Append(header_render_Format);
            foreach (var item in Spans)
                sb.AppendLine(item.Render());
            sb.Append(footer_render_Format);
            return xmlRenderer.RenderRaw(sb.ToString());
        }

        public override string ToString()
        {
            return $"[Line Spans:{Spans.Count()} {Style} {Level}]";
        }
    }
}
