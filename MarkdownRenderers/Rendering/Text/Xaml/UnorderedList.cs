using System;
using System.Collections.Generic;
using System.Text;
using MarkdownDeep.Rendering.Abstract;
using System.Linq;

namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    public class UnorderedList : MdToXamlBlock {
        private MdToXamlBlock[] list;
        public bool IsBlockList { get; }
        public UnorderedList( IEnumerable<IRenderer<string>> items )
		{
            Spans = items.ToArray();
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
        public override string ToString()
        {
            if (IsBlockList)
                return $"[Unordered list {Style} Block {list.Length}]";
            else 
                return $"[Unordered list {Style} Spans:{Spans.Count()}]";
        }
    }
}

