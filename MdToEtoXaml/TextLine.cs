
using System.Collections.Generic;
using System;
using System.Linq;
using MarkdownAVToXaml.Rendering.Text.Xaml.Xamarin;

namespace MarkdownAVToXaml.Rendering.Text.Xaml.Eto
{
    public class TextLine : MdToXamlBlock<MDSpan>
    {
        private IEnumerable<MDSpan> words;
        private IMap _map;
        private XmlRenderer xmlRenderer;

        public TextLine(IEnumerable<MDSpan> words, IMap map)
        {
            _map = map;
            this.words = words;
            xmlRenderer = new XmlRenderer(Tag, null);
            xmlRenderer.Parameters.Add("Orientation", "Horizontal");
        }
        public string Tag { get; set; } = "StackLayout";
        public override string GetRenderer()
        {
           return xmlRenderer.RenderBlocks(words.Select(w => w.GetRenderer()));
        }
    }
}

