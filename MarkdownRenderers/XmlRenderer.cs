// // XmlRenderer.cs
// /*
// Paul Schneider paul@pschneider.fr 02/06/2018 04:00 20182018 6 2
// */
using System;
using System.Collections.Generic;
using System.Text;
using MarkdownDeep.Rendering.Abstract;
using System.Collections;

namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    public class XmlRenderer
    {
        public const string XmlHeader = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n";

        public string MainClass { get; set; }
        public string ClassMember { get; set; }

        public Dictionary<string, string> Parameters { get; protected set; }

        public XmlRenderer(string mainClass, string classMember)
        {
            MainClass = mainClass;
            ClassMember = classMember;
            Parameters = new Dictionary<string, string>();
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

        static string ToXmlAttrVal (string val)
        {
            return val?.Replace("\"", "\\\"").Replace("&","&amp;").Replace("<", "&lt;").Replace(">","&gt;");
        }

        public virtual string RenderBlocks(IEnumerable<string> blocks)
        {
            StringBuilder sb = new StringBuilder();
            RenderOpeningTag(sb);
            if (ClassMember!=null)
                sb.AppendLine($"<{MainClass}.{ClassMember}>");
            if (blocks!=null)
            foreach (var child in blocks)
                sb.AppendLine(child);
            if (ClassMember != null)
                sb.AppendLine($"</{MainClass}.{ClassMember}>");
            sb.AppendLine($"</{MainClass}>");
            return sb.ToString();
        }

        public virtual string Render(string block)
        {
            StringBuilder sb = new StringBuilder();
            RenderOpeningTag(sb);
            if (ClassMember != null)
                sb.AppendLine($"<{MainClass}.{ClassMember}>");
            if (block != null)
                    sb.AppendLine(block);
            if (ClassMember != null)
                sb.AppendLine($"</{MainClass}.{ClassMember}>");
            sb.AppendLine($"</{MainClass}>");
            return sb.ToString();
        }
    }
}
