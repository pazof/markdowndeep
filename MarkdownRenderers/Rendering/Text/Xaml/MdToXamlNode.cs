using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using MarkdownDeep;
using MarkdownDeep.Model;
using MarkdownDeep.Rendering.Abstract;
using System.Runtime.Serialization;

namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    [Serializable]
    public abstract class MdToXamlNode : ISpan<string>, ITextStyleOwner, IHeaderStyleOwner
    {
        public HeaderLevel Level { get; set; }

        public TextStyle Style { get; set; }

        public int Start { get; protected set; }

        public int Length { get; protected set; }

        public abstract string Render();
    }

}

