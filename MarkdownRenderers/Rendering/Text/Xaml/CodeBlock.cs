namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    
    public class CodeNode  : MdToXamlBlock
    {
        private string[] lines;
        private string lang;
        XmlRenderer xmlRenderer;
        public CodeNode(string[] lines, string lang)
        {
            this.lines = lines;
            this.lang = lang;
            xmlRenderer = new XmlRenderer("RichTextArea");
            if (lang != null)
                xmlRenderer.Parameters.Add("Tag", lang);
        }

        public override string Render()
        {
            return xmlRenderer.RenderRaw(string.Join("\n", lines));
        }
    }

    public class CodeBlock : MdToXamlBlock
    {
        private string[] lines;
        private string lang;
        XmlRenderer xmlRenderer;
        public CodeBlock(string[] lines, string lang)
        {
            this.lines = lines;
            this.lang = lang;
            xmlRenderer = new XmlRenderer("RichTextArea");
            if (lang!=null)
                xmlRenderer.Parameters.Add("Tag", lang);
        }

        public override string Render()
        {
            return xmlRenderer.RenderRaw(string.Join("\n", lines));
        }
    }
}