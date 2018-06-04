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
namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    public class XamlText : MdToXamlNode
    {
        XmlRenderer xmlRenderer;

        IMap _map;

        public string Text { get;  set; }
        public XamlText()
        {
            init();
        }
        void init()
        {
            xmlRenderer = new XmlRenderer("Label");
        }

        public XamlText(string txt, int start, int len, TextStyle style, IMap map)
        {
            Start = start;
            Length = len;
            Text = txt;
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
            if (variants.Count > 0)
                xmlRenderer.Parameters["Font"] = string.Join("+", variants);
            else if (xmlRenderer.Parameters.ContainsKey("Font"))
                xmlRenderer.Parameters.Remove("Font");
            
            return xmlRenderer.Render(Text);
        }
    }
}
