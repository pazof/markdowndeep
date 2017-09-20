using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using MarkdownDeep;
using MarkdownDeep.Model;

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

			// Les liens
			if (Source != null) {
				string linktext="";
				if (Children != null && Children.Count() > 0)
					// TODO RichText
					linktext = string.Join (" ", Children.Select (c => Trim (((MdToXamlNode)c).ToText())));
				linktext = $"{Value}{linktext}";
				return $"<LinkButton Command=\"{{Binding open{SourceType}}}\" CommandParameter=\"{Source}\">{linktext}</LinkButton>";
			}
			if (Value != null) {
				var val = Trim (Value);
				return $"<Label Font=\"{font}\">{val}</Label>";
			}
			if (IsBlock) {
				if (Children == null)
					// FIXME newLine? 
					return "<Label/>\n";
				var items = string.Join("\n",Children.Select (c => ((MdToXamlNode)c).ToXaml ()));
				// span
				return Children.Length>1? $"<StackLayout>{items}</StackLayout>\n" : items;
			}
			if (Children != null) {
				var items = string.Join("\n",Children.Select (c => ((MdToXamlNode)c).ToXaml ()));
				return $"<DynamicLayout Padding=\"10,10\">\n{items}\n</DynamicLayout>\n";
			}
			return null;
		}

		static string Trim(string str)
		{
			if (str == null)
				return null;
			var txt = str.Replace("\n"," ").Split (' ');
			return string.Join(" ",txt.Where(m=>!string.IsNullOrWhiteSpace(m))
				.Select(m=>m.Trim ()));
		}

		public string ToText()
		{
			if (Value != null)
				return Trim (Value);
			else
				return string.Join (" ", Children.Select (c => ((MdToXamlNode)c).ToText ()));
		}
	}

}

