// // IStackRenderer.cs
// /*
// Paul Schneider paul@pschneider.fr 15/05/2018 15:53 20182018 5 15
// */
using System;
namespace MarkdownDeep.Rendering.Abstract
{
    public interface IMarkdownDocumentRenderer<T,U,TBlock> : IMarkdownBlockRenderer<T, U, TBlock>
        where U:ISpan<T> where TBlock:IBlock<T>
    {
        /// <summary>s
        /// Aggregates the final block.
        /// (TODO Let's say "Document")
        /// </summary>
        /// <returns>The final block.</returns>
        /// <param name="children">Children.</param>
        TBlock AggregateFinalBlock (params TBlock [] children); 
    }
}
