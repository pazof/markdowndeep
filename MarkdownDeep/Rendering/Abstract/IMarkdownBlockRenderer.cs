// // IMarkdownBlockRenderer.cs
// /*
// Paul Schneider paul@pschneider.fr 15/05/2018 15:57 20182018 5 15
// */
using System;
namespace MarkdownDeep.Rendering.Abstract
{
    public interface IMarkdownBlockRenderer<T,U,TBlock> : IMarkdownRenderer<T, U, TBlock>
        where U:ISpan<T> where TBlock: IBlock<T>
    {
        /// <summary>
        /// Aggregate the specified children.
        /// </summary>
        /// <returns>The aggregate.</returns>
        /// <param name="children">Children.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        TBlock Aggregate(TBlock[] children);

        /// <summary>
        /// Separator this instance.
        /// </summary>
        /// <returns>The separator.</returns>
		TBlock Separator();
	}
}
