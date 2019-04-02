namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    public class CodeNode<S> : MDSpan
    {
        private string[] lines;
        XmlRenderer xmlRenderer;
        public CodeNode(string[] lines, string lang)
        {
            this.lines = lines;
            xmlRenderer = new XmlRenderer("RichTextArea",null);
            if (lang != null)
                xmlRenderer.Parameters.Add("Tag", lang);
        }

        public override string GetRenderer()
        {
            return xmlRenderer.RenderBlocks(lines);
        }
    }
}
