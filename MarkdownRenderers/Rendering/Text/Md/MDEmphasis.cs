using System;
using System.Linq;
using MarkdownDeep.Model;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text.Md
{
    public class MDEmphasis : MDSpan {
        ISpan<string> [] parts;

        public MDEmphasis(ISpan<string> [] parts) 
        {
            this.parts = parts;
        }

        public override string Render() {
            return "*" + string.Join (" ", parts.Select
                (line => line.Render()))+ "*";
        }

    }
}

