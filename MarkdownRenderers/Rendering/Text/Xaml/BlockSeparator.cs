// // BlockSeparator.cs
// /*
// Paul Schneider paul@pschneider.fr 04/06/2018 01:11 20182018 6 4
// */
using System;

namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    public class BlockSeparator : MdToXamlBlock
    {
        public int Height { get; set; } = 4;

        public override string Render()
        {
            string space = $"<StackLayout Height=\"{Height}\" BackgroundColor=\"Gray\"" +
                " HorizontalContentAlignment=\"Stretch\" ></StackLayout>";
            return space;
        }
    }
}
