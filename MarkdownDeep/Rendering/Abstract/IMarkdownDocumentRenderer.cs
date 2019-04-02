// // IStackRenderer.cs
// /*
// Paul Schneider paul@pschneider.fr 15/05/2018 15:53 20182018 5 15
// */
using System;
using System.Collections.Generic;

namespace MarkdownDeep.Rendering.Abstract
{
    public interface IMarkdownDocumentRenderer<T, TBlock, S> 
    : IMarkdownRenderer<T, TBlock, S>
        where TBlock:IBlock
        where S : ISpan
    {
        /// <summary>s
        /// Aggregates the final block.
        /// (TODO Let's say "Document")
        /// </summary>
        /// <returns>The final block.</returns>
        /// <param name="children">Children.</param>
        T  AggregateFinalBlock (IEnumerable<TBlock> children); 
    }
}
