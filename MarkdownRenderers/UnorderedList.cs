using System;
using System.Collections.Generic;
using System.Text;
using MarkdownDeep.Rendering.Abstract;
using System.Linq;

namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    public class UnorderedList : MdToXamlBlock<MDSpan> {
        private MdToXamlBlock<MDSpan>[] list;
        public bool IsBlockList { get; }
     
        public UnorderedList(MdToXamlBlock<MDSpan>[] list)
        {
            this.list = list;
            IsBlockList = true;
        }

        public  override string ToString()
        {
            if (IsBlockList)
                return $"[Unordered Block list :{list.Length}]";
            else 
                return $"[Unordered span list :{Count}]";
        }

        public override string GetRenderer()
        {
            StringBuilder sb = new StringBuilder();
            if (IsBlockList)
                foreach (MdToXamlBlock<MDSpan> item in list)
                {
                    sb.AppendLine(item.GetRenderer());
                }
            else
                foreach (MDSpan item in this)
                {
                    sb.AppendLine(item.GetRenderer());
                }
            return sb.ToString();
        }
    }
}

