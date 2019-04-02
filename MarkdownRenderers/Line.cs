using MarkdownDeep.Rendering.Abstract;
using System.Collections.Generic;
using System.Dynamic;
namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    public abstract class Line<S> : MdToXamlBlock<S> where S : ISpan
    {
        public abstract Line<S> Create(IEnumerable<S> inner, IMap map);
    }
}
