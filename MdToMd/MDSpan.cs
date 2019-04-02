// // MdSpan.cs
// /*
// Paul Schneider paul@pschneider.fr 17/05/2018 13:28 20182018 5 17
// */
using System;
using MarkdownDeep.Rendering;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text.Md
{

    public interface IMDSpanFactory 
    {
        TSpan CreateSpanFromISpan<TSpan>(ISpan span) where TSpan : ISpan;
    }

    public interface IMDBlockFactory
    {
        TBlock CreateSpanFromIBlock<TBlock>(ISpan span) where TBlock : IBlock;
    }

    public class MDSpan : ISpan
    {
        public MDSpan()
        {
        }

        public TextStyle Style { get; set; }

        public int Start { get; set; }

        public int Length { get; set; }

        public Func<ISpan,string> RenderAction { get; set; }
        
        public string Text { get; set; }

        public virtual string GetRenderer() {
            return RenderAction(this);
        }
    }
}
