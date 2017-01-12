using System;

namespace MarkdownDeep.Rendering.Markdown
{
	public class DT : IMDNode {

		IMDNode inner;
		public DT(IMDNode inner)
		{
			this.inner = inner;
		}

		public int Width { get; set; } = 3;

		public string Render()
		{
			var innerTxt = inner.Render ().Replace('\n',' ').Substring(0,Width);
			return innerTxt.PadRight(Width);
		}
	}
}

