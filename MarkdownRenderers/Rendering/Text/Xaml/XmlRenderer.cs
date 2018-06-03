// // XmlRenderer.cs
// /*
// Paul Schneider paul@pschneider.fr 02/06/2018 04:00 20182018 6 2
// */
using System;
using System.Collections.Generic;
using System.Text;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    public class XmlRenderer
    {
        public string MainClass { get; set; }
        public Dictionary<string, string> Parameters { get; protected set; }

        public XmlRenderer(string mainClass)
        {
            MainClass = mainClass;
            Parameters = new Dictionary<string, string>();
        }

        public string Render(params IRenderer<string>[] children)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"<{MainClass} {Parameters}>");
            foreach (var child in children)
                sb.Append(child.Render());
            sb.Append($"</{MainClass}>");
            return sb.ToString();
        }

        internal string Render(List<IBlock<string>> blocks)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"<{MainClass} {Parameters}>");
            foreach (var child in blocks)
                sb.Append(child.Render());
            sb.Append($"</{MainClass}>");
            return sb.ToString();
        }
    }
}
