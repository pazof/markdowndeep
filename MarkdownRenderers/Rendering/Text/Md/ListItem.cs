﻿using System;
using System.Linq;

namespace MarkdownAVToXaml.Rendering.Text.Md
{
	public class ListItem : MDBlock {
        MDBlock inner;
        public ListItem(MDBlock inner)
		{
			this.inner = inner;
		}
        public override string Prefix { get; set; } = "* ";
		public string ListPrefix { get; set; } = " ";
		public override string Render()
		{
			var toRender = inner.Render ().Split ('\n').Where(s=>!string.IsNullOrWhiteSpace(s));

			return Prefix + string.Join ("\n" + ListPrefix, toRender);
		}
	}
}
