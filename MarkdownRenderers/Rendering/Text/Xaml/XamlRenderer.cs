
using MarkdownDeep;
using MarkdownDeep.Rendering;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
	/// <summary>
	///  markdown renderer to Xaml
	/// </summary>

    public class XamlRenderer : MarkdownRendererToString<MdToXamlNode, MdToXamlBlock>
    {
        public XamlRenderer()
        {
        }

        public override void AddBlankTo(MdToXamlNode span)
        {
            throw new System.NotImplementedException();
        }

        public override void AddNewLineTo(MdToXamlNode span)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlNode Aggregate<T>(IRenderer<T>[] children)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlNode Audio(string href, string alt, string title)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlNode Code(string source)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock CodeBlock(string[] lines, string lang)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock DD(MdToXamlNode inner)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock DT(MdToXamlBlock inner)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlNode Emphasis(MdToXamlNode[] TSpan)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock FootNote(MdToXamlNode inner, string id)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock Header(MdToXamlBlock inner, HeaderLevel level)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlNode Image(string href, string alt, string title)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlNode Link(string text, string href, string title)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock ListItem(MdToXamlBlock inner)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock ListItem(MdToXamlNode inner)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock OrderedList(MdToXamlBlock[] list)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock Paragraph(MdToXamlNode inner)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock Quote(MdToXamlBlock inner)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock Separator()
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlNode Strike(MdToXamlNode TSpan)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlNode Strong(MdToXamlNode[] inner)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock Table(MdToXamlBlock head, MdToXamlBlock body)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock TableBody(MdToXamlBlock[] rows)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock TableHeader(string[] headers)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock TableRow(MdToXamlBlock[] cells)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlNode Text(string txt, int start, int len)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlNode Underline(MdToXamlNode inner)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock UnorderedList(MdToXamlBlock[] list)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlNode Video(string href, string alt, string title)
        {
            throw new System.NotImplementedException();
        }
    }
}

