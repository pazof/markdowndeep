// // TextStyles.cs
// /*
// Paul Schneider paul@pschneider.fr 06/05/2018 02:44 20182018 5 6
// */
using System;
namespace MarkdownDeep.Rendering.Abstract
{
    /// <summary>
    /// Text style.
    /// </summary>
    [Flags]
    public enum TextStyle: int
    {
        Normal,     // normal body text style
        Emphasys,   // **emphasys**
        Underline,  // _underline_ 
        Italic,     // *italic*
        Strike,     // ~~strike~~
        Fixed  // `code`
    }
}
