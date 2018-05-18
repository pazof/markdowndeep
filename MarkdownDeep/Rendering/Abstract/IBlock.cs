// // IBlock.cs
// /*
// Paul Schneider paul@pschneider.fr 15/05/2018 14:35 20182018 5 15
// */
using System;
namespace MarkdownDeep.Rendering.Abstract
{
    public interface IBlock<T> : IRenderer<T>
    {
        void FromSpan(ISpan<T> span);
    }
}
