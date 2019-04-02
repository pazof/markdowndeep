using System;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text.Md
{
    public class MDCodeBlock : MDBlock, ISpan { 
		protected string lang=null;
		public MDCodeBlock(string [] lines, string lang) 
		{
			this.lang = lang;
            throw new NotImplementedException();
		}

        public string Text { get; set; }

        public override string GetRenderer() {
			var baseTxt = base.GetRenderer ();
            string mypref = Prefix == null ? "" : Prefix;
			return mypref+$"```{lang}\n"+
				baseTxt+'\n'+mypref+"```\n";

		}
	}
}

