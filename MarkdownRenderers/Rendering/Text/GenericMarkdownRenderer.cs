using System;
using MarkdownDeep;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using MarkdownDeep.Model;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text
{

    /// <summary>
    /// Markdown renderer.
    /// Once fully implemented, it could be used to parse markdown and build 
    /// all text based content from md format
    /// </summary>
    public interface IMarkdownRendererToString<U, V> : IMarkdownDocumentRenderer<string, U, V>
        where U : ISpan<string> where V : IBlock<string>
    {
        
    }

    public abstract class MarkdownRendererToString<U, V> : IMarkdownRendererToString<U, V>
        where U : ISpan<string> where V : IBlock<string>
    {
        public abstract void AddBlankTo(U span);

        public abstract void AddNewLineTo(U span);

        public abstract U Aggregate<T>(IRenderer<T>[] children);

        public V Aggregate(V[] children)
        {
            throw new NotImplementedException();
        }

        public V AggregateFinalBlock(params V[] children)
        {
            throw new NotImplementedException();
        }

        public U AggregateSpan(U[] children)
        {
            throw new NotImplementedException();
        }

        public abstract U Audio(string href, string alt, string title);

        public abstract U Code(string source);

        public abstract V CodeBlock(string[] lines, string lang);

        public abstract V DD(U inner);

        public abstract V DT(V inner);

        public abstract U Emphasis(U[] TSpan);

        public abstract V FootNote(U inner, string id);

        public abstract V Header(V inner, HeaderLevel level);

        public abstract U Image(string href, string alt, string title);

        public abstract U Link(string text, string href, string title);

        public abstract V ListItem(V inner);

        public abstract V ListItem(U inner);

        public abstract V OrderedList(V[] list);

        public abstract V Paragraph(U inner);

        public abstract V Quote(V inner);

        public abstract V Separator();

        public abstract U Strike(U TSpan);

        public abstract U Strong(U[] inner);

        public abstract V Table(V head, V body);

        public abstract V TableBody(V[] rows);

        public abstract V TableHeader(string[] headers);

        public abstract V TableRow(V[] cells);

        public abstract U Text(string txt, int start, int len);

        public abstract U Underline(U inner);

        public abstract V UnorderedList(V[] list);

        public abstract U Video(string href, string alt, string title);
    }
}

