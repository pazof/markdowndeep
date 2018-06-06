// // MdToXamlBlock.cs
// /*
// Paul Schneider paul@pschneider.fr 17/05/2018 13:19 20182018 5 17
// */
using System;
using MarkdownDeep.Model;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    [Serializable]
    public abstract class MdToXamlBlock : IBlock<string>
    {
        public IRenderer<string>[] Spans { get; protected set; }

        public TextStyle Style { get ; set; }

        public int Start { get; set; }

        public int Length { get; set; }

        public void FromSpan (IRenderer<string> span)
        {
            Spans = new IRenderer<string>[] { span };
        }

        public abstract string Render();
    }
}
