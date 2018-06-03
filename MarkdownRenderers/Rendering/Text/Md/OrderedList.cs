using System;
using System.Text;

namespace MarkdownAVToXaml.Rendering.Text.Md
{
	public class OrderedList : MDBlock {
        public override string Render()
		{
			int i = 0;
			int plen = Items.Length.ToString ().Length;
			StringBuilder sb = new StringBuilder();

			foreach (ListItem item in Items) {
				i++;
				item.Prefix = $"{i}."+new string(' ',plen);
				item.ListPrefix = new string(' ',plen+1);
				sb.AppendLine(item.Render());
			}
			return sb.ToString();
		}
	}
}

