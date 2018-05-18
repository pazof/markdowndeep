using System;
using System.Collections.Generic;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownDeep.Model
{
    [Obsolete("Use IBlock or ISpan interfaces")]
    public interface IMDNode : ISpan<string>  {
		string Display { get; set; }
		string Data { get; set; }
		string Meta {  get; set; }
		MediaType SourceType { get; set; } 
		IMDNode [] Children { get; set; }
		HeaderLevel IsHeader { get; set; }
		int Depth { get; set; }
		ListStyle IsList { get; set; }
	}
}

