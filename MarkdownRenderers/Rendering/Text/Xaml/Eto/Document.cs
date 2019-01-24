// // DocumentRenderer.cs
// /*
// Paul Schneider paul@pschneider.fr 06/06/2018 03:15 20182018 6 6
// */
using System;
using System.Collections.Generic;
using MarkdownDeep.Rendering.Abstract;
using System.Linq;

namespace MarkdownAVToXaml.Rendering.Text.Xaml.Eto
{
    public class Document : IRenderer<string>
    {
        XmlRenderer renderer;
        BlockList Content;
        public Document (string mainClass, IEnumerable<IRenderer<string>> blocks)
        {
            Content = new BlockList(blocks);
            Renderer = new XmlRenderer(mainClass);
            Renderer.Parameters.Add("xmlns", "http://schema.picoe.ca/eto.forms");
            Renderer.Parameters.Add("xmlns:x", "http://schemas.microsoft.com/winfx/2006/xaml");
        }

        public XmlRenderer Renderer { get => renderer; set => renderer = value; }

        public string Render()
        {
            return XmlRenderer.XmlHeader+renderer.Process (Content, "StackLayout");
        }
    }
}
