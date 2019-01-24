
using System.Collections.Generic;
using MarkdownDeep;
using MarkdownDeep.Rendering;
using MarkdownDeep.Rendering.Abstract;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace MarkdownAVToXaml.Rendering.Text.Xaml.Eto
{
    /// <summary>
    ///  markdown renderer to Xaml
    /// </summary>

    public class XamlRenderer : MarkdownRendererToString<MdToXamlBlock> 
    {
        IMap _map;
        private string _mainClass;

        public XamlRenderer(string mainClass, IMap map=null)
        {
            _mainClass = mainClass;
            _map = map ?? new DefaultMap();
        }


        public override IRenderer<string> Aggregate(IEnumerable<MdToXamlBlock> children)
        {
            var first = children.FirstOrDefault();
            if (children.Count() > 1) if (first!=null) if (typeof(Line).IsAssignableFrom(first.GetType()))
            {
                return first;
            }
            return new Line(children,_map);
        }

        public override MdToXamlBlock AggregateSpan(IEnumerable<MdToXamlBlock> children)
        {
            // FIXME how?
            if (children.Count() == 0) return null;
            return new Line(children, _map);
        }

        public override void Emphasis(MdToXamlBlock[] spans)
        {
            foreach (var node in spans)
                node.Style |= TextStyle.Italic;
        }

        public override void Strong(MdToXamlBlock[] inner)
        {
            foreach (var child in inner)
            {
                child.Style |= TextStyle.Emphasys;
            }
        }

        public override IRenderer<string> AggregateFinalBlock(IEnumerable<MdToXamlBlock> children)
        {
            return new Document(_mainClass, children);
        }


        public override MdToXamlBlock Header(IEnumerable<MdToXamlBlock> inner, HeaderLevel level)
        {
            var children = new List<MdToXamlBlock>();
            foreach (MdToXamlBlock child in inner)
            {
                if (typeof(XamlText).IsAssignableFrom(child.GetType()))
                {
                    var text = child as XamlText;
                    text.Level = level;
                    children.Add(child);
                }
                else {
                    children.Add(child);
                }
            }
            return new Line(children, _map);
        }


        public override MdToXamlBlock Audio(string href, string alt, string title)
        {
            throw new System.NotImplementedException();
        }

        public override void AddBlankTo(MdToXamlBlock span)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock Code(string source, string lang)
        {
            return new CodeNode(source.Split('\n'), lang);
        }

        public override MdToXamlBlock CodeBlock(string[] lines, string lang)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock DD(MdToXamlBlock inner)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock DT(MdToXamlBlock inner)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock Image(string href, string alt, string title)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock Link(string text, string href, string title)
        {
            return new Button(href, text, title);
        }

        public override MdToXamlBlock ListItem(IEnumerable<MdToXamlBlock> inner )
        {
            return new ListItem(inner, _map);
        }

        public override MdToXamlBlock Separator()
        {
            return new BlockSeparator();
        }

        public override MdToXamlBlock Strike(MdToXamlBlock span)
        {
            span.Style |= TextStyle.Strike;
            return span;
        }

        public override MdToXamlBlock Table(MdToXamlBlock head, MdToXamlBlock body)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock TableBody(MdToXamlBlock[] rows)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock TableHeader(string[] headers)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock Text(string txt, int start, int len)
        {
            return new Line(txt, start, len, _map);
        }

        public override MdToXamlBlock Underline(MdToXamlBlock inner)
        {
            if (typeof(ITextStyled).IsAssignableFrom(inner.GetType()))
            {
                ((ITextStyled)inner).Style |= TextStyle.Underline;
            }
            return inner;
        }

        public override MdToXamlBlock UnorderedList(IEnumerable<MdToXamlBlock> list)
        {
            return new UnorderedList(list);
        }

        public override MdToXamlBlock Video(string href, string alt, string title)
        {
            throw new System.NotImplementedException();
        }

        public override void Strong(IEnumerable<MdToXamlBlock> inner)
        {
            throw new System.NotImplementedException();
        }

        public override void Emphasis(IEnumerable<MdToXamlBlock> TSpan)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock NewLine()
        {
            return new BlockSeparator();
        }

        public override MdToXamlBlock Quote(IEnumerable<MdToXamlBlock> inner)
        {
            throw new System.NotImplementedException();
        }

        public override void AddNewLineTo(MdToXamlBlock span)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock Html(IEnumerable<MdToXamlBlock> inner)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock DT(IEnumerable<MdToXamlBlock> inner)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock DL(IEnumerable<MdToXamlBlock> inner)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock DD(IEnumerable<MdToXamlBlock> inner)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock FootNote(IEnumerable<MdToXamlBlock> inner, string id)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock TableBody(IEnumerable<MdToXamlBlock> rows)
        {
            throw new System.NotImplementedException();
        }

        public override ISpan<string> AggregateSpan(IEnumerable<ISpan<string>> children)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock NewLine(IEnumerable<MdToXamlBlock> words)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock Paragraph(IEnumerable<MdToXamlBlock> inner)
        {
            // TODOORNOT introduce a difference between paragraph and lines
            if (inner.Count() > 1) return new Line(inner, _map);
            return inner.FirstOrDefault();
        }

        public override MdToXamlBlock TableCell(IEnumerable<MdToXamlBlock> inner)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock OrderedList(IEnumerable<MdToXamlBlock> list)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock TableRow(IEnumerable<MdToXamlBlock> cells)
        {
            throw new System.NotImplementedException();
        }
    }
}

