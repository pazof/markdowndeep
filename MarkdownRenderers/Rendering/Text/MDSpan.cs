// // MdSpan.cs
// /*
// Paul Schneider paul@pschneider.fr 17/05/2018 13:28 20182018 5 17
// */
using System;
using MarkdownDeep.Rendering;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text
{

    public interface IMDSpanFactory 
    {
        TSpan CreateSpanFromISpan<TSpan>(ISpan<string> span) where TSpan : ISpan<string>;
    }

    public interface IMDBlockFactory
    {
        TBlock CreateSpanFromIBlock<TBlock>(ISpan<string> span)where TBlock : IBlock<string>;
    }

    public class MDSpan : ISpan<string>
    {
        public TextStyle Style { get; set; }

        public int Start { get; set; }

        public int Length { get; set; }

        public Func<ISpan<string>,string> RenderAction { get; set; }

        public virtual string Render() {
            return RenderAction(this);
        }
    }
}
