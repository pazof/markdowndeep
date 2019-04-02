
using System.Collections.Generic;
using MarkdownDeep;
using MarkdownDeep.Rendering;
using MarkdownDeep.Rendering.Abstract;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace MarkdownAVToXaml.Rendering.Text.Xaml.Xamarin
{
    /// <summary>
    ///  markdown renderer to Xaml
    /// </summary>

    public abstract class XamlRenderer<MdToXamlSpan> 
    : MarkdownRendererToString<MdToXamlBlock<MdToXamlSpan>, MdToXamlSpan>
         where MdToXamlSpan : ISpan
    {
        protected  IMap _map;
        protected string _mainClass;

        public XamlRenderer(string mainClass, IMap map=null)
        {
            _mainClass = mainClass;
            _map = map ?? new DefaultMap();
        }

        public XamlRenderer(IMap map, string mainClass)
        {
            _map = map;
            _mainClass = mainClass;
        }

        public  MdToXamlBlock<MDSpan> Separator()
        {
            return new BlockSeparator();
        }


        public override MdToXamlBlock<MdToXamlSpan> Paragraph(IEnumerable<MdToXamlBlock<MdToXamlSpan>> inner)
        {
            var result = Aggregate(inner);
            return result;
        }


        public override MdToXamlBlock<MdToXamlSpan> Aggregate(IEnumerable<MdToXamlBlock<MdToXamlSpan>> children)
        {
            if (children == null) return null;
            var first = children.FirstOrDefault();
            if (first == null) return null;
            foreach (var next in children.Skip(1))
                first.AddRange(next);
            return first;
        }
    }
}

