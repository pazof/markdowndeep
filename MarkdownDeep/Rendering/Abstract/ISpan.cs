using System;

namespace MarkdownDeep.Rendering.Abstract
{
    public interface ISpan<T> : IRenderer<T>, IBaseTextChunk
    {
        TextStyle Style { get; }
    }

}
