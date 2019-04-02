// // IMarkdownBlockRenderer.cs
// /*
// Paul Schneider paul@pschneider.fr 15/05/2018 15:57 20182018 5 15
// */
using System;
using System.Collections.Generic;

namespace MarkdownDeep.Rendering.Abstract
{
    public interface IMarkdownBlockRenderer<T, TBlock, S> 
        where TBlock: IBlock
        where S : ISpan
    {
        /// <summary>
        /// Displays the specified children on a same line.
        /// </summary>
        /// <returns>The aggregate.</returns>
        /// <param name="children">Children.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        TBlock Aggregate(IEnumerable<TBlock> children);

        /// <summary>
        /// Adds a visual separator to the end of this block.
        /// </summary>
        /// <returns>The separator.</returns>
		TBlock Ruler();

        /// <summary>
        /// Adds a new line to this block.
        /// </summary>
        /// <returns>The separator.</returns>
        TBlock NewLine(IEnumerable<S> words);

        TBlock Abbreviation(string id, string abbreviation);
	}
}
