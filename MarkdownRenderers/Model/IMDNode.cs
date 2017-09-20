using System;
using System.Collections.Generic;

namespace MarkdownDeep.Model
{
	public enum MediaType { 
		Text,
		Link,
		Image,
		Audio,
		Video
	}
	public enum ListStyle { 
		None,
		Ordered,
		Unordered
	}
	public interface IMDNode  {
		string Value { get; set; }
		string Source { get; set; }
		string Meta {  get; set; }
		MediaType SourceType { get; set; } 
		// int col { get; set; } 
		// int row { get; set; }
		bool IsEmphasys { get; set; }
		bool IsStrong { get; set; }
		bool IsStrikout { get; set; }
		bool IsUnderline { get; set; }
		bool IsBlock { get; set; }
		bool IsMonospace { get; set; }
		IMDNode [] Children { get; set; }
		HeaderLevel IsHeader { get; set; }
		int Depth { get; set; }
		ListStyle IsList { get; set; }
	}
}

