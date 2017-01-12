using System;

namespace MarkdownDeep.Rendering.Markdown
{
	public class Quote : IMDNode {

		IMDNode inner;
		public Quote(IMDNode inner)
		{
			this.inner = inner;
		}
		public string Prefix { get; set; } = "> ";
		public string Render()
		{
			return Prefix +
				string.Join ("\n" + Prefix, 
					inner.Render ().Split ('\n'));
		}
	}
}

