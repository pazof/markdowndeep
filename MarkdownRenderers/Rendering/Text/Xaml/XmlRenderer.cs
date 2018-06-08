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
        public const string XmlHeader = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n";

        public string MainClass { get; set; }
        public Dictionary<string, string> Parameters { get; protected set; }

        public XmlRenderer(string mainClass)
        {
            MainClass = mainClass;
            Parameters = new Dictionary<string, string>();
        }

        public string RenderRaw(string rawContent)
        {
            StringBuilder sb = new StringBuilder();
            RenderOpeningTag(sb);
            sb.Append(rawContent);
            RenderClosingTag(sb);
            return sb.ToString();
        }

        void RenderOpeningTag(StringBuilder sb)
        {
            sb.Append("<");
            sb.Append(MainClass);
            foreach (var parameter in Parameters)
            {
                sb.Append(" ");
                sb.Append(parameter.Key);
                sb.Append("=\"");
                sb.Append(ToXmlAttrVal(parameter.Value));
                sb.Append("\"");
            }
            sb.Append(">"); 
        }
        string ToXmlAttrVal (string val)
        {
            return val?.Replace("\"", "\\\"").Replace("&","&amp;").Replace("<", "&lt;").Replace(">","&gt;");
        }

        void RenderClosingTag(StringBuilder sb)
        {
            sb.AppendLine($"</{MainClass}>");
        }

        internal string Render(IRenderer<string> block)
        {
            StringBuilder sb = new StringBuilder();
            RenderOpeningTag(sb);
            if (block != null)
                sb.AppendLine(block.Render());
            RenderClosingTag(sb);
            return sb.ToString();
        }

        internal string RenderEmpty ()
        {
            StringBuilder sb = new StringBuilder();
            RenderOpeningTag(sb);
            RenderClosingTag(sb);
            return sb.ToString();
        }

        internal string Render(List<IRenderer<string>> blocks)
        {
            StringBuilder sb = new StringBuilder();
            RenderOpeningTag(sb);
            if (blocks!=null)
            foreach (var child in blocks)
                sb.AppendLine(child.Render());
            RenderClosingTag(sb);
            return sb.ToString();
        }
    }
}
