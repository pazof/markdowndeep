// // MDHeader.cs
// /*
// Paul Schneider paul@pschneider.fr 18/05/2018 00:29 20182018 5 18
// */
using System;
using System.Collections.Generic;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text
{
    public class MDHeader : MDBlock
    {
        public HeaderLevel Level { get;  set; }
        public MDHeader(HeaderLevel level, params ISpan<string>[] items)
        {
            Level = level;
            Items = items;
        }
    }
}
