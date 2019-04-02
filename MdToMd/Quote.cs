using System;
using System.Collections.Generic;
using System.Linq;

namespace MarkdownAVToXaml.Rendering.Text.Md
{
	public class Quote : MDBlock {
        public Quote(MDBlock innerBlock)
        {
            Prefix="> ";
            AddRange(innerBlock);
        }
        public override string GetRenderer()
		{
			return Prefix +
				string.Join ("\n" + Prefix, 
                             ((List<MDSpan>)this).Select(i=>i.GetRenderer ().Split ('\n')));
		}
	}
}

