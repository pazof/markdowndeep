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
    public class Document 
    {
        BlockList Content;
        public Document (string mainClass, string destMember, IEnumerable<MdToXamlBlock<MDSpan>> blocks)
        {
            Content = new BlockList();
            Content.AddRange(blocks);
            Renderer = new XmlRenderer(mainClass, destMember);
            Renderer.Parameters.Add("xmlns", "http://schema.picoe.ca/eto.forms");
            Renderer.Parameters.Add("xmlns:x", "http://schemas.microsoft.com/winfx/2006/xaml");
        }

        public XmlRenderer Renderer { get; set; }

        public string GetRenderer()
        {
            var content = Content.Select(b=>b?.GetRenderer() ?? null).ToArray();
            return Renderer.Render("<StackLayout>" +string.Join("\n",content) + "</StackLayout>");
        }
    }
}
