using System;
using MarkdownDeep.Model;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text.Md
{
    public class MDText : MDBlock {

		public string Text { get; set; }
		public Func<MDText,string> Rendering { get; set; } = r => r.Text;

		public string Display { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Meta { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public MediaType SourceType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsMonospace { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IMDNode[] Children { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public HeaderLevel IsHeader { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Depth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ListStyle IsList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public TextStyle Style { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Start => throw new NotImplementedException();

        public int Length => throw new NotImplementedException();

        public string Render()
        {
            return this.Rendering(this);
        }

        public MDText(string text)
        {
            this.Text = text;
        }

        public bool IsBlock()
        {
            return Text.Contains("\n");
        }

        public string GetInnerText()
        {
            return this.Text;
        }
	}
}

