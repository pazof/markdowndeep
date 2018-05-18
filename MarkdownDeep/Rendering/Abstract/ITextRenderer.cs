// // IRenderer.cs
// /*
// Paul Schneider paul@pschneider.fr 15/05/2018 14:44 20182018 5 15
// */
using System;

namespace MarkdownDeep.Rendering.Abstract
{
    // not used ...
    public interface ITextRenderer<T> 
    {
        T RenderText(IText text);
    }
}
