using System;
using System.Collections.Generic;
using System.Linq;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text.Md
{
	public class ListItem : MDBlock {
        IEnumerable<MDSpan> inner;
        public ListItem(IEnumerable<MDSpan>  inner)
		{
			this.inner = inner;
		}
        public override string Prefix { get; set; } = "* ";
		public string ListPrefix { get; set; } = " ";
		public override string GetRenderer()
		{
            var toRender = inner.Select( i => i.GetRenderer ()).Where(s=>!string.IsNullOrWhiteSpace(s));

			return Prefix + string.Join ("\n" + ListPrefix, toRender);
		}
	}
}

