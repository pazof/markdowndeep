// // XamlBlock.cs
// /*
// Paul Schneider paul@pschneider.fr 20/04/2019 23:46 20192019 4 20
// */
using System;
using System.Collections.Generic;
using MarkdownAVToXaml;
using MarkdownAVToXaml.Rendering.Text.Xaml;
using System.Linq;

namespace MdToEtoXaml
{
    public class XamlBlock : MdToXamlBlock<MDSpan>
    {

        XmlRenderer xmlRenderer;
        public Dictionary<string, string> Parameters
        { get => xmlRenderer.Parameters; }

        IMap _map;
        IEnumerable<MdToXamlBlock<MDSpan>> _blocks;

        public XamlBlock(IMap map, IEnumerable<MdToXamlBlock<MDSpan>> blocks, string tag = "StackLayout")
        {
            _map = map;
            _blocks = blocks ;
            xmlRenderer = new XmlRenderer(tag,null);
        }

        public string Tag { get => xmlRenderer.MainClass; set => xmlRenderer.MainClass = value; }

        public override string GetRenderer()
        {
            return xmlRenderer.RenderBlocks(_blocks?.Select(b => b.GetRenderer()));
        }
    }
}
