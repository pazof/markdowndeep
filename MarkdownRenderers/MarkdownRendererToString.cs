using System;
using MarkdownDeep;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using MarkdownDeep.Model;
using MarkdownDeep.Rendering.Abstract;
using MarkdownDeep.Rendering;

namespace MarkdownAVToXaml.Rendering.Text
{

    public abstract class MarkdownRendererToString<V,S> : IMarkdownDocumentRenderer<string, V, S>
       where V : class, IBlock
        where S : ISpan
    {

        public abstract V Audio(string href, string alt, string title);

        public abstract V DD(IEnumerable<V> inner);

        public abstract V DT(IEnumerable<V> inner);

        public abstract V DL(IEnumerable<V> inner);

        public abstract V Image(string href, string alt, string title);

        public abstract S Link(string text, string href, string title);

        public abstract V Ruler();

        public abstract V Table(V head, V body);

        public abstract V TableBody(IEnumerable<V> rows);

        public abstract S Text(string txt, int start, int len);

        public abstract V Video(string href, string alt, string title);

        public abstract V Html(IEnumerable<V> inner);


        public abstract V FootNote(IEnumerable<V> inner, string id);

        public abstract V TableHeader(string[] headers);

        public abstract V NewLine(IEnumerable<S> words);

        public abstract V Paragraph(IEnumerable<V> inner);

        public abstract V Header(IEnumerable<V> inner, HeaderLevel level);

        public abstract V ListItem(IEnumerable<V> inner);

        public abstract V TableCell(IEnumerable<V> inner);

        public abstract V UnorderedList(IEnumerable<V> list);
        public abstract  V OrderedList(IEnumerable<V> list);
        public abstract S Code(string source, string lang);
        public abstract V CodeBlock(string[] lines, string lang);
        public abstract  V Quote(IEnumerable<V> inner);
        public abstract V TableRow(IEnumerable<V> cells);
        public abstract string AggregateFinalBlock(IEnumerable<V> children);
        public abstract V Aggregate(IEnumerable<V> children);
        public abstract V Abbreviation(string id, string abbreviation);
    }
}

