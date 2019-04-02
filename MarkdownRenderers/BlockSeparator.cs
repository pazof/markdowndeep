// // BlockSeparator.cs
// /*
// Paul Schneider paul@pschneider.fr 04/06/2018 01:11 20182018 6 4
// */
using System;

namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    public class BlockSeparator : MdToXamlBlock<MDSpan>
    {
        public int Height { get; set; } = 1;
        public string Color { get; set; } = "Gray";

        public override string GetRenderer()
        {
            string space = $"<StackLayout Height=\"{Height}\" BackgroundColor=\"{Color}\"></StackLayout>";
            return space;
        }
    }
}
