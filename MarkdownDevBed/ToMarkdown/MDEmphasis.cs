using System;
using System.Linq;

namespace MarkdownDeep.Rendering.Markdown
{
	public class MDEmphasis : IMDBlock {
		IMDNode [] parts;

		public MDEmphasis(IMDNode [] parts) 
		{
			this.parts = parts;
		}

		public string Render(string prefix) {
			string mypref = prefix == null ? "" : prefix;
			return "*" + string.Join (" ", parts.Select
				(line => mypref + line.Render()))+ "*";
		}

		public string Render()
		{
			return Render ("");
		}
	}
}

