using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using MarkdownDeep;
using MarkdownDeep.Model;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    public class MdToXamlNode : ISpan<string> {
		public string Display { get; set; } 
		public string Data { get; set; }
		public string Meta {  get; set; }
		public MediaType SourceType { get; set; } 
		public bool IsEmphasys { get; set; }
		public bool IsStrong { get; set; }
		public bool IsStrikout { get; set; }
		public bool IsUnderline { get; set; }
		public bool IsBlock { get; set; }
		public bool IsFinalBlock { get; set; }
		public bool IsMonospace { get; set; }
		public IMDNode [] Children { get; set; }
		public HeaderLevel IsHeader { get; set; }
		public int Depth { get; set; }
		public ListStyle IsList { get; set; }
        public Dictionary<HeaderLevel, string> Font { get; private set; } =
            new Dictionary<HeaderLevel, string>
        {
            { HeaderLevel.H1, "Serif+Regular+30pt" },
            { HeaderLevel.H2, "Serif+Regular+24pt" },
            { HeaderLevel.H3, "Serif+Regular+20pt" },
            { HeaderLevel.H4, "Serif+Regular+16pt" },
            { HeaderLevel.H5, "Serif+Regular+14pt" },
            { HeaderLevel.H6, "Sans+Regular+12pt" },
            { HeaderLevel.None, "Sans+Regular+10pt" }
        };

        public TextStyle Style { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Start => throw new NotImplementedException();

        public int Length => throw new NotImplementedException();

		public string ToXaml ()
		{
			// les cas terminaux

			// Les liens
			if (Data != null) {
				string linktext="";
				if (Children != null && Children.Count() > 0)
					// TODO RichText
					linktext = string.Join (" ", Children.Select (c => Trim (((MdToXamlNode)c).ToXaml())));
				linktext = $"{Display}{linktext}";
				return $"<LinkButton Command=\"{{Binding open{SourceType}}}\" CommandParameter=\"{Data}\">{linktext}</LinkButton>";
            }
            if (Display != null) {
                var val = Trim(Display);
                var font = Font[IsHeader];
                if (IsList != ListStyle.None)
                {
                    var bullet = IsList.ToString();
                    return $"<ImageView Image=\"{bullet}\" /><Label Font=\"{font}\">{val} </Label>\n";
                }
                return  $"<Label Font=\"{font}\">{val} </Label>\n";
			}
			if (IsBlock) {
				if (Children == null)
					// FIXME newLine? 
					return "\n";
				var items = string.Join("\n",Children.Select (c => ((MdToXamlNode)c).ToXaml ()));
				// span
                return Children.Length>1? $"<StackLayout Orientation=\"Vertical\" Padding=\"10,10\">\n{items}\n</StackLayout>\n" : items;
			}
            if (Children != null && Children.Count()>1 ) {
				var items = string.Join("\n",Children.Select (c => ((MdToXamlNode)c).ToXaml ()));
                var orientax = IsFinalBlock ? "Vertical" : "Horizontal" ;
                return Children.Length > 1 ? $"<StackLayout Orientation=\"{orientax}\" Padding=\"10,10\">\n{items}\n</StackLayout>\n": items;
                
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

        public string GetInnerText()
        {
            throw new NotImplementedException();
        }

        public void FromSpan(ISpan<string> span)
        {
            throw new NotImplementedException();
        }

        public string Render()
        {
            throw new NotImplementedException();
        }
	}

}

