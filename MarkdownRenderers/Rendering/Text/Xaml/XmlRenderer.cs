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

        public string Render(string rawContent)
        {
            return $"<{MainClass} {Parameters}>{rawContent}</{MainClass}>";
        }

        public string Render(params IRenderer<string>[] children)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<");
            sb.Append(MainClass);
            foreach (var parameter in Parameters)
            {
                sb.Append(" ");
                sb.Append(parameter.Key);
                sb.Append("=");
                sb.Append(parameter.Value);
            }
            sb.Append(">");             
            foreach (var child in children)
                sb.Append(child.Render());
            sb.Append($"</{MainClass}>");
            return sb.ToString();
        }

    }
}
