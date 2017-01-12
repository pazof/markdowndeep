using System;

namespace MarkdownDeep.Rendering.TeX
{
	public interface IMDBlock: IMDNode {
		string Render(string prefix);
	}
}

