using MarkdownDeep.Rendering.Abstract;
namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    public class CodeBlock<S> : MdToXamlBlock<S>
        where S : ISpan
    {
        private string[] lines;
        XmlRenderer xmlRenderer;
        public CodeBlock(string[] lines, string lang)
        {
            this.lines = lines;
            xmlRenderer = new XmlRenderer("RichTextArea",null);
            if (lang!=null)
                xmlRenderer.Parameters.Add("Tag", lang);
        }

        public override string GetRenderer()
        {
            return xmlRenderer.RenderBlocks(lines);
        }
    }
}
