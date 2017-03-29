using System;
using MarkdownDeep;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace MarkdownDeep.Rendering.Markdown
{
	/// <summary>
	/// Markdown renderer.
	/// Once fully implemented, it could be used to parse markdown and build an
	/// `string` implementation used as a DOM.
	/// Note: the first rendering produces an string.
	/// This string allows the latest rendering, to Markdown, as a string
	/// </summary>
	public class TextRenderer : IMarkdownRenderer<string> 
	{
		public string Paragraph(string inner)
		{
			return $"{inner}";
		}

		public string AggregateSpan(string [] parts)
        {
			return string.Join (" ", parts);
        }

		public string AggregateBlock(string [] parts)
		{
			return string.Join ("\n\n", parts);
		}

		public string AggregateFinalBlock(string [] parts)
		{
			return string.Join ("\n\n", parts);
		}

		public string Image(string href, string alt, string title)
		{
			return $"![{alt}]({href} \"{title}\")";
		}

		public string Audio(string href, string alt, string title)
        {
			return $"![audio:{alt}]({href} \"{title}\")";
        }

		public string Video (string href, string alt, string title)
		{
			return $"![video:{alt}]({href} \"{title}\")";
		}

		public string Code(string source)
        {
			return $"`{source}`";
        }
			
		public string CodeBlock (string[] lines, string lang)
		{
			var source = string.Join ("\n",lines);
			return $"```{lang}\n{source}\n```\n`";
		}

		public string Emphasis(string [] inner)
        {
			return "***"+string.Join ("\n", inner)+"***\n";
        }

		public string Header(string inner, HeaderLevel level)
		{
			string prefix = "";
			for (int i = 0; i < (int)level; i++)
				prefix += "#";
			return $"{prefix} {inner}";
        }

		public string Link(string inner, string href, string title)
        {
			return $"[{inner}]({href} \"{title}\")";
		}


		public string ListItem(string inner)
        {
			return $"* {inner}\n";
        }

		public string NewLine()
        {
			return"\n";
        }

		public string OrderedList(string[] list)
        {
			StringBuilder builder = new StringBuilder ();
			int i = 0;
			foreach (var line in list) {
				i++;
				builder.Append (i.ToString () + ") " + line);
			}
			return builder.ToString ();
        }

		public string Quote(string inner)
        {
			StringBuilder builder = new StringBuilder ();
			foreach (var line in inner.Split('\n')) {
				builder.Append ("   " + line);
			}
			return builder.ToString ();
        }

		public string Strike(string inner)
		{
			if (inner.Contains("\n"))
				return $"~~{inner}~~";
			return $"~{inner}~";
        }

		public string Strong(string [] inner)
		{
			return "**"+string.Join("\n",inner)+"**";
        }

		public string Text(string txt)
        {
			return txt;
        }

		public string Underline(string existent)
		{
			return $"_{existent}_";
        }

		public string UnorderedList (string[] list)
        {
			StringBuilder builder = new StringBuilder ();
			foreach (var line in list) {
				builder.Append ("* " + line);
			}
			return builder.ToString ();
		}
		
		public string DD(string data)
		{
			throw new NotImplementedException ();
		}

		public string DT(string data)
		{
			throw new NotImplementedException ();
		}

		public string Table(string head, string body)
		{
			throw new NotImplementedException ();
		}

		public string TableHeader (string [] titles)
		{
			throw new NotImplementedException ();
		}

		public string TableBody (string [] rows)
		{
			throw new NotImplementedException ();
		}

		public string Blank()
		{
			return" ";
		}

		public string TableRow(string[] cells)
		{
			throw new NotImplementedException ();
		}

		public string FootNote(string id, string text)
		{
			throw new NotImplementedException ();
		}

    }
}

