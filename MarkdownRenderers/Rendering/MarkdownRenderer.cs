using System;
using MarkdownDeep;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using MarkdownDeep.Model;

namespace MarkdownDeep.Rendering
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
		public T Paragraph(T inner, int start, int len)
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
			return new T { Children = parts.Cast<IMDNode>().ToArray(), IsBlock = true, IsFinalBlock = true };
		}

		public T Link(T inner, string href, string title)
		{
			return new T { Data = href, Display = title, Children =  new IMDNode[] { inner } };
		}

		public T Image(string href, string alt, string title)
		{
			return new T { Data = href, SourceType = MediaType.Image, Display = alt };
		}

		public T Audio(string href, string alt, string title)
		{
			return new T { Data = href, SourceType = MediaType.Audio, Display = alt };
        }

		public T Video (string href, string alt, string title)
		{
			return new T { Data = href, SourceType = MediaType.Video, Display = alt };
		}

		public T Code(string source)
        {
			return new T { Display = source, IsMonospace = true };
        }
			
		public T CodeBlock (string[] lines, string lang)
		{
            return new T { Display = string.Join("\n",lines), IsMonospace = true, IsBlock = true, Meta = $"lan:{lang}" };
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

		public T Text(string txt, int start, int len)
        {
			return new T { Display = txt.Substring(start, len) };
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
			return new T { Display = " " };
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

