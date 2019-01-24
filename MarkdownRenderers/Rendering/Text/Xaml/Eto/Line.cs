// // Line.cs
// /*
// Paul Schneider paul@pschneider.fr 02/06/2018 04:42 20182018 6 2
// */
using System;
using System.Collections.Generic;
using System.Linq;
using MarkdownDeep.Rendering.Abstract;
using System.Text;

namespace MarkdownAVToXaml.Rendering.Text.Xaml.Eto
{
    public class Line : MdToXamlBlock
    {
        public Line(IEnumerable<MdToXamlBlock> inner, IMap map)
        {
            Spans = inner;
        }
        public Line(string txt, int start, int len, IMap map)
        {
            Spans = new List<MdToXamlBlock>
            {
                new XamlText(txt, start, len, TextStyle.Normal, map)
            };
        }

        public override string Render()
        {
            if (Spans == null) return null;
            StringBuilder sb = new StringBuilder();
            foreach (var item in Spans)
                sb.AppendLine(item.Render());
            return sb.ToString();
        }

        public override string ToString()
        {
            return $"[Line Spans:{Spans.Count()} {Style} {Level}]";
        }
    }
}
