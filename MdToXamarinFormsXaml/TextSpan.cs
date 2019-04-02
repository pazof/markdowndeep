// // TextSpan.cs
// /*
// Paul Schneider paul@pschneider.fr 02/04/2019 17:10 20192019 4 2
// */
using System;
using MarkdownDeep.Rendering.Abstract;
namespace MdToEtoXamarinFormsXaml
{
    public class TextSpan : ISpan
    {
        public TextSpan()
        {
        }

        public TextStyle Style { get; set; }

        public int Start { get; set; }

        public int Length { get; set; }

        public string Text { get; set; }

        public string GetRenderer()
        {
            return $"<span Text=\"{Text}\" Style=\"{Style}\" ></span>";
        }
    }
}
