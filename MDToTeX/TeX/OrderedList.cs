using System;
using System.Text;

namespace MarkdownDeep.Rendering.TeX
{
	public class OrderedList : IMDNode {
		IMDNode [] items;
		public OrderedList( IMDNode [] items )
		{
			this.items = items;
		}
		public string Render()
		{
			int i = 0;
			int plen = items.Length.ToString ().Length;
			StringBuilder sb = new StringBuilder();

			foreach (ListItem item in items) {
				i++;
				item.Prefix = $"{i}."+new string(' ',plen);
				item.ListPrefix = new string(' ',plen+1);
				sb.AppendLine(item.Render());
			}
			return sb.ToString();
		}
	}
}

