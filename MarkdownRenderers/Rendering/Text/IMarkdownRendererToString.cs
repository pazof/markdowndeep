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
}

