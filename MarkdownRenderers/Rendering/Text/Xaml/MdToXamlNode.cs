using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using MarkdownDeep;
using MarkdownDeep.Model;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    public abstract class MdToXamlNode : ISpan<string>, ITextStyleOwner 
    {

        public TextStyle Style { get; set; }

        public int Start { get; protected set; }

        public int Length { get; protected set; }

		static string Trim(string str)
		{
			if (str == null)
				return null;
			var txt = str.Replace("\n"," ").Split (' ');
			return string.Join(" ",txt.Where(m=>!string.IsNullOrWhiteSpace(m))
				.Select(m=>m.Trim ()));
		}

        public abstract string Render();
    }

}

