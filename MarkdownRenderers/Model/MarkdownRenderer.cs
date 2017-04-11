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
	/// `IMDNode` implementation used as a DOM node.
	/// 
	/// </summary>
	public class MarkdownRenderer<T> : IMarkdownRenderer<T>
		where T : IMDNode, new()
	{
		public T Paragraph(T inner)
		{
			inner.IsBlock = true;
			return inner;
		}

		public T AggregateSpan(T [] parts)
        {
			return new T { Children = parts.Cast<IMDNode>().ToArray() }; 
        }

		public T AggregateBlock(T [] parts)
		{
			return new T { Children = parts.Cast<IMDNode>().ToArray(), IsBlock = true };
		}

		public T AggregateFinalBlock(T [] parts)
		{
			return new T { Children = parts.Cast<IMDNode>().ToArray(), IsBlock = true };
		}

		public T Link(T inner, string href, string title)
		{
			inner.Source = href;
			inner.Value = title;
			return inner;
		}

		public T Image(string href, string alt, string title)
		{
			return new T { Source = href, SourceType = MediaType.Image, Value = alt };
		}

		public T Audio(string href, string alt, string title)
		{
			return new T { Source = href, SourceType = MediaType.Audio, Value = alt };
        }

		public T Video (string href, string alt, string title)
		{
			return new T { Source = href, SourceType = MediaType.Video, Value = alt };
		}

		public T Code(string source)
        {
			return new T { Value = source, IsMonospace = true };
        }
			
		public T CodeBlock (string[] lines, string lang)
		{
			return new T { Value = string.Join("\n",lines), IsMonospace = true, IsBlock = true, Meta = lang };
		}

		public T Emphasis(T [] inner)
        {
			return new T { Children = inner.Cast<IMDNode>().ToArray(), IsEmphasys = true };
        }

		public T Header(T inner, HeaderLevel level)
		{
			inner.IsHeader = level;
			return inner;
        }


		public T ListItem(T inner)
        {
			return inner; 
        }

		public T NewLine()
        {
			return new T { IsBlock = true };
        }

		public T OrderedList(T[] list)
        {
			return new T{ Children = list.Cast<IMDNode>().ToArray() , IsList = ListStyle.Ordered };
        }

		public T Quote(T inner)
        {
			inner.Depth++;
			return inner;
        }

		public T Strike(T inner)
		{
			inner.IsStrikout = true;
			return inner;
        }

		public T Strong(T [] inner)
		{
			return new T { Children = inner.Cast<IMDNode>().ToArray(), IsStrong = true };
        }

		public T Text(string txt)
        {
			return new T { Value = txt };
        }

		public T Underline(T existent)
		{
			existent.IsUnderline = true;
			return existent;
        }

		public T UnorderedList (T[] list)
        {
			return new T { Children = list.Cast<IMDNode>().ToArray(), IsList = ListStyle.Unordered };
		}
		
		public T DD(T data)
		{
			throw new NotImplementedException ();
		}

		public T DT(T data)
		{
			throw new NotImplementedException ();
		}

		public T Table(T head, T body)
		{
			throw new NotImplementedException ();
		}

		public T TableHeader (string [] titles)
		{
			throw new NotImplementedException ();
		}

		public T TableBody (T [] rows)
		{
			throw new NotImplementedException ();
		}

		public T Blank()
		{
			return new T { Value = " " };
		}

		public T TableRow(T[] cells)
		{
			throw new NotImplementedException ();
		}

		public T FootNote(T id, string text)
		{
			throw new NotImplementedException ();
		}

    }
}

