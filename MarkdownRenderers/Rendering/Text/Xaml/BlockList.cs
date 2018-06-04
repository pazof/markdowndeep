﻿// // BlockList.cs
// /*
// Paul Schneider paul@pschneider.fr 02/06/2018 20:36 20182018 6 2
// */
using System;
using System.Collections.Generic;
using MarkdownDeep.Rendering.Abstract;
using System.Text;

namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    public class BlockList: MdToXamlBlock
    {
        XmlRenderer renderer;

        public List<IBlock<string>> Blocks { get; protected set; }

        public BlockList()
        {
            Blocks = new List<IBlock<string>>();
            renderer = new XmlRenderer("StackLayout");
        }

        public BlockList(IBlock<string>[] blocks)
        {
            Blocks = new List<IBlock<string>>(blocks);
            renderer = new XmlRenderer("StackLayout");
            renderer.Parameters["Padding"] = "15,18,12,12";
        }

        public override string Render()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var block in Blocks)
            {
                sb.Append(block.Render());
            }
            return renderer.Render(sb.ToString());
        }
    }
}
