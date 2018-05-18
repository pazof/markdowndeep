namespace MarkdownDeep.Rendering.Abstract
{
    // a text piece, providing a list
    public interface IListedTextChunk : ISimpleTextReference, IText
    {
        /// <summary>
        /// Gets the inner text, 
        /// at the specified row, 
        /// in the original markdown format.
        /// </summary>
        /// <returns>The inner text.</returns>
        /// <param name="row">Row.</param>
        string GetInnerText(int row);
    }
}
