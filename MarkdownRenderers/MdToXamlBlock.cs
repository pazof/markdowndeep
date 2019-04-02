// // MdToXamlBlock.cs
// /*
// Paul Schneider paul@pschneider.fr 17/05/2018 13:19 20182018 5 17
// */
using System;
using System.Collections;
using System.Collections.Generic;
using MarkdownDeep.Model;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    [Serializable]
    public abstract class MdToXamlBlock<TSpan> : 
        List<TSpan>,
     IHeaderStyled, 
        IBlock
        where TSpan : ISpan

    {

        public int Start { get; set; }

        public int Length { get; set; }

        public HeaderLevel Level { get; set; }

        public abstract string GetRenderer();
    }
}
