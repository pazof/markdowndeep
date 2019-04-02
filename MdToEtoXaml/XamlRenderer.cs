
using System.Collections.Generic;
using MarkdownDeep;
using MarkdownDeep.Rendering;
using MarkdownDeep.Rendering.Abstract;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System;
using MdToEtoXaml;

namespace MarkdownAVToXaml.Rendering.Text.Xaml.Eto
{
    /// <summary>
    ///  markdown renderer to Xaml
    /// </summary>

    public class XamlRenderer : MarkdownRendererToString<MdToXamlBlock< MDSpan>, MDSpan> 
      
    {
        IMap _map;
        private string _mainClass;
        private string _member;

        public XamlRenderer(string mainClass, string member, IMap map=null)
        {
            _mainClass = mainClass;
            _member = member;
            _map = map ?? new DefaultMap();
        }

        public override MdToXamlBlock<MDSpan> Abbreviation(string id, string abbreviation)
        {
            throw new NotImplementedException();
        }

        public override MdToXamlBlock<MDSpan> Aggregate(IEnumerable<MdToXamlBlock<MDSpan>> children)
        {
            return new XamlBlock(_map, children );
        }

        public override string AggregateFinalBlock(IEnumerable<MdToXamlBlock<MDSpan>> children)
        {
            var doc = new Document(_mainClass, _member, children);
            return doc.GetRenderer();
        }

        public override MdToXamlBlock<MDSpan> Audio(string href, string alt, string title)
        {
            var q = new XamlBlock(_map, null);
            q.Parameters.Add("Style", "Audio");
            q.Add( new Button(href, alt, title, TextStyle.Underline, _map));
            return q;
        }

        public override MDSpan Code(string source, string lang)
        {
            return new XamlText(source, TextStyle.Fixed, _map);
        }

        public override MdToXamlBlock<MDSpan> CodeBlock(string[] lines, string lang)
        {

            var q = new XamlBlock(_map, null);
            // TODO real rendering
            foreach (var colh in lines)
                q.Add(new XamlText(colh, TextStyle.Fixed, _map));

            q.Parameters.Add("Style", "CodeBlock");
            return q;

        }

        public override MdToXamlBlock<MDSpan> DD(IEnumerable<MdToXamlBlock<MDSpan>> inner)
        {
            var li = new XamlBlock(_map, inner);
            li.Parameters.Add("Style", "dd");
            return li;
        }

        public override MdToXamlBlock<MDSpan> DL(IEnumerable<MdToXamlBlock<MDSpan>> inner)
        {
            var li = new XamlBlock(_map, inner);
            li.Parameters.Add("Style", "dl");
            return li;
        }

        public override MdToXamlBlock<MDSpan> DT(IEnumerable<MdToXamlBlock<MDSpan>> inner)
        {
            var li = new XamlBlock(_map, inner);
            li.Parameters.Add("Style", "dt");
            return li;
        }

        public override MdToXamlBlock<MDSpan> FootNote(IEnumerable<MdToXamlBlock<MDSpan>> inner, string id)
        {
            var li = new XamlBlock(_map, inner);
            li.Parameters.Add("Style", "FootNote");
            return li;
        }


        public override MdToXamlBlock<MDSpan> Header(IEnumerable<MdToXamlBlock<MDSpan>> inner, HeaderLevel level)
        {
            var head = new TextLine(inner.First(), _map)
            {
                Level = level
            };
            if (inner.Count() < 2) return head;
            var blocks = new List<MdToXamlBlock<MDSpan>>();
            blocks.Add(head);
            blocks.AddRange(inner.Skip(1));
            var block = new XamlBlock(_map, blocks);
            return block;
        }

        public override MdToXamlBlock<MDSpan> Html(IEnumerable<MdToXamlBlock<MDSpan>> inner)
        {
            var li = new XamlBlock(_map, inner);
            li.Parameters.Add("Style", "Html");
            return li;
        }

        public override MdToXamlBlock<MDSpan> Image(string href, string alt, string title)
        {
            var q = new XamlBlock(_map, null);
            q.Parameters.Add("Style", "Image");
            q.Add(new Button(href, alt, title, TextStyle.Underline, _map));
            return q;
        }

