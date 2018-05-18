namespace MarkdownDeep.Rendering.Abstract
{

    // a text piece, providing a table
    public interface ITabledTextChunk : ISimpleTextReference, IText
    {
        string GetInnerText(int row, int col);
        int RowCount { get; }
        int ColumnCount { get; }
    }
}
