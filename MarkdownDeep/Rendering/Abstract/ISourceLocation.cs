namespace MarkdownDeep.Rendering.Abstract
{
    // a simple text scope
    public interface ISourceLocation
    {
        int Start { get; }
        int Length { get; }
    }
}
