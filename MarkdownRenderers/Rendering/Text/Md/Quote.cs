using System;
using System.Linq;

namespace MarkdownAVToXaml.Rendering.Text.Md
{
	public class Quote : MDBlock {
        public Quote(MDBlock innerBlock)
        {
            Prefix="> ";
            Items=innerBlock.Items;
        }
        public override string Render()
		{
			return Prefix +
				string.Join ("\n" + Prefix, 
                             Items.Select(i=>i.Render ().Split ('\n')));
		}
	}
}

