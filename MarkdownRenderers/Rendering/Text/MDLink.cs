// // MDImage.cs
// /*
// Paul Schneider paul@pschneider.fr 17/05/2018 18:12 20182018 5 17
// */
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text
{
    public class MDLink : ISpan<string>
    {
        public MDLink()
        {
        }

        public virtual string Text
        {
            get; set;
        }

        public virtual string Title
        {
            get; set;
        }

        public string HRef { get; set; }

        public TextStyle Style { get; set; }

        public int Start { get; set; }

        public int Length { get; set; }

        public virtual string Render()
        {
            throw new System.NotImplementedException();
        }
    }
}
