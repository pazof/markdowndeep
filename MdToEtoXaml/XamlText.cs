// // MDText.cs
// /*
// Paul Schneider paul@pschneider.fr 01/06/2018 14:15 20182018 6 1
// */
using System;
using System.Collections.Generic;
using MarkdownDeep.Rendering.Abstract;
using System.Text;
using System.Linq;
using MarkdownDeep.Rendering;
namespace MarkdownAVToXaml.Rendering.Text.Xaml.Eto
{
    public class XamlText : MDSpan
    {
        XmlRenderer xmlRenderer;
        public Dictionary<string, string> Parameters
        { get => xmlRenderer.Parameters; }

        IMap _map;

        public HeaderLevel Level { get; private set; }
        public XamlText(string display, TextStyle style, IMap map)

        {
            xmlRenderer = new XmlRenderer("Label", null);
            Text = display;
            _map = map;
            Style = style;
        }

        public string Tag { get => xmlRenderer.MainClass; set => xmlRenderer.MainClass = value; }

        public override string GetRenderer()
        {
            List<string> variants = new List<string>();
            foreach (var styleFlag in new TextStyle[]{TextStyle.Emphasys, TextStyle.Fixed,
                TextStyle.Strong, TextStyle.Underline, TextStyle.Strike
            })
            {
                if ((styleFlag & Style) > 0)
                {
                    variants.Add(_map.TextFont[styleFlag]);
                }
            }
            if (Level > HeaderLevel.None)
                variants.Add(_map.HeaderFont[Level]);

            if (variants.Count > 0)
                xmlRenderer.Parameters["Font"] = string.Join("+", variants);
            else if (xmlRenderer.Parameters.ContainsKey("Font"))
                xmlRenderer.Parameters.Remove("Font");
            xmlRenderer.Parameters["Text"] = Text;
            return xmlRenderer.Render(null);
        }

        public override string ToString()
        {
            return $"[XamlText:{Tag} \"{Text}\", {Style}, {Level}]";
        }
    }
}
