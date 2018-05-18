// // MdToXamlBlock.cs
// /*
// Paul Schneider paul@pschneider.fr 17/05/2018 13:19 20182018 5 17
// */
using System;
using MarkdownDeep.Model;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    public class MdToXamlBlock : MDBlock
    {
        public MdToXamlBlock(params MDSpan[] nodes) : base(nodes)
        {
            
        }

    }
}
