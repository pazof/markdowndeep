using System;
using System.Collections.Generic;
using System.Text;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text.Md
{
	public class OrderedList : List<ListItem>
       
    {
        public void FromFirstRow(ListItem span)
        {
            throw new NotImplementedException();
        }

        public string Render()
		{
			int i = 0;
			int plen = Count.ToString ().Length;
			StringBuilder sb = new StringBuilder();

			foreach (ListItem item in this) {
				i++;
				item.Prefix = $"{i}."+new string(' ',plen);
				item.ListPrefix = new string(' ',plen+1);
				sb.AppendLine(item.GetRenderer());
			}
			return sb.ToString();
		}

    }
}

