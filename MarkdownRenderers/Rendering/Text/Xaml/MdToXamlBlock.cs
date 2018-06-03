// // MdToXamlBlock.cs
// /*
// Paul Schneider paul@pschneider.fr 17/05/2018 13:19 20182018 5 17
// */
using System;
using MarkdownDeep.Model;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    public abstract class MdToXamlBlock : IBlock<string>
    {
        public ISpan<string>[] Spans { get; protected set; }

        virtual public void FromSpan(ISpan<string> span)
        {
            Spans = new ISpan<string>[] { span };
        }

        public abstract string Render();
    }
}
