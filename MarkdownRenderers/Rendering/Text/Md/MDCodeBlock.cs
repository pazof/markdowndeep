using System;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text.Md
{
    public class MDCodeBlock : MDBlock, ISpan<string> { 
		protected string lang=null;
		public MDCodeBlock(string [] lines, string lang) : base(lines)
		{
			this.lang = lang;
		}

        public override string Render() {
			var baseTxt = base.Render ();
            string mypref = Prefix == null ? "" : Prefix;
			return mypref+$"```{lang}\n"+
				baseTxt+'\n'+mypref+"```\n";

		}
	}
}

