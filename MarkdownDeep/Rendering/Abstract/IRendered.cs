// // IRenderer.cs
// /*
// Paul Schneider paul@pschneider.fr 17/05/2018 12:56 20182018 5 17
// */
using System;
using System.Runtime.Serialization;
namespace MarkdownDeep.Rendering.Abstract
{
    public interface IRendered<T> 
    {
        T GetRenderer();
    }
}
