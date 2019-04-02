using System;
using System.Collections.Generic;

namespace MarkdownDeep.Rendering.Abstract
{
    public interface IMarkdownRenderer<TFinal,TBlock,TSpan> 
        : IMarkdownBlockRenderer<TFinal, TBlock, TSpan>
         where TBlock : IBlock
        where TSpan : ISpan
	{
        /// <summary>
        /// Paragraph the specified inner.
        /// </summary>
        /// <param name="inner">Inner.</param>
        TBlock Paragraph (IEnumerable<TBlock> inner);

        /// <summary>
        /// Render as text the specified txt.
        /// </summary>
        /// <param name="txt">Text.</param>
        TSpan Text (string txt, int start, int len);
        /// <summary>
        /// Header the specified inner at level.
        /// </summary>
        /// <param name="inner">Inner.</param>
        /// <param name="level">Level.</param>
        TBlock Header (IEnumerable<TBlock> inner, HeaderLevel level);
		/// <summary>
		/// Lists the item.
		/// </summary>
		/// <returns>The item.</returns>
		/// <param name="inner">Inner.</param>
        TBlock  ListItem (IEnumerable<TBlock> inner);

        TBlock TableCell(IEnumerable<TBlock> inner);
		/// <summary>
		/// Unorders the list.
		/// </summary>
		/// <returns>The list.</returns>
		/// <param name="list">List.</param>
        TBlock  UnorderedList(IEnumerable<TBlock> list);
		/// <summary>
		/// Orders the list.
		/// </summary>
		/// <returns>The list.</returns>
		/// <param name="list">List.</param>
        TBlock OrderedList (IEnumerable<TBlock> list);
		
        /// <summary>
        /// Link the specified inner, href and title.
        /// </summary>
        /// <param name="inner">Inner.</param>
        /// <param name="href">Href.</param>
        /// <param name="title">Title.</param>
        TSpan Link (string text, string href, string title);
		/// <summary>
		/// Audio the specified href, alt and title.
		/// </summary>
		/// <param name="href">Href.</param>
		/// <param name="alt">Alternate.</param>
		/// <param name="title">Title.</param>
        TBlock Audio (string href, string alt, string title);
		/// <summary>
		/// Video the specified href, alt and title.
		/// </summary>
		/// <param name="href">Href.</param>
		/// <param name="alt">Alternate.</param>
		/// <param name="title">Title.</param>
        TBlock Video (string href, string alt, string title);
		/// <summary>
		/// Image the specified href, alt and title.
		/// </summary>
		/// <param name="href">Href.</param>
		/// <param name="alt">Alternate.</param>
		/// <param name="title">Title.</param>
        TBlock Image (string href, string alt, string title);
		/// <summary>
		/// Code the specified source.
		/// </summary>
		/// <param name="source">Source.</param>
        TSpan Code (string source, string lang);

        TBlock CodeBlock (string[] lines, string lang);
		/// <summary>
		/// Quote the specified inner.
		/// </summary>
		/// <param name="inner">Inner.</param>
        TBlock Quote (IEnumerable<TBlock> inner);
        TBlock Html(IEnumerable<TBlock> inner);


		/// <summary>
		/// D the specified inner.
		/// </summary>
		/// <param name="inner">Inner.</param>
        TBlock DT (IEnumerable<TBlock> inner);
        TBlock DL(IEnumerable<TBlock> inner);
		/// <summary>
		/// D the specified inner.
		/// </summary>
		/// <param name="inner">Inner.</param>
        TBlock DD (IEnumerable<TBlock> inner);

        TBlock Table (TBlock head, TBlock body);

        TBlock TableHeader (string[] headers);

        TBlock TableRow (IEnumerable<TBlock> cells);

        TBlock TableBody (IEnumerable<TBlock> rows);

        TBlock FootNote (IEnumerable<TBlock> inner, string id);

	}

}
