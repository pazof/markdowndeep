using System;

namespace MarkdownDevBed
{
	public class Paragraph : IMDNode {

		IMDNode inner;
		public Paragraph(IMDNode inner)
		{
			this.inner = inner;
		}
		public string Render()
		{
			return inner.Render ().TrimEnd('\n') + '\n';
		}
	}
}

