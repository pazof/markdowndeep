// // BlockList.cs
// /*
// Paul Schneider paul@pschneider.fr 02/06/2018 20:36 20182018 6 2
// */
using System;
using System.Collections.Generic;
using MarkdownDeep.Rendering.Abstract;
using System.Text;
using System.Runtime.Serialization;
using System.Linq;

namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    public class BlockList : IRenderer<string>, IBlockList, ISerializable
    {
        protected XmlRenderer renderer;

        public List<IRenderer<String>> Blocks { get; protected set; }

        public BlockList()
        {
            Blocks = new List<IRenderer<String>>();
            renderer = new XmlRenderer("StackLayout");
        }

        public BlockList(IEnumerable<IRenderer<string>> blocks)
        {
            Blocks = new List<IRenderer<String>>(blocks);
            renderer = new XmlRenderer("StackLayout");
            renderer.Parameters["Padding"] = "7,11,5,5";
            renderer.Parameters["HorizontalContentAlignment"] = "Stretch";
        }

        public string Render()
        {
            if (Blocks.Count>1) {
                StringBuilder sb = new StringBuilder();
                foreach (var item in Blocks)
                    sb.AppendLine(item.Render());
                return renderer.RenderRaw(sb.ToString());
            }
            return Blocks.FirstOrDefault()?.Render();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
