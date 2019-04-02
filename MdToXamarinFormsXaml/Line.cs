// // Line.cs
// /*
// Paul Schneider paul@pschneider.fr 02/06/2018 04:42 20182018 6 2
// */
using System;
using System.Collections.Generic;
using System.Linq;
using MarkdownDeep.Rendering.Abstract;
using System.Text;
using MdToEtoXamarinFormsXaml;

namespace MarkdownAVToXaml.Rendering.Text.Xaml.Xamarin
{
    public class Line : MdToXamlBlock<TextSpan>
    {
        IEnumerable<MdToXamlBlock<TextSpan>> inner;
        IMap map;
        public Line(IEnumerable<MdToXamlBlock<TextSpan>> inner, IMap map)
        {
            this.inner = inner;
            this.map = map;
        }

        string header_render_Format = "<Label.FormattedText><FormattedString><FormattedString.Spans>";
        string footer_render_Format = "</FormattedString.Spans></FormattedString></Label.FormattedText>";

        public enum XamlFormats
        {
            Xamarin,
            Eto
        };

        public static XamlFormats GlobalSetup { get; set; } = XamlFormats.Eto;

        public override string GetRenderer()
        {
          //  if (Spans == null) return null;
            StringBuilder sb = new StringBuilder();
            sb.Append(header_render_Format);
            foreach (var item in this)
               sb.AppendLine(item.GetRenderer());
            sb.Append(footer_render_Format);
            return sb.ToString();
        }

        public override string ToString()
        {
            return $"[Line Spans:{Count} {Level}]";
        }
    }
}
