using System;
using System.Collections.Generic;
using System.Text;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text.Md
{
    public class Paragraph : MDBlock {
        List<MDSpan> spans;
        public override void FromFirstRow(MDSpan span)
        {
            spans = new List<MDSpan>();
            spans.Add(span);
        }

	}
}

