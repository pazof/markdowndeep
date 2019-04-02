using System;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text.Md
{
    public class MDText : MDBlock {

		public string Text { get; set; }
        public MDText(string text)
        {
            this.Text = text;
        }
	}
}

