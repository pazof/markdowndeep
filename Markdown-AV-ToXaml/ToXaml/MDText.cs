﻿using System;

namespace MarkdownDeep.Rendering.Markdown
{
	public class MDText {

		public string Text { get; set; }
		public Func<MDText,string> Rendering { get; set; } = r => r.Text;
		public string Render()
		{
			var res = Rendering(this);
			return res;
		}

		public MDText(string text)
		{
			this.Text = text;
		}

		public bool IsBlock()
		{
			return Text.Contains ("\n");
		}
	}
}
