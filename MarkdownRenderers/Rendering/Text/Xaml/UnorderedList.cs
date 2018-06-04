using System;
using System.Text;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    public class UnorderedList : MdToXamlBlock {
        private MdToXamlBlock[] list;
        public bool IsBlockList { get; }
        public UnorderedList( ISpan<string> [] items )
		{
            Spans = items;
            IsBlockList = false;
		}

        public UnorderedList(MdToXamlBlock[] list)
        {
            this.list = list;
            IsBlockList = true;
        }

        public override string Render()
		{
			StringBuilder sb = new StringBuilder();
            if (IsBlockList)
                foreach (MdToXamlBlock item in list)
                {
                    sb.AppendLine(item.Render());
                }
                else 
            foreach (ISpan<string> item in Spans) {
				sb.AppendLine(item.Render());
			}
			return sb.ToString();
		}
	}
}

