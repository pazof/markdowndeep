﻿// // IMarkdownBlockRenderer.cs
// /*
// Paul Schneider paul@pschneider.fr 15/05/2018 15:57 20182018 5 15
// */
using System;
using System.Collections.Generic;

namespace MarkdownDeep.Rendering.Abstract
{
    public interface IMarkdownBlockRenderer<T, TBlock> : IMarkdownRenderer<T, TBlock>
        where TBlock: IBlock<T>
    {
        /// <summary>
        /// Displays the specified children on a same line.
        /// </summary>
        /// <returns>The aggregate.</returns>
        /// <param name="children">Children.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        IRenderer<T> Aggregate(IEnumerable<TBlock> children);

        /// <summary>
        /// Separator this instance.
        /// </summary>
        /// <returns>The separator.</returns>
		TBlock Separator();

        /// <summary>
        /// .
        /// </summary>
        /// <returns>The separator.</returns>
        TBlock NewLine(IEnumerable<TBlock> words);
	}
}
