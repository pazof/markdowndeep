using System;
using MarkdownDeep;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using MarkdownDeep.Model;
using MarkdownDeep.Rendering.Abstract;
using MarkdownAVToXaml.Rendering.Text.Xaml;

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

        override public ISpan<string> CodeBlock (string[] lines, string lang)
		{
			return new MDCodeBlock(lines,lang);
		}

         public MDBlock Header(MDBlock inner, HeaderLevel level)
		{
            return new MDHeader(level, inner.Items);
        }
        public override ISpan<string> Link(string text, string href, string title)
		{
            return new MDLink{ HRef = href, Title = title, Text = text  }; 
		}

        public  MDBlock Quote(MDBlock inner)
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

        public override void Strong(ISpan<string>[] inner)
		{
            // Debug.Assert(inner.Length>0);
            throw new NotImplementedException();
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

        public override MDBlock DD(ISpan<string> inner)
        {
            throw new NotImplementedException();
        }

        public override MDBlock DT(MDBlock inner)
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

        public override ISpan<string> Code(string[] source, string lang)
        {
            throw new NotImplementedException();
        }

        public override IRenderer<string> AggregateFinalBlock(IEnumerable<IRenderer<string>> children)
        {
            throw new NotImplementedException();
        }

        public override MDBlock OrderedList(IRenderer<string>[] list)
        {
            throw new NotImplementedException();
        }

        public override IRenderer<string> Paragraph(ISpan<string> inner)
        {
            throw new NotImplementedException();
        }

        public override MDBlock UnorderedList(ISpan<string>[] list)
        {
            throw new NotImplementedException();
        }

        public override ISpan<string> AggregateSpan(IEnumerable<ISpan<string>> children)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Code the specified source and lang.
        /// </summary>
        /// <returns>The code.</returns>
        /// <param name="source">Source.</param>
        /// <param name="lang">Lang.</param>
        // FIXME : this is a block ...
        public override ISpan<string> Code(string source, string lang)
        {
            throw new NotImplementedException();
        }

        public override MDBlock DD(IRenderer<string> inner)
        {
            throw new NotImplementedException();
        }

        public override MDBlock FootNote(IRenderer<string> inner, string id)
        {
            throw new NotImplementedException();
        }

        public override IRenderer<string> Header(IRenderer<string> inner, HeaderLevel level)
        {
            throw new NotImplementedException();
        }

        public override IRenderer<string> OrderedList(IEnumerable<IRenderer<string>> list)
        {
            throw new NotImplementedException();
        }

        public override MDBlock TableBody(IEnumerable<IRenderer<string>> rows)
        {
            throw new NotImplementedException();
        }

        public override IRenderer<string> TableRow(IEnumerable<IRenderer<string>> cells)
        {
            throw new NotImplementedException();
        }

        public override IRenderer<string> UnorderedList(IEnumerable<IRenderer<string>> list)
        {
            throw new NotImplementedException();
        }

        public override IRenderer<string> Aggregate(IEnumerable<IRenderer<string>> children)
        {
            throw new NotImplementedException();
        }

        public override void Emphasis(ISpan<string>[] TSpan)
        {
            throw new NotImplementedException();
        }

        public override void Strong(IEnumerable<ISpan<string>> inner)
        {
            throw new NotImplementedException();
        }

        public override void Emphasis(IEnumerable<ISpan<string>> TSpan)
        {
            throw new NotImplementedException();
        }

        public override MDBlock NewLine()
        {
            throw new NotImplementedException();
        }

        public override MDBlock Quote(IEnumerable<IRenderer<string>> inner)
        {
            throw new NotImplementedException();
        }

        public override void AddNewLineTo(ISpan<string> span)
        {
            throw new NotImplementedException();
        }

        public override IRenderer<string> Header(IEnumerable<IRenderer<string>> inner, HeaderLevel level)
        {
            throw new NotImplementedException();
        }

        public override IRenderer<string> TableCell(IEnumerable<IRenderer<string>> inner)
        {
            throw new NotImplementedException();
        }

        public override MDBlock Html(IEnumerable<IRenderer<string>> inner)
        {
            throw new NotImplementedException();
        }

        public override MDBlock DT(IEnumerable<IRenderer<string>> inner)
        {
            throw new NotImplementedException();
        }

        public override MDBlock DL(IEnumerable<IRenderer<string>> inner)
        {
            throw new NotImplementedException();
        }

        public override MDBlock DD(IEnumerable<IRenderer<string>> inner)
        {
            throw new NotImplementedException();
        }

        public override MDBlock FootNote(IEnumerable<IRenderer<string>> inner, string id)
        {
            throw new NotImplementedException();
        }

        public override IRenderer<string> ListItem(IEnumerable<IRenderer<string>> inner)
        {
            return new ListItem(inner);
        }
    }
}

