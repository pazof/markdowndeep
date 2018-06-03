using System;
using System.Linq;
using MarkdownDeep.Model;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text.Md
{
    public class MDBlock : IBlock<string> {

        public ISpan<string>  [] Items { get; set; }

        public virtual string Prefix { get;  set; } = "";
        public string Separator { get;  set; } = "\n";
        public MDBlock()
        {
            Items = new ISpan<string>[0];
        }

		public MDBlock(params string[] text)
		{
            Items = text.Select(t=> new MDText (t)).ToArray();
		}

        public MDBlock (params ISpan<string> [] nodes)
		{
            Items = nodes;
		}

		public virtual string Render()
		{
            return string.Join( Separator, 
                Items.Select(
                    item => Prefix + item.Render()));
		}

        /// <summary>
        /// Froms the span.
        /// 
        /// </summary>
        /// <param name="span">Span.</param>
		public void FromSpan(params ISpan<string> []spans)
        {
            Items = spans;
        }

        public void FromSpan(ISpan<string> span)
        {
            FromSpan(new ISpan<string>[] { span });
        }

	}
}

