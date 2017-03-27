using System;
using MarkdownDeep;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace MarkdownDeep.Rendering.TeX
{
	/// <summary>
	/// Markdown renderer.
	/// Once fully implemented, it could be used to parse markdown and build an
	/// `IMDNode` implementation used as a DOM.
	/// Note: the first rendering produces an IMDNode.
	/// This IMDNode allows the latest rendering, to Markdown, as a string
	/// </summary>
	public class TeXRenderer : IMarkdownRenderer<IMDNode> 
	{
		public IMDNode Paragraph(IMDNode inner)
		{
			return new Paragraph (inner);
		}

		public IMDNode AggregateSpan(IMDNode [] parts)
        {
			return new MDBlock (parts) {

				Rendering = (block,prefix) => string.Join (" ", block.Items.Select (item => 
					prefix + item.Render()))
			};
        }

		public IMDNode AggregateBlock(IMDNode [] parts)
		{
			return new MDBlock (parts);
		}

		public IMDNode AggregateFinalBlock(IMDNode [] parts)
		{
			return new MDBlock (parts);
		}

		public IMDNode Image(string href, string alt, string title)
		{
			return new MDText((string.IsNullOrWhiteSpace (title)) ? 
				$"![{alt}]({href})" : $"![{alt}]({href} \"{title}\")");
		}

		public IMDNode Audio(string href, string alt, string title)
        {
			return new MDText(
				string.IsNullOrWhiteSpace (title) ? 
				$"![audio:{alt}]({href})" : 
				$"![audio:{alt}]({href} \"{title}\")"
				);
        }

		public IMDNode Video (string href, string alt, string title)
		{
			return new MDText( (string.IsNullOrWhiteSpace (title)) ? 
				$"![video:{alt}]({href})" :
				$"![video:{alt}]({href} \"{title}\")" );
		}

		public IMDNode Code(string source)
        {
			return new MDText($"`{source}`");
        }
			
		public IMDNode CodeBlock (string[] lines, string lang)
		{
			return new MDCodeBlock(lines,lang);
		}

		public IMDNode Emphasis(IMDNode [] inner)
        {
			return new MDEmphasis(inner);
        }

		public IMDNode Header(IMDNode inner, HeaderLevel level)
		{
			string prefix = "";
			for (int i = 0; i < (int)level; i++)
				prefix += "#";
			return new MDText($"{prefix} {inner}");
        }


		public IMDNode Link(IMDNode inner, string href, string title)
        {
			return new MDText(string.IsNullOrWhiteSpace (title) ? 
				$"[{inner}]({href})" : $"[{inner}]({href} \"{title}\")");
		}


		public IMDNode ListItem(IMDNode inner)
        {
			return new ListItem(inner);
        }

		public IMDNode NewLine()
        {
			return new MDText("\n");
        }

		public IMDNode OrderedList(IMDNode[] list)
        {
			return new OrderedList(list);
        }

		public IMDNode Quote(IMDNode inner)
        {
			return new Quote(inner);
        }

		public IMDNode Strike(IMDNode inner)
		{
			var text = inner.Render ();
			return new MDText(text) {
				Rendering = x=> $"~{x.Text}~"
			};
        }

		public IMDNode Strong(IMDNode [] inner)
		{
			// Debug.Assert(inner.Length>0);
			return new MDBlock(inner) {
				Rendering = (block,prefix) => {
					var rendered = block.Items.Select(
						item => item.Render());
					return (rendered.Any(
							item => item.Contains('\n'))) ? 
						"**\n"+ string.Join("\n",rendered) +"\n**\n" :
						"**"+string.Join(" ",rendered)+"**";
					}
			};
        }

		public IMDNode Text(string txt)
        {
			return  new MDText(txt) {
					Rendering = x=> x.Text
				};
        }

		public IMDNode Underline(IMDNode existent)
		{
			return new MDText(existent.Render()) {
				Rendering = x=> $"*{x.Text}*"
			};
        }

		public IMDNode UnorderedList (IMDNode[] list)
        {
			return new UnorderedList(list);
		}
		
		public IMDNode DD(IMDNode data)
		{
			return new DD(data);
		}

		public IMDNode DT(IMDNode data)
		{
			return new DT(data);
		}

		public IMDNode Table(IMDNode head, IMDNode body)
		{
			return new Table ( head, body) ;
		}

		public IMDNode TableHeader (string [] titles)
		{
			throw new NotImplementedException ();
		}

		public IMDNode TableBody (IMDNode [] rows)
		{
			throw new NotImplementedException ();
		}

		public IMDNode Blank()
		{
			return new MDText(" ");
		}

		public IMDNode TableRow(IMDNode[] cells)
		{
			throw new NotImplementedException ();
		}

		public IMDNode FootNote(IMDNode id, string text)
		{
			throw new NotImplementedException ();
		}

    }
}

