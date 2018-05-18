namespace MarkdownDeep.Rendering.Abstract
{
    // a simple text scope
    public interface ISimpleTextReference
    {
        int Start { get; }
        int Length { get; }
    }
}
