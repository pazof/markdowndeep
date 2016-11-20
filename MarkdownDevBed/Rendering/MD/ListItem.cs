using System;

namespace MarkdownDevBed
{
	public class ListItem : IMDNode {
		IMDNode inner;
		public ListItem(IMDNode inner)
		{
			this.inner = inner;
		}
		public string Prefix { get; set; } = "* ";
		public string ListPrefix { get; set; } = "  ";
		public string Render()
		{
			return Prefix +
				string.Join ("\n" + ListPrefix, 
					inner.Render ().Split ('\n'));
		}
	}
}

