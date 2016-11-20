using System;
using System.Linq;

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
			var toRender = inner.Render ().Split ('\n').Where(s=>!string.IsNullOrWhiteSpace(s));

			return Prefix + string.Join ("\n" + ListPrefix, toRender);
		}
	}
}

