using System;
using System.Linq;

namespace MarkdownAVToXaml.Rendering.Text.Md
{
	public class DT : MDBlock {
		public int Width { get; set; } = 3;

		public override string Render()
		{
            return string.Join(
                    "\n",
                    Items.Select(
                        item => (Prefix + item.Render()).PadRight(Width)));
		}
	}
}

