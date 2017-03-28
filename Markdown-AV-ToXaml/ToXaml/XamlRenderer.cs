using System;
using MarkdownDeep;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace MarkdownDeep.Rendering.Xaml
{
	/// <summary>
	/// Markdown renderer.
	/// Once fully implemented, it could be used to parse markdown and build an
	/// `string` implementation used as a DOM.
	/// Note: the first rendering produces an string.
	/// This string allows the latest rendering, to Markdown, as a string
	/// </summary>
	public class XamlRenderer : IMarkdownRenderer<string> 
	{
		public string Paragraph(string inner)
		{
			return inner;
		}

		public string AggregateSpan(string [] parts)
        {
			return string.Join ("\n", parts);
        }

		public string AggregateBlock(string [] parts)
		{
			
			return string.Join("\n",parts);
		}

		public string AggregateFinalBlock(string [] parts)
		{
			
			var items = string.Join("\n",parts);
			return $"<StackLayout>{items}</StackLayout>";
		}

		public string Image(string href, string alt, string title)
		{
			return $"<ImageView Text=\"{title}\" ID=\"{alt}\" Image=\""
			+"{x:ImageFromUriConverter \""+href+"\"}\" />";
		}

		public string Audio(string href, string alt, string title)
        {
			return $"<ImageView Text=\"{title}\" ID=\"{alt}\" Image=\""
				+"{x:ImageFromUriConverter \""+href+"\"}\" />";
        }

		public string Video (string href, string alt, string title)
		{
			return $"<ImageView Text=\"{title}\" ID=\"{alt}\" Image=\""
				+"{x:ImageFromUriConverter \""+href+"\"}\" />";
		}

		public string Code(string source)
        {
			return $"<Label Font=\"Fixed\" >{source}</Label>";
        }
			
		public string CodeBlock (string[] lines, string lang)
		{
			var source = string.Join ("\n",lines);
			return Code (source);
		}

		public string Emphasis(string [] inner)
        {
			var source = string.Join ("\n", inner);
			return $"<!-- Emphasis -->{source}";
        }

		public string Header(string inner, HeaderLevel level)
		{
			return $"<Label Style=\"{level.ToString()}\">{inner}</Label>";
        }

		public string Link(string inner, string href, string title)
        {
			return $"<LinkButton href=\"{href}\" title=\"{title}\">{inner}</LinkButton>";
		}


		public string ListItem(string inner)
        {
			return $"<Label>{inner}</Label>";
        }

		public string NewLine()
        {
			return"<Label/>\n";
        }

		public string UnorderedList (string[] list)
		{
			StringBuilder builder = new StringBuilder ();
			builder.Append ("<StackLayout Style=\"UL\">");
			foreach (var line in list) {
				builder.Append ("<StackLayout Orientation=\"Horizontal\">");
				builder.Append ("<Label>◉</Label>" + line);
				builder.Append ("</StackLayout>");
			}
			builder.Append ("</StackLayout>");
			return builder.ToString ();
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
				builder.Append ("<Label Style=\"Quote\">"+line+"</Label>");
			}
			return "<StackLayout Style=\"Quote\">"+builder.ToString ()+"</StackLayout>";
        }

		public string Strike(string inner)
		{
			return "<StackLayout Style=\"Strike\">"+inner+"</StackLayout>";
        }

		public string Strong(string [] inner)
		{
			return "<StackLayout Style=\"Strong\">"+string.Join("\n",inner)+"</StackLayout>";
        }

		public string Text(string txt)
        {
			return txt;
        }

		public string Underline(string existent)
		{
			return $"<StackLayout Style=\"Underline\">{existent}</StackLayout>";
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

