
namespace MarkdownDeep.Rendering.Abstract
{
    public interface IList : ISourceLocation
    {
        ListStyle DefaultStyle { get; set; }
        ISourceLocation[] Items { get; set; }
    }

}
