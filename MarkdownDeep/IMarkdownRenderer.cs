using System;
namespace MarkdownDeep
{
	public enum HeaderLevel: int
	{
		H1 = 1, H2, H3, H4, H5, H6
	}

	public interface IMarkdownRenderer<T>

	{
		/// <summary>
		/// Paragraph the specified inner.
		/// </summary>
		/// <param name="inner">Inner.</param>
		T Paragraph (T inner);
		/// <summary>
		/// Aggregates the span.
		/// </summary>
		/// <returns>The span.</returns>
		/// <param name="children">Children.</param>
		T AggregateSpan (T [] children); 
		/// <summary>
		/// Aggregates the block.
		/// </summary>
		/// <returns>The block.</returns>
		/// <param name="children">Children.</param>
		T AggregateBlock (T [] children); 
		/// <summary>
		/// Render as text the specified txt.
		/// </summary>
		/// <param name="txt">Text.</param>
		T Text (string txt);
		/// <summary>
		/// Header the specified inner at level.
		/// </summary>
		/// <param name="inner">Inner.</param>
		/// <param name="level">Level.</param>
		T Header (T inner, HeaderLevel level);
		/// <summary>
		/// Lists the item.
		/// </summary>
		/// <returns>The item.</returns>
		/// <param name="inner">Inner.</param>
		T ListItem (T inner);
		/// <summary>
		/// Unorders the list.
		/// </summary>
		/// <returns>The list.</returns>
		/// <param name="lis">Lis.</param>
		T UnorderedList(T[] list);
		/// <summary>
		/// Orders the list.
		/// </summary>
		/// <returns>The list.</returns>
		/// <param name="lis">Lis.</param>
		T OrderedList (T[] list);
		/// <summary>
		/// Strong the specified inner.
		/// </summary>
		/// <param name="inner">Inner.</param>
		T Strong (T [] inner);
		/// <summary>
		/// Link the specified inner, href and title.
		/// </summary>
		/// <param name="inner">Inner.</param>
		/// <param name="href">Href.</param>
		/// <param name="title">Title.</param>
		T Link (T inner, string href, string title);
		/// <summary>
		/// Audio the specified href, alt and title.
		/// </summary>
		/// <param name="href">Href.</param>
		/// <param name="alt">Alternate.</param>
		/// <param name="title">Title.</param>
		T Audio (string href, string alt, string title);
		/// <summary>
		/// Video the specified href, alt and title.
		/// </summary>
		/// <param name="href">Href.</param>
		/// <param name="alt">Alternate.</param>
		/// <param name="title">Title.</param>
		T Video (string href, string alt, string title);
		/// <summary>
		/// Image the specified href, alt and title.
		/// </summary>
		/// <param name="href">Href.</param>
		/// <param name="alt">Alternate.</param>
		/// <param name="title">Title.</param>
		T Image (string href, string alt, string title);
		/// <summary>
		/// Code the specified source.
		/// </summary>
		/// <param name="source">Source.</param>
		T Code (string source);

		T CodeBlock (string[] lines, string lang);
		/// <summary>
		/// Quote the specified inner.
		/// </summary>
		/// <param name="inner">Inner.</param>
		T Quote (T inner);
		/// <summary>
		/// Renews the precedent.
		/// </summary>
		/// <returns>The precedent with a new line attribution.</returns>
		/// <param name="existent">precedent.</param>
		T NewLine ();
		/// <summary>
		/// Emphasis the specified inner.
		/// </summary>
		/// <param name="existant">inner.</param>
		T Emphasis (T [] inner);
		/// <summary>
		/// Emphasis the specified inner.
		/// </summary>
		/// <param name="existant">inner.</param>
		T Strike (T inner);
		/// <summary>
		/// Emphasis the specified inner.
		/// </summary>
		/// <param name="inner">inner.</param>
		T Underline (T inner);

		/// <summary>
		/// Blank this instance.
		/// </summary>
		T Blank ();
		/// <summary>
		/// D the specified inner.
		/// </summary>
		/// <param name="inner">Inner.</param>
		T DT (T inner);
		/// <summary>
		/// D the specified inner.
		/// </summary>
		/// <param name="inner">Inner.</param>
		T DD (T inner);

		T Table (T head, T body);

		T TableHeader (string[] headers);

		T TableRow (T [] cells);

		T TableBody (T [] rows);

		T FootNote (T inner, string text);

	}

}