        public override MDSpan Link(string text, string href, string title)
        {
            return new Button(href, text, title, TextStyle.Underline, _map);
        }

        public override MdToXamlBlock<MDSpan> ListItem(IEnumerable<MdToXamlBlock<MDSpan>> inner)
        {
            var li = new XamlBlock(_map, inner);
            li.Parameters.Add("Style", "li");
            return li;
        }


        public override MdToXamlBlock<MDSpan> NewLine(IEnumerable<MDSpan> words)
        {
            return new TextLine(words, _map);
        }

        public override MdToXamlBlock<MDSpan> OrderedList(IEnumerable<MdToXamlBlock<MDSpan>> list)
        {
            var ol = new XamlBlock(_map, list);
            ol.Parameters.Add("Style", "ol");
            return ol;
        }

        public override MdToXamlBlock<MDSpan> Paragraph(IEnumerable<MdToXamlBlock<MDSpan>> inner)
        {

            var p = new XamlBlock(_map, inner);
            p.Parameters.Add("Style", "p");
            return p;
        }


        public override MdToXamlBlock<MDSpan> Quote(IEnumerable<MdToXamlBlock<MDSpan>> inner)
        {

            var q = new XamlBlock(_map, inner);
            q.Parameters.Add("Style", "Quote");
            return q;
        }

        public override MdToXamlBlock<MDSpan> Ruler()
        {
            var q = new XamlBlock(_map, null);
            q.Parameters.Add("Style", "Ruler");
            q.Parameters.Add("Height", "5");
            return q;
        }

        public override MdToXamlBlock<MDSpan> Table(MdToXamlBlock<MDSpan> head, MdToXamlBlock<MDSpan> body)
        {
            var q = new XamlBlock(_map, null);
            // TODO real rendering
            q.AddRange(head);
            q.AddRange(body);

            q.Parameters.Add("Style", "Table");
            return q;
        }

        public override MdToXamlBlock<MDSpan> TableBody(IEnumerable<MdToXamlBlock<MDSpan>> rows)
        {
            var q = new XamlBlock(_map, null);
            // TODO real rendering
            foreach (var row in rows)
                q.AddRange(row);

            q.Parameters.Add("Style", "TableBody");
            return q;
        }

        public override MdToXamlBlock<MDSpan> TableCell(IEnumerable<MdToXamlBlock<MDSpan>> inner)
        {

            var q = new XamlBlock(_map, null);
            // TODO real rendering
            foreach (var row in inner)
                q.AddRange(row);

            q.Parameters.Add("Style", "TableCell");
            return q;
        }

        public override MdToXamlBlock<MDSpan> TableHeader(string[] headers)
        {

            var q = new XamlBlock(_map, null);
            // TODO real rendering
            foreach (var colh in headers)
                q.Add(new XamlText(colh, TextStyle.Strong, _map));

            q.Parameters.Add("Style", "TableCell");
            return q;
        }

        public override MdToXamlBlock<MDSpan> TableRow(IEnumerable<MdToXamlBlock<MDSpan>> cells)
        {

            var q = new XamlBlock(_map, null);
            // TODO real rendering
            foreach (var row in cells)
                q.AddRange(row);

            q.Parameters.Add("Style", "TableRow");
            return q;
        }

        public override MDSpan Text(string txt, int start, int len)
        {
            return new XamlText(txt.Substring(start, len), TextStyle.Normal, _map);
        }

        public override MdToXamlBlock<MDSpan> UnorderedList(IEnumerable<MdToXamlBlock<MDSpan>> list)
        {
            var ol = new XamlBlock(_map, list);
            ol.Parameters.Add("Style", "ul");
            return ol;
        }

        public override MdToXamlBlock<MDSpan> Video(string href, string alt, string title)
        {
            return new 
            TextLine( new List<MDSpan> { new XamlText($"Video: [{alt} ,{title}]({href})", TextStyle.Normal, _map) }, _map);
        }
    }
}

