using MarkdownDeep.Rendering.Abstract;

namespace MarkdownDeep.Rendering
{
    /// <summary>
    /// Table.
    /// </summary>
    public interface ITable<T> : IRenderer<T>, ISimpleTextReference
    {
        string GetInnerText(int row, int col);
        int RowCount { get; }
        int ColumnCount { get; }
    }

}
