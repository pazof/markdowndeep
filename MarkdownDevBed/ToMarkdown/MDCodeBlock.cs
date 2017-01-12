using System;

namespace MarkdownDeep.Rendering.Markdown
{
	public class MDCodeBlock : MDBlock { 
		protected string lang=null;
		public MDCodeBlock(string [] lines, string lang) : base(lines)
		{
			this.lang = lang;
		}

		public override string Render(string prefix) {
			var baseTxt = base.Render (prefix);
			string mypref = prefix == null ? "" : prefix;
			return mypref+$"```{lang}\n"+
				baseTxt+'\n'+mypref+"```\n";

		}
	}
}

