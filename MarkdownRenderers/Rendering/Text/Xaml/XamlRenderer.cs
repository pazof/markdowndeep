
using System.Collections.Generic;
using MarkdownDeep;
using MarkdownDeep.Rendering;
using MarkdownDeep.Rendering.Abstract;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    /// <summary>
    ///  markdown renderer to Xaml
    /// </summary>

    public class XamlRenderer : MarkdownRendererToString<MdToXamlNode, MdToXamlBlock> 
    {
        IMap _map;
        private string _mainClass;

        public XamlRenderer(string mainClass)
        {
            _mainClass = mainClass;
            _map = new DefaultMap();
        }

        public override void AddBlankTo(MdToXamlNode span)
        {
            throw new System.NotImplementedException();
        }

        public override IRenderer<string> Aggregate(IEnumerable<IRenderer<string>> children)
        {
            if (children.Count() > 1)
                return new Line(children,_map);
            else return children.FirstOrDefault();
        }

        public override ISpan<string> AggregateSpan(IEnumerable<ISpan<string>> children)
        {
            // FIXME how?
            if (children.Count() == 0) return null;
            return new Line(children, _map);
        }

        public override void Emphasis(MdToXamlNode[] spans)
        {
            foreach (var node in spans)
                node.Style |= TextStyle.Italic;
        }

        public override void Strong(MdToXamlNode[] inner)
        {
            foreach (var child in inner)
            {
                child.Style |= TextStyle.Emphasys;
            }
        }

        public override IRenderer<string> AggregateFinalBlock(IEnumerable<IRenderer<string>> children)
        {
            return new Document(_mainClass, children);
        }

        public override MdToXamlNode Audio(string href, string alt, string title)
        {
            throw new System.NotImplementedException();
        }

        public override ISpan<string> Code(string[] source, string lang)
        {
            throw new System.NotImplementedException();
        }

        public override ISpan<string> Code(string source, string lang)
        {
            return new CodeNode(source.Split('\n'), lang);
        }

        public override ISpan<string> CodeBlock(string[] lines, string lang)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock DD(MdToXamlNode inner)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock DD(IRenderer<string> inner)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock DT(MdToXamlBlock inner)
        {
            throw new System.NotImplementedException();
        }


        public override MdToXamlBlock FootNote(IRenderer<string> inner, string id)
        {
            throw new System.NotImplementedException();
        }

        public override IRenderer<string> Header(IRenderer<string> inner, HeaderLevel level)
        {
            if (typeof(IBlockList).IsAssignableFrom(inner.GetType()))
            {
                IBlockList blocks = (IBlockList)inner;
                foreach (var item in blocks.Blocks)
                {
                    if (typeof(IHeaderStyleOwner).IsAssignableFrom(item.GetType()))
                    {
                        var styled = (IHeaderStyleOwner)item;
                        styled.Level = level;
                    }
                }
            }
            return inner;
        }

        public override MdToXamlNode Image(string href, string alt, string title)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlNode Link(string text, string href, string title)
        {
            return new Button(href, text, title);
        }

        public override IRenderer<string> ListItem(IEnumerable<IRenderer<string>> inner )
        {
            return new ListItem(inner, _map);
        }

        public override MdToXamlBlock OrderedList(IRenderer<string>[] list)
        {
            throw new System.NotImplementedException();
        }

        public override IRenderer<string> OrderedList(IEnumerable<IRenderer<string>> list)
        {
            throw new System.NotImplementedException();
        }

        public override IRenderer<string> Paragraph(ISpan<string> inner)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock Separator()
        {
            return new BlockSeparator();
        }

        public override MdToXamlNode Strike(MdToXamlNode span)
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

        public override MdToXamlBlock TableBody(IEnumerable<IRenderer<string>> rows)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock TableHeader(string[] headers)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock TableRow(MdToXamlBlock[] cells)
        {
            throw new System.NotImplementedException();
        }

        public override IRenderer<string> TableRow(IEnumerable<IRenderer<string>> cells)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlNode Text(string txt, int start, int len)
        {
            return new XamlText(txt, start, len, TextStyle.Normal,_map);
        }

        public override MdToXamlNode Underline(MdToXamlNode inner)
        {
            if (typeof(ITextStyleOwner).IsAssignableFrom(inner.GetType()))
            {
                ((ITextStyleOwner)inner).Style |= TextStyle.Underline;
            }
            return inner;
        }

        public override IRenderer<string> UnorderedList(IEnumerable<IRenderer<string>> list)
        {
            return new UnorderedList(list);
        }

        public override MdToXamlBlock UnorderedList(ISpan<string>[] list)
        {
            return new UnorderedList(list);
        }

        public override MdToXamlNode Video(string href, string alt, string title)
        {
            throw new System.NotImplementedException();
        }

        public override void Strong(IEnumerable<MdToXamlNode> inner)
        {
            throw new System.NotImplementedException();
        }

        public override void Emphasis(IEnumerable<MdToXamlNode> TSpan)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock NewLine()
        {
            return new BlockSeparator();
        }

        public override MdToXamlBlock Quote(IEnumerable<IRenderer<string>> inner)
        {
            throw new System.NotImplementedException();
        }

        public override void AddNewLineTo(MdToXamlNode span)
        {
            throw new System.NotImplementedException();
        }

        public override IRenderer<string> Header(IEnumerable<IRenderer<string>> inner, HeaderLevel level)
        {
            foreach (var child in inner)
            {
                if (typeof(XamlText).IsAssignableFrom(child.GetType()))
                    ((XamlText)child).Level = level;
            }
            return new Line(inner,_map);
        }

        public override IRenderer<string> TableCell(IEnumerable<IRenderer<string>> inner)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock Html(IEnumerable<IRenderer<string>> inner)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock DT(IEnumerable<IRenderer<string>> inner)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock DL(IEnumerable<IRenderer<string>> inner)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock DD(IEnumerable<IRenderer<string>> inner)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock FootNote(IEnumerable<IRenderer<string>> inner, string id)
        {
            throw new System.NotImplementedException();
        }
    }
}

