using System;
using System.Linq;

namespace MarkdownDevBed
{
	public class MDEM : IMDBlock {
		IMDNode [] parts;

		public MDEM(IMDNode [] parts) 
		{
			this.parts = parts;
		}

		public string Render(string prefix) {
			string mypref = prefix == null ? "" : prefix;
			if (parts.Length>1) {
				return "**" + string.Join ("\n", parts.Select
					(line => mypref + line.Render()))+ "**";
			} else {
				return mypref + "*" +
					string .Join( " ", this.parts.Select( p=> p.Render ())) + "*";
			}
		}

		public string Render()
		{
			return Render ("");
		}
	}
}

