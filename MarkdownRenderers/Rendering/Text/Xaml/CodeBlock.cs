namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
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
                xmlRenderer.Parameters.Add("TextReplacements", lang);
        }

        public override string Render()
        {
            return xmlRenderer.Render(string.Join("\n", lines));
        }
    }
}