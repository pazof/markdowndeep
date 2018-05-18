using System;
using System.Collections.Generic;
using System.Text;
using MarkdownDeep.Model;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text
{
    public class Paragraph : MDBlock {
        List<MDSpan> spans;
        public void FromSpan(MDSpan span)
        {
            spans = new List<MDSpan>();
            spans.Add(span);
        }

	}
}

