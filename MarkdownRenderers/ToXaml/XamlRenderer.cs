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
			// TODO smarter ...
			string font = "Sans+Regular+10pt";
			switch (IsHeader) {
			case HeaderLevel.H1:
				font = "Serif+Regular+30pt";
				break;
			case HeaderLevel.H2:
				font = "Serif+Regular+24pt";
				break;
			case HeaderLevel.H3:
				font = "Serif+Regular+20pt";
				break;
			case HeaderLevel.H4:
				font = "Serif+Regular+16pt";
				break;
			case HeaderLevel.H5:
				font = "Serif+Regular+14pt";
				break;
			case HeaderLevel.H6:
				font = "Serif+Regular+12pt";
				break;
			}

			// rendre reccursivement la taille de l'entête:
			if (IsHeader > 0) {
				if (Children!=null)
				foreach (var i in Children) {
					i.IsHeader = IsHeader;
				}
			}

			// les cas terminaux
			if (Source != null) {
				string txt = this.Value ?? this.Children? [0].Value ?? null;
				return $"<LinkButton Command=\"{{Binding open{SourceType}}}\" CommandParameter=\"{Source}\">{txt} ({Meta})</LinkButton>";
			}
			if (Value != null) {
				// ugly min html
				var txt = Value.Replace("\n"," ").Split (' ');
				var tr = string.Join(" ",txt.Where(m=>!string.IsNullOrWhiteSpace(m))
					.Select(m=>m.Trim ()));
				return $"<Label Font=\"{font}\">{tr}</Label>";
			}
			if (IsBlock) {
				if (Children == null)
					return "<Label/>\n";
				var items = string.Join("\n",Children.Select (c => ((MdToXamlNode)c).ToXaml ()));
				return $"<StackLayout Orientation=\"Vertical\">\n{items}\n</StackLayout>\n";
			}
			if (Children != null) {
				var items = string.Join("\n",Children.Select (c => ((MdToXamlNode)c).ToXaml ()));
				return $"<DynamicLayout>\n{items}\n</DynamicLayout>\n";
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

