﻿using System;

namespace MarkdownDevBed
{
	public class MDText : IMDNode {

		public string Text { get; set; }
		public Func<MDText,string> Rendering { get; set; } = r => r.Text;
		public string Render()
		{
			return Rendering(this);
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
