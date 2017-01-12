using System;

namespace MarkdownDeep.Rendering.Markdown
{
	public class Paragraph : IMDNode {

		IMDNode inner;
		public Paragraph(IMDNode inner)
		{
			this.inner = inner;
		}
		public string Render()
		{
			string data = inner.Render ();
			if (string.IsNullOrWhiteSpace (data))
				return "";
			return data.TrimEnd('\n') + '\n';
		}
	}
}

