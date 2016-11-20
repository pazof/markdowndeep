using System;
using System.Linq;

namespace MarkdownDevBed
{
	public class MDBlock: IMDBlock {
		protected IMDNode [] items;
		public IMDNode [] Items { get { return items; } } 

		public MDBlock(string text)
		{
			items = new IMDNode[] { new MDText (text) };
		}

		public MDBlock(string [] text)
		{
			items = text.Select (item => new MDText (item)).ToArray ();
		}

		public MDBlock (IMDNode [] nodes)
		{
			items = nodes;
		}

		public string Render()
		{
			return Render("");
		}

		public virtual string Render(string prefix)
		{
			return Rendering (this, prefix);
		}

		public Func<MDBlock,string,string> Rendering { get; set; } 
		= (block,prefix) => string.Join ("\n", block.Items.Select (item 
			=> prefix + item.Render()));
	}
}

