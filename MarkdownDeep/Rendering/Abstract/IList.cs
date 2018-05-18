
namespace MarkdownDeep.Rendering.Abstract
{
    public interface IList : IListedTextChunk
    {
        ListStyle DefaultStyle { get; set; }
        ISimpleTextReference[] Items { get; set; }
    }

}
