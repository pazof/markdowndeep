using System;
using MarkdownDeep;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using MarkdownDeep.Model;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text
{

    public abstract class MarkdownRendererToString<U, V> : IMarkdownRendererToString<U, V>
        where U : ISpan<string> where V : IBlock<string>
    {
        public abstract void AddBlankTo(U span);

        public abstract IRenderer<string> AggregateFinalBlock(IEnumerable<IRenderer<string>> children);

        public abstract IRenderer<string> Aggregate(IEnumerable<IRenderer<string>> children);

        public abstract U Audio(string href, string alt, string title);

        public abstract ISpan<string> Code(string[] source, string lang);

        public abstract ISpan<string> Code(string source, string lang);

        public abstract ISpan<string> CodeBlock(string[] lines, string lang);

        public abstract V DD(U inner);

        public abstract V DD(IRenderer<string> inner);

        public abstract V DT(V inner);

        public abstract void Emphasis(U[] TSpan);

        public abstract V FootNote(IRenderer<string> inner, string id);

        public abstract IRenderer<string> Header(IRenderer<string> inner, HeaderLevel level);

        public abstract U Image(string href, string alt, string title);

        public abstract U Link(string text, string href, string title);

        public abstract V OrderedList(IRenderer<string>[] list);

        public abstract IRenderer<string> OrderedList(IEnumerable<IRenderer<string>> list);

        public abstract IRenderer<string> Paragraph(ISpan<string> inner);

        public abstract V Quote(IEnumerable<IRenderer<string>> inner);

        public abstract V Separator();

        public abstract U Strike(U TSpan);

        public abstract void Strong(U[] inner);

        public abstract V Table(V head, V body);

        public abstract V TableBody(V[] rows);

        public abstract V TableBody(IEnumerable<IRenderer<string>> rows);

        public abstract V TableHeader(string[] headers);

        public abstract V TableRow(V[] cells);

        public abstract IRenderer<string> TableRow(IEnumerable<IRenderer<string>> cells);

        public abstract U Text(string txt, int start, int len);

        public abstract U Underline(U inner);

        public abstract V UnorderedList(ISpan<string>[] list);

        public abstract IRenderer<string> UnorderedList(IEnumerable<IRenderer<string>> list);

        public abstract U Video(string href, string alt, string title);


        public abstract ISpan<string> AggregateSpan(IEnumerable<ISpan<string>> children);

        public abstract  void Strong(IEnumerable<U> inner);
        public abstract  void Emphasis(IEnumerable<U> TSpan);

        public abstract V NewLine();

        public abstract void AddNewLineTo(U span);

        public abstract IRenderer<string> Header(IEnumerable<IRenderer<string>> inner, HeaderLevel level);

        public abstract IRenderer<string> TableCell(IEnumerable<IRenderer<string>> inner);


        public abstract V Html(IEnumerable<IRenderer<string>> inner);

        public abstract V DT(IEnumerable<IRenderer<string>> inner);

        public abstract V DL(IEnumerable<IRenderer<string>> inner);

        public abstract V DD(IEnumerable<IRenderer<string>> inner);

        public abstract V FootNote(IEnumerable<IRenderer<string>> inner, string id);

        public abstract IRenderer<string> ListItem(IEnumerable<IRenderer<string>> inner);
    }
}

