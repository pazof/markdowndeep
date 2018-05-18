﻿// // IRenderer.cs
// /*
// Paul Schneider paul@pschneider.fr 17/05/2018 12:56 20182018 5 17
// */
using System;
namespace MarkdownDeep.Rendering.Abstract
{
    public interface IRenderer<T>
    {
        T Render();
    }
}
