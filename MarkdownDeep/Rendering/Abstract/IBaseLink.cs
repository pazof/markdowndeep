using MarkdownDeep.Rendering.Abstract;

namespace MarkdownDeep.Rendering.Abstract
{
    public interface IBaseLink : ISourceLocation
    {
        ISourceLocation Label { get; }
        ISourceLocation Address { get; }
    }
}
