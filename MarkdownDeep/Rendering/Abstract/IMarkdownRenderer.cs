using System;
using System.Collections.Generic;

namespace MarkdownDeep.Rendering.Abstract
{
    public interface IMarkdownRenderer<TFinal,TSpan,TBlock> 
        where TSpan : ISpan<TFinal> 
        where TBlock : IBlock<TFinal>
	{
		/// <summary>
		/// Paragraph the specified inner.
		/// </summary>
		/// <param name="inner">Inner.</param>
        IRenderer<string> Paragraph (ISpan<TFinal> inner);
		/// <summary>
		/// Aggregates the span.
		/// </summary>
		/// <returns>The span.</returns>
		/// <param name="children">Children.</param>
        ISpan<TFinal> AggregateSpan (IEnumerable<ISpan<TFinal>> children); 

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
        IRenderer<TFinal>  Header (IEnumerable<IRenderer<TFinal>> inner, HeaderLevel level);
		/// <summary>
		/// Lists the item.
		/// </summary>
		/// <returns>The item.</returns>
		/// <param name="inner">Inner.</param>
        IRenderer<TFinal>  ListItem (IEnumerable<IRenderer<TFinal>> inner);

        IRenderer<TFinal> TableCell(IEnumerable<IRenderer<TFinal>> inner);
		/// <summary>
		/// Unorders the list.
		/// </summary>
		/// <returns>The list.</returns>
		/// <param name="lis">Lis.</param>
        IRenderer<TFinal>  UnorderedList(IEnumerable<IRenderer<TFinal>> list);
		/// <summary>
		/// Orders the list.
		/// </summary>
		/// <returns>The list.</returns>
		/// <param name="lis">Lis.</param>
        IRenderer<TFinal> OrderedList (IEnumerable<IRenderer<TFinal>> list);
		/// <summary>
		/// Strong the specified inner.
		/// </summary>
		/// <param name="inner">Inner.</param>
        void Strong (IEnumerable<TSpan> inner);
        /// <summary>
        /// Emphasis the specified inner.
        /// </summary>
        /// <param name="existant">inner.</param>
        void Emphasis(IEnumerable<TSpan> TSpan);
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
        TSpan Audio (string href, string alt, string title);
		/// <summary>
		/// Video the specified href, alt and title.
		/// </summary>
		/// <param name="href">Href.</param>
		/// <param name="alt">Alternate.</param>
		/// <param name="title">Title.</param>
        TSpan Video (string href, string alt, string title);
		/// <summary>
		/// Image the specified href, alt and title.
		/// </summary>
		/// <param name="href">Href.</param>
		/// <param name="alt">Alternate.</param>
		/// <param name="title">Title.</param>
        TSpan Image (string href, string alt, string title);
		/// <summary>
		/// Code the specified source.
		/// </summary>
		/// <param name="source">Source.</param>
        ISpan<TFinal> Code (string source, string lang);

        ISpan<TFinal> CodeBlock (string[] lines, string lang);
		/// <summary>
		/// Quote the specified inner.
		/// </summary>
		/// <param name="inner">Inner.</param>
        TBlock Quote (IEnumerable<IRenderer<TFinal>> inner);
        TBlock Html(IEnumerable<IRenderer<TFinal>> inner);

		/// <summary>
		/// Emphasis the specified inner.
		/// </summary>
		/// <param name="existant">inner.</param>
        TSpan Strike (TSpan TSpan);
		/// <summary>
		/// Emphasis the specified inner.
		/// </summary>
		/// <param name="inner">inner.</param>
        TSpan Underline (TSpan inner);

		/// <summary>
		/// Blank this instance.
		/// </summary>
        void AddBlankTo (TSpan span);
		/// <summary>
		/// D the specified inner.
		/// </summary>
		/// <param name="inner">Inner.</param>
        TBlock DT (IEnumerable<IRenderer<TFinal>> inner);
        TBlock DL(IEnumerable<IRenderer<TFinal>> inner);
		/// <summary>
		/// D the specified inner.
		/// </summary>
		/// <param name="inner">Inner.</param>
        TBlock DD (IEnumerable<IRenderer<TFinal>> inner);

        TBlock Table (TBlock head, TBlock body);

        TBlock TableHeader (string[] headers);

        IRenderer<TFinal> TableRow (IEnumerable<IRenderer<TFinal>> cells);

        TBlock TableBody (IEnumerable<IRenderer<TFinal>>  rows);

        TBlock FootNote (IEnumerable<IRenderer<TFinal>> inner, string id);

	}

}
