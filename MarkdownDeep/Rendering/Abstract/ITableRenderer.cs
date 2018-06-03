// // ITableRenderer.cs
// /*
// Paul Schneider paul@pschneider.fr 15/05/2018 14:39 20182018 5 15
// */
using System;
namespace MarkdownDeep.Rendering
{
    public interface  ITableRenderer<T>
    {
        T RenderTable(ITable<T> t);
    }
}
