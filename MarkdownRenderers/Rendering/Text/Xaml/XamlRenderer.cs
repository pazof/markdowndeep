
using System.Collections.Generic;
using MarkdownDeep;
using MarkdownDeep.Rendering;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    /// <summary>
    ///  markdown renderer to Xaml
    /// </summary>

    public class XamlRenderer : MarkdownRendererToString<MdToXamlNode, MdToXamlBlock> 
    {
        DefaultMap _map;

        public XamlRenderer()
        {
            _map = new DefaultMap();
        }

        public override void AddBlankTo(MdToXamlNode span)
        {
            throw new System.NotImplementedException();
        }

        public override void AddNewLineTo(MdToXamlNode span)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlNode Aggregate<T>(IRenderer<T>[] children)
        {
            
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock Aggregate(MdToXamlBlock[] children)
        {
            return new BlockList(children);
        }

        public override MdToXamlBlock AggregateFinalBlock(params MdToXamlBlock[] children)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlNode AggregateSpan(MdToXamlNode[] children)
        {
            return new Line(children);
        }

        public override MdToXamlNode Audio(string href, string alt, string title)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlNode Code(string source)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock CodeBlock(string[] lines, string lang)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock DD(MdToXamlNode inner)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock DT(MdToXamlBlock inner)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlNode Emphasis(MdToXamlNode[] TSpan)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock FootNote(MdToXamlNode inner, string id)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock Header(MdToXamlBlock inner, HeaderLevel level)
        {
            return new XamlHeader(inner, level, _map);
        }

        public override MdToXamlNode Image(string href, string alt, string title)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlNode Link(string text, string href, string title)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock ListItem(MdToXamlBlock inner)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock ListItem(MdToXamlNode inner)
        {
            return new ListItem(inner, _map);
        }

        public override MdToXamlBlock OrderedList(MdToXamlBlock[] list)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock Paragraph(MdToXamlNode inner)
        {
            return new Paragraph(inner);
        }

        public override MdToXamlBlock Quote(MdToXamlBlock inner)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlBlock Separator()
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlNode Strike(MdToXamlNode TSpan)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlNode Strong(MdToXamlNode[] inner)
        {
            
                foreach (var child in inner)
                {
                    if (typeof(ITextStyleOwner).IsAssignableFrom(child.GetType()))
                    {
                        ((ITextStyleOwner)child).Style |= TextStyle.Emphasys;
                    }
                }
            return new Line(inner);
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

        public override MdToXamlBlock TableRow(MdToXamlBlock[] cells)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlNode Text(string txt, int start, int len)
        {
            return new XamlText(txt, start, len);
        }

        public override MdToXamlNode Underline(MdToXamlNode inner)
        {
            
            if (typeof(ITextStyleOwner).IsAssignableFrom(inner.GetType()))
            {
                ((ITextStyleOwner)inner).Style |= TextStyle.Underline;
            }
            return inner;
        }

        public override MdToXamlBlock UnorderedList(MdToXamlBlock[] list)
        {
            throw new System.NotImplementedException();
        }

        public override MdToXamlNode Video(string href, string alt, string title)
        {
            throw new System.NotImplementedException();
        }
    }
}

