using System;

namespace MarkdownDeep.Rendering.TeX
{
	public class Table : IMDNode 
	{
		public int [] Widthes { get; set; } 
		public Table (IMDNode head, IMDNode body)
		{
			throw new NotImplementedException ();
		}
		public string Render()
		{
			throw new NotImplementedException ();
		}
	}
}

