using System;

namespace MarkdownDeep.Rendering.Markdown
{
	public interface IMDBlock: IMDNode {
		string Render(string prefix);
	}
}

