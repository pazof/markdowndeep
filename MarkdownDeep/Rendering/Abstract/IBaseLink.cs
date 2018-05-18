using MarkdownDeep.Rendering.Abstract;

namespace MarkdownDeep.Rendering.Abstract
{
    public interface IBaseLink : ISimpleTextReference
    {
        IBaseTextChunk Label { get; }
        IBaseTextChunk Address { get; }
    }
}
