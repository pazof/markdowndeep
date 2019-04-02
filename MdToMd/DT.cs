using System;
using System.Collections.Generic;
using System.Linq;

namespace MarkdownAVToXaml.Rendering.Text.Md
{
	public class DT : MDBlock {
		public int Width { get; set; } = 3;

		public override string GetRenderer()
		{
            return string.Join(
                    "\n",
                   ((List < MDSpan > )this).Select(
                        item => (Prefix + item.GetRenderer()).PadRight(Width)));
		}
	}
}

