// // MDHeader.cs
// /*
// Paul Schneider paul@pschneider.fr 18/05/2018 00:29 20182018 5 18
// */
using System;
using System.Collections.Generic;
using MarkdownDeep.Rendering.Abstract;
using System.Linq;

namespace MarkdownAVToXaml.Rendering.Text.Md
{
    public class MDHeader : MDBlock
    {
        public HeaderLevel Level { get;  set; }
        public MDHeader(HeaderLevel level, params ISpan[] items)
        {
            Level = level;
            throw new NotImplementedException();
        }
    }
}
