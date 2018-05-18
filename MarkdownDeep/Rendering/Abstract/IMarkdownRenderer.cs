using System;
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
        TBlock Paragraph (TSpan inner);
		/// <summary>
		/// Aggregates the span.
		/// </summary>
		/// <returns>The span.</returns>
		/// <param name="children">Children.</param>
        TSpan AggregateSpan (TSpan [] children); 

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
		TBlock Header (TBlock inner, HeaderLevel level);
		/// <summary>
		/// Lists the item.
		/// </summary>
		/// <returns>The item.</returns>
		/// <param name="inner">Inner.</param>
        TBlock ListItem (TBlock inner);
        TBlock ListItem(TSpan inner);
		/// <summary>
		/// Unorders the list.
		/// </summary>
		/// <returns>The list.</returns>
		/// <param name="lis">Lis.</param>
        TBlock UnorderedList(TBlock[] list);
		/// <summary>
		/// Orders the list.
		/// </summary>
		/// <returns>The list.</returns>
		/// <param name="lis">Lis.</param>
        TBlock OrderedList (TBlock[] list);
		/// <summary>
		/// Strong the specified inner.
		/// </summary>
		/// <param name="inner">Inner.</param>
        TSpan Strong (TSpan [] inner);
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
        TSpan Code (string source);

        TBlock CodeBlock (string[] lines, string lang);
		/// <summary>
		/// Quote the specified inner.
		/// </summary>
		/// <param name="inner">Inner.</param>
        TBlock Quote (TBlock inner);
		/// <summary>
		/// Renews the precedent.
		/// </summary>
		/// <returns>The precedent with a new line attribution.</returns>
		/// <param name="existent">precedent.</param>
        void AddNewLineTo(TSpan span);
		/// <summary>
		/// Emphasis the specified inner.
		/// </summary>
		/// <param name="existant">inner.</param>
        TSpan Emphasis (TSpan [] TSpan);
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
        TBlock DT (TBlock inner);
		/// <summary>
		/// D the specified inner.
		/// </summary>
		/// <param name="inner">Inner.</param>
        TBlock DD (TSpan inner);

        TBlock Table (TBlock head, TBlock body);

        TBlock TableHeader (string[] headers);

        TBlock TableRow (TBlock [] cells);

        TBlock TableBody (TBlock [] rows);

        TBlock FootNote (TSpan inner, string id);

	}

}
