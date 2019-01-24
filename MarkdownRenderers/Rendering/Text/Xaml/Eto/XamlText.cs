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
    public class XamlText : MdToXamlBlock
    {
        XmlRenderer xmlRenderer;

        IMap _map;

        public string Text { get;  set; }

        void init()
        {
            xmlRenderer = new XmlRenderer("Label");
        }

        public XamlText(string txt, int start, int len, TextStyle style, IMap map)
        {
            Start = start;
            Length = len;
            Text = txt.Substring(start, len);
            _map = map;
            Style = style;
            init();
        }

        public override string Render()
        {
            List<string> variants = new List<string>();

            foreach (var styleFlag in new TextStyle[]{TextStyle.Emphasys, TextStyle.Fixed,
                TextStyle.Italic, TextStyle.Underline, TextStyle.Strike
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
            return xmlRenderer.RenderRaw(null);
        }

        public override string ToString()
        {
            return $"[XamlText {Text}, {Style}, {Level}]";
        }
    }
}
