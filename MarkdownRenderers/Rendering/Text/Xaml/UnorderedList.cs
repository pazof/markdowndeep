using System;
using System.Text;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    public class UnorderedList : MdToXamlBlock {

        public UnorderedList( ISpan<string> [] items )
		{
			this.Items = items;
		}

		public override string Render()
		{
			StringBuilder sb = new StringBuilder();

            foreach (ISpan<string> item in Items) {
				sb.AppendLine(item.Render());
			}
			return sb.ToString();
		}
	}
}

