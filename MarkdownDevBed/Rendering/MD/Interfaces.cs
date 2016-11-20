using System;

namespace MarkdownDevBed
{
	public interface IMDNode  {
		string Render();
	}
	public interface IMDBlock: IMDNode {
		string Render(string prefix);
	}
}

