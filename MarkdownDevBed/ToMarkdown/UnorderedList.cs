using System;
using System.Text;

namespace MarkdownDeep.Rendering.Markdown
{
	public class UnorderedList : IMDNode {
		IMDNode [] items;
		public UnorderedList( IMDNode [] items )
		{
			this.items = items;
		}
		public string Render()
		{
			StringBuilder sb = new StringBuilder();

			foreach (ListItem item in items) {
				sb.AppendLine(item.Render());
			}
			return sb.ToString();
		}
	}
}

