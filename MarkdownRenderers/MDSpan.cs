// // MDSpan.cs
// /*
// Paul Schneider paul@pschneider.fr 02/04/2019 14:49 20192019 4 2
// */
using System;
using MarkdownDeep.Rendering.Abstract;
namespace MarkdownAVToXaml
{
    public abstract class MDSpan : ISpan
    {
        public MDSpan()
        {
        }

        public TextStyle Style { get ; set ; }

        public string Text { get; set; }

        public string HRef { get; set; }

        public string Title { get; set; }

        public int Start { get; set; }

        public int Length { get; set; }

        public abstract string GetRenderer();
    }
}
