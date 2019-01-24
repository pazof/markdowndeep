using System;
using MarkdownDeep;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using MarkdownDeep.Model;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text
{

    public abstract class MarkdownRendererToString<V> : IMarkdownDocumentRenderer<string, V>
       where V : class, IBlock<string>
    {
        public abstract void AddBlankTo(V span);

        public abstract V Audio(string href, string alt, string title);

        public abstract V DD(V inner);

        public abstract V DT(V inner);

        public abstract void Emphasis(V[] TSpan);


        public abstract V Image(string href, string alt, string title);

        public abstract V Link(string text, string href, string title);


        public abstract V Separator();

        public abstract V Strike(V TSpan);

        public abstract void Strong(V[] inner);

        public abstract V Table(V head, V body);

        public abstract V TableBody(V[] rows);

        public abstract V TableBody(IEnumerable<V> rows);

        public abstract V Text(string txt, int start, int len);

        public abstract V Underline(V inner);


        public abstract V Video(string href, string alt, string title);


        public abstract ISpan<string> AggregateSpan(IEnumerable<ISpan<string>> children);

        public abstract  void Strong(IEnumerable<V> inner);
        public abstract  void Emphasis(IEnumerable<V> TSpan);

        public abstract V NewLine();

        public abstract void AddNewLineTo(V span);


        public abstract V Html(IEnumerable<V> inner);

        public abstract V DT(IEnumerable<V> inner);

        public abstract V DL(IEnumerable<V> inner);

        public abstract V DD(IEnumerable<V> inner);

        public abstract V FootNote(IEnumerable<V> inner, string id);

        public abstract V TableHeader(string[] headers);

        public abstract V NewLine(IEnumerable<V> words);

        public abstract V Paragraph(IEnumerable<V> inner);

        public abstract V AggregateSpan(IEnumerable<V> children);

        public abstract V Header(IEnumerable<V> inner, HeaderLevel level);

        public abstract V ListItem(IEnumerable<V> inner);

        public abstract V TableCell(IEnumerable<V> inner);

        public abstract V UnorderedList(IEnumerable<V> list);

        public abstract  V OrderedList(IEnumerable<V> list);

        public abstract V Code(string source, string lang);
        public abstract V CodeBlock(string[] lines, string lang);

        public abstract  V Quote(IEnumerable<V> inner);
        public abstract V TableRow(IEnumerable<V> cells);

        public abstract IRenderer<string> AggregateFinalBlock(IEnumerable<V> children);
        public abstract IRenderer<string> Aggregate(IEnumerable<V> children);
    }
}

