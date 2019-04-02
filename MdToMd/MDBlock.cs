using System;
using System.Collections.Generic;
using System.Linq;
using MarkdownDeep.Rendering.Abstract;
using System.Text;

namespace MarkdownAVToXaml.Rendering.Text.Md
{
    public class MDBlock : List<MDSpan>, IBlock {


        public virtual string Prefix { get;  set; } = "";
        public string Separator { get;  set; } = "\n";
        public TextStyle Style { get ; set; }

        public int Start => throw new NotImplementedException();

        public int Length => throw new NotImplementedException();

     

        /// <summary>
        /// Froms the span.
        /// 
        /// </summary>
        /// <param name="span">Span.</param>
		public virtual void FromSpan(params MDSpan []spans)
        {
            AddRange(spans);
        }

        public virtual void FromFirstRow(MDSpan span)
        {
            Add(span);
        }


        public virtual string GetRenderer()
        {
            StringBuilder sb = new
                StringBuilder();
            foreach (var item in this)
            {
                sb.AppendLine(item.GetRenderer());
            }
            return sb.ToString();
        }
    }
}

