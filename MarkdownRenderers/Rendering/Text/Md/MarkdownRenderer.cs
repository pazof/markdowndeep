using System;
using MarkdownDeep;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using MarkdownDeep.Model;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text.Md
{
	/// <summary>
	/// Markdown renderer.
	/// </summary>
    public class MarkdownRenderer : MarkdownRendererToString<ISpan<string>, MDBlock>
	{
        
        override public ISpan<string> Image(string href, string alt, string title)
		{
            return new MDImage { HRef = href, Alt = alt, Title = title };
		}

        override public ISpan<string> Audio(string href, string alt, string title)
        {
            return new MDImage { HRef = href, Alt = alt, Title = title, MimeCat="audio" };
        }

        override public ISpan<string> Video (string href, string alt, string title)
		{
            return new MDImage { HRef = href, Alt = alt, Title = title, MimeCat = "video" };
		}

        override public MDBlock CodeBlock (string[] lines, string lang)
		{
			return new MDCodeBlock(lines,lang);
		}

        override public ISpan<string> Emphasis(ISpan<string> [] parts)
        {
            return  new MDEmphasis(parts);
        }

        override public MDBlock Header(MDBlock inner, HeaderLevel level)
		{
            return new MDHeader(level, inner.Items);
        }
        public override ISpan<string> Link(string text, string href, string title)
		{
            return new MDLink{ HRef = href, Title = title, Text = text  }; 
		}

        public override MDBlock ListItem(MDBlock inner)
        {
			return new ListItem(inner);
        }

        public override MDBlock Quote(MDBlock inner)
        {
            return new Quote (inner);
        }

        public override ISpan<string> Strike(ISpan<string> inner)
		{
			var text = inner.Render ();
			return new MDText(text) {
				Rendering = x=> $"~{x.Text}~"
			};
        }

        public override ISpan<string> Strong(ISpan<string>[] inner)
		{
			// Debug.Assert(inner.Length>0);
            return new MDEmphasis(inner);
        }

        public override ISpan<string> Underline(ISpan<string> existent)
		{
			return new MDText(existent.Render()) {
				Rendering = x=> $"_{x.Text}_"
			};
        }

        public override void AddBlankTo(ISpan<string> span)
        {
            throw new NotImplementedException();
        }

        public override void AddNewLineTo(ISpan<string> span)
        {
            throw new NotImplementedException();
        }


        public override MDBlock DD(ISpan<string> inner)
        {
            throw new NotImplementedException();
        }

        public override MDBlock DT(MDBlock inner)
        {
            throw new NotImplementedException();
        }


        public override MDBlock FootNote(ISpan<string> inner, string id)
        {
            throw new NotImplementedException();
        }



        public override MDBlock ListItem(ISpan<string> inner)
        {
            throw new NotImplementedException();
        }

        public override MDBlock OrderedList(MDBlock[] list)
        {
            throw new NotImplementedException();
        }

        public override MDBlock Paragraph(ISpan<string> inner)
        {
            throw new NotImplementedException();
        }


        public override MDBlock Separator()
        {
            throw new NotImplementedException();
        }


        public override MDBlock Table(MDBlock head, MDBlock body)
        {
            throw new NotImplementedException();
        }

        public override MDBlock TableBody(MDBlock[] rows)
        {
            throw new NotImplementedException();
        }

        public override MDBlock TableHeader(string[] headers)
        {
            throw new NotImplementedException();
        }

        public override MDBlock TableRow(MDBlock[] cells)
        {
            throw new NotImplementedException();
        }

        public override ISpan<string> Text(string txt, int start, int len)
        {
            throw new NotImplementedException();
        }

        public override MDBlock UnorderedList(MDBlock[] list)
        {
            throw new NotImplementedException();
        }

        public override ISpan<string> Aggregate<T>(IRenderer<T>[] children)
        {
            throw new NotImplementedException();
        }

        public override ISpan<string> AggregateSpan(ISpan<string>[] children)
        {
            throw new NotImplementedException();
        }

        public override MDBlock Aggregate(MDBlock[] children)
        {
            throw new NotImplementedException();
        }

        public override MDBlock AggregateFinalBlock(params MDBlock[] children)
        {
            throw new NotImplementedException();
        }

        public override ISpan<string> Code(string[] source, string lang)
        {
            throw new NotImplementedException();
        }

        public override ISpan<string> Code(string[] sourcelines)
        {
            throw new NotImplementedException();
        }

        public override ISpan<string> Code(string source)
        {
            throw new NotImplementedException();
        }
    }
}

