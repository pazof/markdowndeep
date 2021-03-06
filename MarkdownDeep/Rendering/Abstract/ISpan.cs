﻿using System;

namespace MarkdownDeep.Rendering.Abstract
{
    /// <summary>
    /// Span.
    /// seen as the unique terminal in the md grammar
    /// </summary>
    public interface ISpan : ISourceLocation
    {
        TextStyle Style { get; set; }

    }

}
