using System;
using MarkdownDeep;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using MarkdownDeep.Rendering.Markdown;

namespace MarkdownDeep.Rendering.Xaml
{
	public class MdToXamlNode : IMDNode {
		public string Value { get; set; } 
		public string Source { get; set; }
		public string Meta {  get; set; }
		public MediaType SourceType { get; set; } 
		public bool IsEmphasys { get; set; }
		public bool IsStrong { get; set; }
		public bool IsStrikout { get; set; }
		public bool IsUnderline { get; set; }
		public bool IsBlock { get; set; }
		public bool IsMonospace { get; set; }
		public IMDNode [] Children { get; set; }
		public HeaderLevel IsHeader { get; set; }
		public int Depth { get; set; }
		public ListStyle IsList { get; set; }
		public string ToXaml ()
		{
			// les cas terminaux
			if (Source != null) {
				string txt = this.Value ?? this.Children? [0].Value ?? null;
				return $"<LinkButton Command=\"open{SourceType}\" CommandParameter=\"{Source}\">{txt} ({Meta})</LinkButton>";
			}
			if (Value != null) {
				return $"<Label>{Value}</Label>";
			}
			if (IsBlock) {
				if (Children == null)
					return "<Label/>\n";
				var items = string.Join("\n",Children.Select (c => ((MdToXamlNode)c).ToXaml ()));
				return $"<StackLayout Orientation=\"Vertical\">\n{items}\n</StackLayout>\n";
			}
			if (Children != null) {
				var items = string.Join("\n",Children.Select (c => ((MdToXamlNode)c).ToXaml ()));
				return $"<StackLayout Orientation=\"Horizontal\">\n{items}\n</StackLayout>\n";
			}
			return null;
		}
	}

	/// <summary>
	///  markdown renderer to Xaml
	/// </summary>
	public class XamlRenderer : MarkdownRenderer<MdToXamlNode> 
	{
		
    }
}

