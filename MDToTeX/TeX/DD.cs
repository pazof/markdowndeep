using System;

namespace MarkdownDeep.Rendering.TeX
{
	public class DD : IMDNode {

		IMDNode inner;
		public DD(IMDNode inner)
		{
			this.inner = inner;
		}

		public int Width { get; set; } = 3;

		public string Render()
		{
			var innerTxt = inner.Render ().Replace('\n',' ').Substring(0,Width);
			return innerTxt.PadLeft(Width);
		}
	}
}

