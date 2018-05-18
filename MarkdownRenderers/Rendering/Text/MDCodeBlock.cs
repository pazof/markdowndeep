using System;

namespace MarkdownAVToXaml.Rendering.Text
{
	public class MDCodeBlock : MDBlock { 
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

