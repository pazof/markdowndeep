// // DocumentRenderer.cs
// /*
// Paul Schneider paul@pschneider.fr 06/06/2018 03:15 20182018 6 6
// */
using System;
using System.Collections.Generic;
using MarkdownDeep.Rendering.Abstract;
using System.Linq;

namespace MarkdownAVToXaml.Rendering.Text.Xaml.Xamarin
{
    public class Document 
    {
        XmlRenderer renderer;
        BlockList Content;
        public Document (string mainClass, string member, IEnumerable<MdToXamlBlock<MDSpan>> blocks)
        {
            Content = new BlockList();
            // blocks);
            Renderer = new XmlRenderer(mainClass, member);
            Renderer.Parameters.Add("xmlns", "http://xamarin.com/schemas/2014/forms");
            Renderer.Parameters.Add("xmlns:x", "http://schemas.microsoft.com/winfx/2009/xaml");
        }

        public XmlRenderer Renderer { get => renderer; set => renderer = value; }

        public string GetRenderer()
        {
            return XmlRenderer.XmlHeader + renderer.RenderBlocks(Content.Select(b => b.GetRenderer()));
        }
    }
}
